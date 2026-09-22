using System;
using System.Drawing;
using System.Windows.Forms;

namespace Experiment9;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        CreateMdiHospitalForm();
    }

    private void CreateMdiHospitalForm()
    {
        Text = "Hospital Management System";
        WindowState = FormWindowState.Maximized;
        IsMdiContainer = true;

        MenuStrip menuStrip = new MenuStrip();

        ToolStripMenuItem fileMenu =
            new ToolStripMenuItem("File");

        ToolStripMenuItem registerPatientMenu =
            new ToolStripMenuItem("Register Patient");

        ToolStripMenuItem exitMenu =
            new ToolStripMenuItem("Exit");

        registerPatientMenu.Click += RegisterPatientMenu_Click;
        exitMenu.Click += ExitMenu_Click;

        fileMenu.DropDownItems.Add(registerPatientMenu);
        fileMenu.DropDownItems.Add(new ToolStripSeparator());
        fileMenu.DropDownItems.Add(exitMenu);

        ToolStripMenuItem windowMenu =
            new ToolStripMenuItem("Window");

        ToolStripMenuItem cascadeMenu =
            new ToolStripMenuItem("Cascade");

        ToolStripMenuItem tileMenu =
            new ToolStripMenuItem("Tile Horizontally");

        cascadeMenu.Click += CascadeMenu_Click;
        tileMenu.Click += TileMenu_Click;

        windowMenu.DropDownItems.Add(cascadeMenu);
        windowMenu.DropDownItems.Add(tileMenu);

        menuStrip.Items.Add(fileMenu);
        menuStrip.Items.Add(windowMenu);

        MainMenuStrip = menuStrip;
        Controls.Add(menuStrip);
    }

    private void RegisterPatientMenu_Click(
        object? sender,
        EventArgs e)
    {
        PatientDialog patientDialog = new PatientDialog();

        if (patientDialog.ShowDialog() == DialogResult.OK)
        {
            Form patientRecordForm = new Form();

            patientRecordForm.Text = "Patient Record";
            patientRecordForm.MdiParent = this;
            patientRecordForm.Size = new Size(420, 280);

            Label lblPatientDetails = new Label();

            lblPatientDetails.Text =
                $"PATIENT DETAILS\n\n" +
                $"Patient Name : {patientDialog.PatientName}\n" +
                $"Age          : {patientDialog.PatientAge}\n" +
                $"Department   : {patientDialog.Department}";

            lblPatientDetails.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            lblPatientDetails.Dock = DockStyle.Fill;
            lblPatientDetails.Padding = new Padding(25);

            patientRecordForm.Controls.Add(lblPatientDetails);
            patientRecordForm.Show();
        }
    }

    private void CascadeMenu_Click(
        object? sender,
        EventArgs e)
    {
        LayoutMdi(MdiLayout.Cascade);
    }

    private void TileMenu_Click(
        object? sender,
        EventArgs e)
    {
        LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void ExitMenu_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }
}

public class PatientDialog : Form
{
    private TextBox txtPatientName = new TextBox();
    private TextBox txtAge = new TextBox();
    private ComboBox cmbDepartment = new ComboBox();

    public string PatientName
    {
        get { return txtPatientName.Text; }
    }

    public string PatientAge
    {
        get { return txtAge.Text; }
    }

    public string Department
    {
        get { return cmbDepartment.Text; }
    }

    public PatientDialog()
    {
        Text = "Patient Registration";
        Size = new Size(400, 310);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Label lblTitle = new Label();
        lblTitle.Text = "PATIENT REGISTRATION";
        lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(85, 25);

        Label lblName = new Label();
        lblName.Text = "Patient Name:";
        lblName.AutoSize = true;
        lblName.Location = new Point(50, 90);

        txtPatientName.Location = new Point(170, 85);
        txtPatientName.Width = 160;

        Label lblAge = new Label();
        lblAge.Text = "Age:";
        lblAge.AutoSize = true;
        lblAge.Location = new Point(50, 135);

        txtAge.Location = new Point(170, 130);
        txtAge.Width = 160;

        Label lblDepartment = new Label();
        lblDepartment.Text = "Department:";
        lblDepartment.AutoSize = true;
        lblDepartment.Location = new Point(50, 180);

        cmbDepartment.Location = new Point(170, 175);
        cmbDepartment.Width = 160;

        cmbDepartment.Items.Add("General Medicine");
        cmbDepartment.Items.Add("Cardiology");
        cmbDepartment.Items.Add("Orthopaedics");
        cmbDepartment.Items.Add("Neurology");

        Button btnSave = new Button();
        btnSave.Text = "Save";
        btnSave.Location = new Point(170, 225);
        btnSave.Width = 75;
        btnSave.Click += BtnSave_Click;

        Button btnCancel = new Button();
        btnCancel.Text = "Cancel";
        btnCancel.Location = new Point(255, 225);
        btnCancel.Width = 75;
        btnCancel.DialogResult = DialogResult.Cancel;

        Controls.Add(lblTitle);
        Controls.Add(lblName);
        Controls.Add(txtPatientName);
        Controls.Add(lblAge);
        Controls.Add(txtAge);
        Controls.Add(lblDepartment);
        Controls.Add(cmbDepartment);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
    }

    private void BtnSave_Click(
        object? sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtPatientName.Text) ||
            string.IsNullOrWhiteSpace(txtAge.Text) ||
            string.IsNullOrWhiteSpace(cmbDepartment.Text))
        {
            MessageBox.Show(
                "Please enter all patient details.",
                "Missing Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}