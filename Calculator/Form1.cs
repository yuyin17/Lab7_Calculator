using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private CalculatorBasic calc = new CalculatorBasic();
        private bool isNewEntry = true;
        private double firstOperand = 0;
        private string currentOperator = "";

        public Form1()
        {
            InitializeComponent();
            txtDisplay.Text = "0";
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (isNewEntry || txtDisplay.Text == "0" || txtDisplay.Text == "Error")
            {
                txtDisplay.Text = btn.Text;
                isNewEntry = false;
            }
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (isNewEntry || txtDisplay.Text == "Error")
            {
                txtDisplay.Text = "0.";
                isNewEntry = false;
            }
            else if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (double.TryParse(txtDisplay.Text, out double val))
            {
                firstOperand = val;
            }
            currentOperator = btn.Text;
            isNewEntry = true;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double secondOperand))
            {
                try
                {
                    calc.Clear();
                    calc.Add(firstOperand);

                    switch (currentOperator)
                    {
                        case "+": calc.Add(secondOperand); break;
                        case "-": calc.Subtract(secondOperand); break;
                        case "*": calc.Multiply(secondOperand); break;
                        case "/": calc.Divide(secondOperand); break;
                    }

                    txtDisplay.Text = calc.CurrentValue.ToString();
                }
                catch (DivideByZeroException)
                {
                    txtDisplay.Text = "Error";
                }
                catch (Exception)
                {
                    txtDisplay.Text = "Error";
                }
            }
            isNewEntry = true;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double val))
            {
                try
                {
                    txtDisplay.Text = calc.SquareRoot(val).ToString();
                }
                catch (Exception)
                {
                    txtDisplay.Text = "Error";
                }
            }
            isNewEntry = true;
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double val))
            {
                try
                {
                    txtDisplay.Text = calc.Reciprocal(val).ToString();
                }
                catch (DivideByZeroException)
                {
                    txtDisplay.Text = "Error";
                }
            }
            isNewEntry = true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double val))
            {
                txtDisplay.Text = calc.ChangeSign(val).ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            calc.Clear();
            txtDisplay.Text = "0";
            firstOperand = 0;
            currentOperator = "";
            isNewEntry = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1 && txtDisplay.Text != "Error")
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
                isNewEntry = true;
            }
        }
    }
}
public class CalculatorBasic
{
    private double currentValue = 0;
    public double CurrentValue => currentValue;

    public void Add(double value) { currentValue += value; }
    public void Subtract(double value) { currentValue -= value; }
    public void Multiply(double value) { currentValue *= value; }
    public void Divide(double value)
    {
        if (value == 0) throw new DivideByZeroException();
        currentValue /= value;
    }
    public double SquareRoot(double value) => Math.Sqrt(value);
    public double Reciprocal(double value) => 1 / value;
    public double ChangeSign(double value) => -value;
    public void Clear() { currentValue = 0; }
 } 