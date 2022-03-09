using ARC.Config.Sub;
using EZ_B;
using Pololu.Usc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MaestroServoController {

  public partial class FormConfig : Form {

    PluginV1 _cf = new PluginV1();

    public FormConfig() {

      InitializeComponent();
    }

    private void Form_FormClosing(object sender, FormClosingEventArgs e) {

    }

    public void SetConfiguration(PluginV1 cf) {

      _cf = cf;

      CustomConfig customConfig = (CustomConfig)cf.GetCustomObjectV2(typeof(CustomConfig));

      foreach (Servo.ServoPortEnum port in Enum.GetValues(typeof(Servo.ServoPortEnum)))
        if (port >= Servo.ServoPortEnum.V1 && port <= Servo.ServoPortEnum.V99)
          clbPorts.Items.Add(port, customConfig.VirtualPorts.Contains(port));

      foreach (var device in Usc.getConnectedDevices())
        clbPorts.Items.Add(device.serialNumber);

      cbDevice.SelectedItem = cf.STORAGE[ConfigTitles.DEVICE_SERIAL_NUMBER].ToString();

      nudMinUS.Value = Convert.ToInt16(cf.STORAGE[ConfigTitles.MIN_US_VALUE]);

      nudMaxUS.Value = Convert.ToInt16(cf.STORAGE[ConfigTitles.MAX_US_VALUE]);
    }

    public PluginV1 GetConfiguration() {

      return _cf;
    }

    private void btnSave_Click(object sender, EventArgs e) {

      try {

        List<Servo.ServoPortEnum> virtualPorts = new List<Servo.ServoPortEnum>();

        foreach (var selected in clbPorts.CheckedItems)
          virtualPorts.Add((Servo.ServoPortEnum)selected);

        _cf.SetCustomObjectV2(
          new CustomConfig() {
            VirtualPorts = virtualPorts.ToArray()
          });

        _cf.STORAGE[ConfigTitles.DEVICE_SERIAL_NUMBER] = cbDevice.SelectedItem == null ? string.Empty : cbDevice.SelectedItem.ToString();

        _cf.STORAGE[ConfigTitles.MIN_US_VALUE] = nudMinUS.Value;

        _cf.STORAGE[ConfigTitles.MAX_US_VALUE] = nudMaxUS.Value;

        DialogResult = System.Windows.Forms.DialogResult.OK;
      } catch (Exception ex) {

        MessageBox.Show(ex.Message);
      }
    }

    private void btnCancel_Click(object sender, EventArgs e) {

      DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }
  }
}
