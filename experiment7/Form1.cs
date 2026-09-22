using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Experiment7;

public partial class Form1 : Form
{
    private TextBox txtStudentName = new TextBox();

    private NumericUpDown numCSharp = new NumericUpDown();
    private NumericUpDown numDatabase = new NumericUpDown();
    private NumericUpDown numMathematics = new NumericUpDown();

    private Label lblResult = new Label();

    public Form1()
    {
        InitializeComponent();
        CreateStudentMarksForm();
    }

    private void CreateStudentMarksForm()
    {
        Text = "Student Marks Entry Form";
        Size = new Size(500, 400);
        StartPosition = FormStartPosition.CenterScreen;

        Label lblTitle = new Label();
        lblTitle.Text = "STUDENT MARKS ENTRY";
        lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(135, 25);

        Label lblName = new Label();
        lblName.Text = "Student Name:";
        lblName.Location = new Point(70, 85);
        lblName.AutoSize = true;

        txtStudentName.Location = new Point(210, 80);
        txtStudentName.Width = 180;

        Label lblCSharp = new Label();
        lblCSharp.Text = "C# Programming:";
        lblCSharp.Location = new Point(70, 125);
        lblCSharp.AutoSize = true;

        numCSharp.Location = new Point(210, 120);
        numCSharp.Maximum = 100;
        numCSharp.Width = 100;

        Label lblDatabase = new Label();
        lblDatabase.Text = "Database:";
        lblDatabase.Location = new Point(70, 165);
        lblDatabase.AutoSize = true;

        numDatabase.Location = new Point(210, 160);
        numDatabase.Maximum = 100;
        numDatabase.Width = 100;

        Label lblMathematics = new Label();
        lblMathematics.Text = "Mathematics:";
        lblMathematics.Location = new Point(70, 205);
        lblMathematics.AutoSize = true;

        numMathematics.Location = new Point(210, 200);
        numMathematics.Maximum = 100;
        numMathematics.Width = 100;

        Button btnCalculate = new Button();
        btnCalculate.Text = "Calculate Result";
        btnCalculate.Location = new Point(180, 245);
        btnCalculate.Width = 130;
        btnCalculate.Click += BtnCalculate_Click;

        lblResult.Location = new Point(70, 295);
        lblResult.AutoSize = true;
        lblResult.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        Controls.Add(lblTitle);
        Controls.Add(lblName);
        Controls.Add(txtStudentName);
        Controls.Add(lblCSharp);
        Controls.Add(numCSharp);
        Controls.Add(lblDatabase);
        Controls.Add(numDatabase);
        Controls.Add(lblMathematics);
        Controls.Add(numMathematics);
        Controls.Add(btnCalculate);
        Controls.Add(lblResult);
    }

    private void BtnCalculate_Click(
        object? sender,
        EventArgs e)
    {
        string studentName = txtStudentName.Text;

        if (string.IsNullOrWhiteSpace(studentName))
        {
            MessageBox.Show(
                "Please enter the student name.",
                "Missing Name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        decimal csharpMark = numCSharp.Value;
        decimal databaseMark = numDatabase.Value;
        decimal mathematicsMark = numMathematics.Value;

        decimal total = csharpMark + databaseMark + mathematicsMark;
        decimal average = total / 3;

        string result;

        if (csharpMark < 40 ||
            databaseMark < 40 ||
            mathematicsMark < 40)
        {
            result = "Fail";
        }
        else
        {
            result = "Pass";
        }

        lblResult.Text =
            $"Student: {studentName}\n" +
            $"Total: {total} / 300\n" +
            $"Average: {average:F2}%\n" +
            $"Result: {result}";
    }
}