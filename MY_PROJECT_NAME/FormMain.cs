using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EZ_B;
using ARC;
using System.Linq;
using System.IO.Ports;
using Pololu.Usc;

namespace MaestroServoController {

  public partial class FormMain : ARC.UCForms.FormPluginMaster {

    CustomConfig         _customConfig = new CustomConfig();
    Usc                  _controller = null;
    ushort               _minUS = 0;
    ushort               _maxUS = 0;

    public FormMain() {

      InitializeComponent();

      // Bind to the events for moving a servo and changing connection state
      EZBManager.PrimaryEZB.Servo.OnServoMove += Servo_OnServoMove;
      EZBManager.PrimaryEZB.Servo.OnServoGetPosition += Servo_OnServoGetPosition;
      EZBManager.PrimaryEZB.Servo.OnServoRelease += Servo_OnServoRelease;
      EZBManager.PrimaryEZB.Servo.OnServoAcceleration += Servo_OnServoAcceleration;
      EZBManager.PrimaryEZB.Servo.OnServoSpeed += Servo_OnServoSpeed;

      Invokers.SetAppendText(tbLog, true, "Connected Events");
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {

      if (_controller != null) {

        _controller.Dispose();
        _controller = null;
      }

      EZBManager.PrimaryEZB.Servo.OnServoMove -= Servo_OnServoMove;
      EZBManager.PrimaryEZB.Servo.OnServoGetPosition -= Servo_OnServoGetPosition;
      EZBManager.PrimaryEZB.Servo.OnServoRelease -= Servo_OnServoRelease;
      EZBManager.PrimaryEZB.Servo.OnServoAcceleration -= Servo_OnServoAcceleration;
      EZBManager.PrimaryEZB.Servo.OnServoSpeed -= Servo_OnServoSpeed;
    }

    public override void SetConfiguration(ARC.Config.Sub.PluginV1 cf) {

      cf.STORAGE.AddIfNotExist(ConfigTitles.DEVICE_SERIAL_NUMBER, string.Empty);
      cf.STORAGE.AddIfNotExist(ConfigTitles.MIN_US_VALUE, 1000);
      cf.STORAGE.AddIfNotExist(ConfigTitles.MAX_US_VALUE, 2000);

      _customConfig = (CustomConfig)cf.GetCustomObjectV2(_customConfig.GetType());

      _minUS = Convert.ToUInt16(cf.STORAGE[ConfigTitles.MIN_US_VALUE]);
      _maxUS = Convert.ToUInt16(cf.STORAGE[ConfigTitles.MAX_US_VALUE]);

      base.SetConfiguration(cf);

      initUSC();
    }

    private void initUSC() {

      var serialNumber = _cf.STORAGE[ConfigTitles.DEVICE_SERIAL_NUMBER].ToString();

      if (string.IsNullOrEmpty(serialNumber)) {

        Invokers.SetAppendText(tbLog, true, "No device selected. Select a Maestro Servo controller in the config menu");

        return;
      }

      if (_controller != null) {

        _controller.Dispose();
        _controller = null;
      }

      var dev = Usc.getConnectedDevices().FirstOrDefault(x => x.serialNumber == serialNumber);

      if (dev == null) {

        Invokers.SetAppendText(tbLog, true, "No device selected. Select a Maestro Servo controller in the config menu");

        return;
      }

      _controller = new Usc(dev);

      Invokers.SetAppendText(tbLog, true, $"Connected to {dev.serialNumber} with range {_minUS}us to {_maxUS}us");
    }

    public override object[] GetSupportedControlCommands() {

      return new string[] {
        string.Format("\"{0}\", [Virtual Servo Port Id], [us value]", ControlCommands.SET_POSITION_RAW),
        };
    }

    public override void SendCommand(string windowCommand, params string[] values) {

      if (windowCommand.Equals(ControlCommands.SET_POSITION_RAW, StringComparison.InvariantCultureIgnoreCase)) {

        if (values.Length != 2)
          throw new Exception("Expecting 2 parameters, which are the virtual servo port and us target");

        var port = (Servo.ServoPortEnum)Enum.Parse(typeof(Servo.ServoPortEnum), values[0], true) - Servo.ServoPortEnum.V0;

        var positionUS = Convert.ToUInt16(values[1]);

        _controller.setTarget((byte)port, positionUS);
      } else {

        base.SendCommand(windowCommand, values);
      }
    }

    private void Servo_OnServoSpeed(EZ_B.Classes.ServoSpeedItem[] servos) {

      if (_controller == null)
        return;

      try {

        List<byte> cmdData = new List<byte>();

        foreach (var servo in servos) {

          if (servo.Port < EZ_B.Servo.ServoPortEnum.V0 || servo.Port > EZ_B.Servo.ServoPortEnum.V99)
            continue;

          if (servo.Speed == -1)
            continue;

          var port = servo.Port - Servo.ServoPortEnum.V0;

          _controller.setSpeed((byte)port, (ushort)Functions.Map(servo.Speed, 0, 20, 0, 16383));
        }
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, ex.Message);
      }
    }

    private void Servo_OnServoAcceleration(EZ_B.Classes.ServoAccelerationItem[] servos) {

      if (_controller == null)
        return;

      try {

        List<byte> cmdData = new List<byte>();

        foreach (var servo in servos) {

          if (servo.Port < EZ_B.Servo.ServoPortEnum.V0 || servo.Port > EZ_B.Servo.ServoPortEnum.V99)
            continue;

          if (servo.Acceleration == -1)
            continue;

          var port = servo.Port - Servo.ServoPortEnum.V0;

          _controller.setAcceleration((byte)port, (ushort)servo.Acceleration);
        }
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, ex.Message);
      }
    }

    void Servo_OnServoMove(EZ_B.Classes.ServoPositionItem[] servos) {

      if (_controller == null)
        return;

      try {

        List<byte> cmdData = new List<byte>();

        foreach (var servo in servos) {

          if (servo.Port < EZ_B.Servo.ServoPortEnum.V0 || servo.Port > EZ_B.Servo.ServoPortEnum.V99)
            continue;

          if (!_customConfig.VirtualPorts.Contains(servo.Port))
            continue;

          var port = servo.Port - Servo.ServoPortEnum.V0;

          if (servo.Acceleration != -1)
            _controller.setAcceleration((byte)port, (ushort)servo.Acceleration);

          if (servo.Speed != -1)
            _controller.setSpeed((byte)port, (ushort)Functions.Map(servo.Speed, 0, 20, 0, 16383));

          var position = Functions.Map(servo.Position, Servo.SERVO_MIN, Servo.SERVO_MAX, _minUS, _maxUS);

          _controller.setTarget((byte)port, (ushort)position);
        }
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, ex.Message);
      }
    }

    public override void ConfigPressed() {

      using (FormConfig form = new FormConfig()) {

        if (_controller != null) {

          _controller.Dispose();
          _controller = null;
        }

        form.SetConfiguration(_cf);

        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          SetConfiguration(form.GetConfiguration());
        else
          initUSC();
      }
    }

    private void Servo_OnServoRelease(Servo.ServoPortEnum[] servos) {

      try {

        List<byte> cmdData = new List<byte>();

        foreach (var servo in servos) {

          if (servo < EZ_B.Servo.ServoPortEnum.V0 || servo > EZ_B.Servo.ServoPortEnum.V99)
            continue;

          if (!_customConfig.VirtualPorts.Contains(servo))
            continue;

          var port = servo - Servo.ServoPortEnum.V0;

          _controller.setTarget((byte)port, 0);
        }
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, ex.Message);
      }
    }

    private void Servo_OnServoGetPosition(Servo.ServoPortEnum servoPort, EZ_B.Classes.GetServoValueResponse getServoResponse) {

      try {

        if (getServoResponse.Success)
          return;

        if (!_customConfig.VirtualPorts.Contains(servoPort)) {

          getServoResponse.ErrorStr = "No matching Maestro servo specified";
          getServoResponse.Success = false;

          return;
        }

        Invokers.SetAppendText(tbLog, true, "Reading position from {0}", servoPort);

        if (_controller == null) {

          getServoResponse.Success = false;
          getServoResponse.ErrorStr = "Device not connected";

          return;
        }

        ServoStatus[] servos;
        _controller.getVariables(out servos);

        var port = servoPort - Servo.ServoPortEnum.V0;

        if (port > servos.Length) {

          getServoResponse.Success = false;
          getServoResponse.ErrorStr = $"Requested servo port is out of range. There are only {servos.Length} servos on this maestro";

          return;
        }

        getServoResponse.Position = (int)EZ_B.Functions.RemapScalar(servos[port].position, 1, 1000, Servo.SERVO_MIN, Servo.SERVO_MAX);
        getServoResponse.Success = true;

      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, ex.Message);
      }
    }
  }
}
