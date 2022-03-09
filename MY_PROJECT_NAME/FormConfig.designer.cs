using ARC.UCForms;
namespace MaestroServoController {
  partial class FormConfig {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.nudMaxUS = new System.Windows.Forms.NumericUpDown();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.nudMinUS = new System.Windows.Forms.NumericUpDown();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbDevice = new System.Windows.Forms.ComboBox();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.clbPorts = new System.Windows.Forms.CheckedListBox();
      this.ucTabControl1 = new ARC.UCForms.UCTabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox5.SuspendLayout();
      this.groupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxUS)).BeginInit();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudMinUS)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.ucTabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.label1);
      this.groupBox5.Controls.Add(this.groupBox3);
      this.groupBox5.Controls.Add(this.groupBox2);
      this.groupBox5.Controls.Add(this.groupBox1);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox5.Location = new System.Drawing.Point(3, 3);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(987, 93);
      this.groupBox5.TabIndex = 7;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Settings";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.nudMaxUS);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
      this.groupBox3.Location = new System.Drawing.Point(444, 16);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(241, 74);
      this.groupBox3.TabIndex = 4;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Max us Value";
      // 
      // nudMaxUS
      // 
      this.nudMaxUS.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nudMaxUS.Location = new System.Drawing.Point(3, 16);
      this.nudMaxUS.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
      this.nudMaxUS.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.nudMaxUS.Name = "nudMaxUS";
      this.nudMaxUS.Size = new System.Drawing.Size(235, 20);
      this.nudMaxUS.TabIndex = 1;
      this.nudMaxUS.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.nudMinUS);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
      this.groupBox2.Location = new System.Drawing.Point(203, 16);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(241, 74);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Min us Value";
      // 
      // nudMinUS
      // 
      this.nudMinUS.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nudMinUS.Location = new System.Drawing.Point(3, 16);
      this.nudMinUS.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
      this.nudMinUS.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.nudMinUS.Name = "nudMinUS";
      this.nudMinUS.Size = new System.Drawing.Size(235, 20);
      this.nudMinUS.TabIndex = 0;
      this.nudMinUS.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cbDevice);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
      this.groupBox1.Location = new System.Drawing.Point(3, 16);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(200, 74);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Device";
      // 
      // cbDevice
      // 
      this.cbDevice.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbDevice.FormattingEnabled = true;
      this.cbDevice.Location = new System.Drawing.Point(3, 16);
      this.cbDevice.Name = "cbDevice";
      this.cbDevice.Size = new System.Drawing.Size(194, 21);
      this.cbDevice.TabIndex = 1;
      // 
      // btnSave
      // 
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Location = new System.Drawing.Point(8, 3);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 41);
      this.btnSave.TabIndex = 8;
      this.btnSave.Text = "&Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Location = new System.Drawing.Point(103, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 41);
      this.btnCancel.TabIndex = 9;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 598);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1001, 48);
      this.panel1.TabIndex = 10;
      // 
      // clbPorts
      // 
      this.clbPorts.Dock = System.Windows.Forms.DockStyle.Fill;
      this.clbPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.clbPorts.FormattingEnabled = true;
      this.clbPorts.Location = new System.Drawing.Point(3, 96);
      this.clbPorts.MultiColumn = true;
      this.clbPorts.Name = "clbPorts";
      this.clbPorts.Size = new System.Drawing.Size(987, 441);
      this.clbPorts.TabIndex = 11;
      this.clbPorts.ThreeDCheckBoxes = true;
      // 
      // ucTabControl1
      // 
      this.ucTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
      this.ucTabControl1.BackColor = System.Drawing.Color.White;
      this.ucTabControl1.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(170)))), ((int)(((byte)(234)))));
      this.ucTabControl1.ButtonSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(146)))), ((int)(((byte)(66)))));
      this.ucTabControl1.ButtonTextColor = System.Drawing.Color.White;
      this.ucTabControl1.Controls.Add(this.tabPage1);
      this.ucTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTabControl1.ItemSize = new System.Drawing.Size(60, 50);
      this.ucTabControl1.Location = new System.Drawing.Point(0, 0);
      this.ucTabControl1.Margin = new System.Windows.Forms.Padding(0);
      this.ucTabControl1.MarginLeft = 0;
      this.ucTabControl1.MarginTop = 0;
      this.ucTabControl1.Multiline = true;
      this.ucTabControl1.Name = "ucTabControl1";
      this.ucTabControl1.Padding = new System.Drawing.Point(0, 0);
      this.ucTabControl1.SelectedIndex = 0;
      this.ucTabControl1.Size = new System.Drawing.Size(1001, 598);
      this.ucTabControl1.TabIndex = 3;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.clbPorts);
      this.tabPage1.Controls.Add(this.groupBox5);
      this.tabPage1.Location = new System.Drawing.Point(4, 54);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(993, 540);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Settings";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(685, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(299, 74);
      this.label1.TabIndex = 5;
      this.label1.Text = "Note: \r\nCheck the manual for your servos to determine the min and max us pulse ra" +
    "nge. The average hobby servo is min 1000 and max 2000.";
      // 
      // FormConfig
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSize = true;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(1001, 646);
      this.Controls.Add(this.ucTabControl1);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormConfig";
      this.Text = "Configuration";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
      this.groupBox5.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.nudMaxUS)).EndInit();
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.nudMinUS)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ucTabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckedListBox clbPorts;
    private UCTabControl ucTabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.ComboBox cbDevice;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.NumericUpDown nudMaxUS;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.NumericUpDown nudMinUS;
    private System.Windows.Forms.Label label1;
  }
}