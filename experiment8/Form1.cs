using System;
using System.Drawing;
using System.Windows.Forms;

namespace Experiment8;

public partial class Form1 : Form
{
    private TextBox txtPrincipal = new TextBox();
    private TextBox txtRate = new TextBox();
    private TextBox txtTime = new TextBox();

    private Label lblResult = new Label();

    public Form1()
    {
        InitializeComponent();
        CreateInterestCalculatorForm();
    }

    private void CreateInterestCalculatorForm()
    {
        Text = "Simple Interest Calculator";
        Size = new Size(480, 360);
        StartPosition = FormStartPosition.CenterScreen;

        Label lblTitle = new Label();
        lblTitle.Text = "SIMPLE INTEREST CALCULATOR";
        lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(90, 25);

        Label lblPrincipal = new Label();
        lblPrincipal.Text = "Principal Amount (Rs.):";
        lblPrincipal.AutoSize = true;
        lblPrincipal.Location = new Point(70, 90);

        txtPrincipal.Location = new Point(250, 85);
        txtPrincipal.Width = 140;

        Label lblRate = new Label();
        lblRate.Text = "Rate of Interest (%):";
        lblRate.AutoSize = true;
        lblRate.Location = new Point(70, 135);

        txtRate.Location = new Point(250, 130);
        txtRate.Width = 140;

        Label lblTime = new Label();
        lblTime.Text = "Time Period (Years):";
        lblTime.AutoSize = true;
        lblTime.Location = new Point(70, 180);

        txtTime.Location = new Point(250, 175);
        txtTime.Width = 140;

        Button btnCalculate = new Button();
        btnCalculate.Text = "Calculate Interest";
        btnCalculate.Location = new Point(165, 220);
        btnCalculate.Width = 145;
        btnCalculate.Click += BtnCalculate_Click;

        Button btnClear = new Button();
        btnClear.Text = "Clear";
        btnClear.Location = new Point(320, 220);
        btnClear.Width = 70;
        btnClear.Click += BtnClear_Click;

        lblResult.AutoSize = true;
        lblResult.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        lblResult.Location = new Point(70, 270);

        Controls.Add(lblTitle);
        Controls.Add(lblPrincipal);
        Controls.Add(txtPrincipal);
        Controls.Add(lblRate);
        Controls.Add(txtRate);
        Controls.Add(lblTime);
        Controls.Add(txtTime);
        Controls.Add(btnCalculate);
        Controls.Add(btnClear);
        Controls.Add(lblResult);
    }

    private void BtnCalculate_Click(
        object? sender,
        EventArgs e)
    {
        bool isPrincipalValid =
            double.TryParse(txtPrincipal.Text, out double principal);

        bool isRateValid =
            double.TryParse(txtRate.Text, out double rate);

        bool isTimeValid =
            double.TryParse(txtTime.Text, out double time);

        if (!isPrincipalValid ||
            !isRateValid ||
            !isTimeValid ||
            principal < 0 ||
            rate < 0 ||
            time < 0)
        {
            MessageBox.Show(
                "Enter valid positive values for principal, rate, and time.",
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        double simpleInterest = (principal * rate * time) / 100;
        double maturityAmount = principal + simpleInterest;

        lblResult.Text =
            $"Simple Interest: Rs. {simpleInterest:F2}\n" +
            $"Maturity Amount: Rs. {maturityAmount:F2}";
    }

    private void BtnClear_Click(
        object? sender,
        EventArgs e)
    {
        txtPrincipal.Clear();
        txtRate.Clear();
        txtTime.Clear();
        lblResult.Text = "";
        txtPrincipal.Focus();
    }
}