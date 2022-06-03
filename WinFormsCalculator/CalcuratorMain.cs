using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.CSharp;
using System.CodeDom.Compiler;


namespace WinFormsCalculator
{
    public partial class Form_calculatorMain : Form
    {
        DataTable dt = new DataTable();

        double result = 0;
        bool isOverwritable = true;
        char currentOperation = '0';
        double latestNum = 0;

        public Form_calculatorMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_0_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "0";
            }
            else
            {
                txtResult.Text += '0';
            }
        }
        private void button_1_Click(object sender, EventArgs e)
        {

            if (isOverwritable)
            {
                txtResult.Text = "1";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '1';
            }
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "2";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '2';
            }
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "3";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '3';
            }
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "4";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '4';
            }
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "5";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '5';
            }
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "6";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '6';
            }
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "7";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '7';
            }
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "8";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '8';
            }
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "9";
                isOverwritable = false;
            }
            else
            {
                txtResult.Text += '9';
            }
        }

        private void button_point_Click(object sender, EventArgs e)
        {
            if (isOverwritable)
            {
                txtResult.Text = "0.";
                isOverwritable = false;
            }
            else if (txtResult.Text != "0" && !txtResult.Text.Contains('.') && txtResult.Text.Length < txtResult.MaxLength)
            {
                txtResult.Text += '.';
            }
        }
        private void button_negation_Click(object sender, EventArgs e)
        {
            if (txtResult.Text != "0")
                txtResult.Text = (-Convert.ToDouble(txtResult.Text)).ToString();
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            currentOperation = '*';
            latestNum = Convert.ToDouble(txtResult.Text);

            if (lblEquation.Text == "")
            {
                result = latestNum;
            }
            else if (!isOverwritable)
            {
                result *= latestNum;
            }
            lblEquation.Text = result + " * ";
            isOverwritable = true;
        }
        private void button_divide_Click(object sender, EventArgs e)
        {
            currentOperation = '/';
            latestNum = Convert.ToDouble(txtResult.Text);

            if (lblEquation.Text == "")
            {
                result = latestNum;
            }
            else if (!isOverwritable)
            {
                result /= latestNum;
            }
            lblEquation.Text = result + " / ";
            isOverwritable = true;
        }
        private void button_subtract_Click(object sender, EventArgs e)
        {
            currentOperation = '-';
            latestNum = Convert.ToDouble(txtResult.Text);

            if (lblEquation.Text == "")
            {
                result = latestNum;
            }
            else if (!isOverwritable)
            {
                result -= latestNum;
            }

            lblEquation.Text = result + " - ";
            isOverwritable = true;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            currentOperation = '+';
            latestNum = Convert.ToDouble(txtResult.Text);

            if (lblEquation.Text == "")
            {
                result = latestNum;
            }
            else if(!isOverwritable)
            {
                result += latestNum;
            }

            lblEquation.Text = result + " + ";
            isOverwritable = true;
        }

        private void button_equals_Click(object sender, EventArgs e)
        {
            if (lblEquation.Text.Contains('+'))
            {
                result += Convert.ToDouble(txtResult.Text);
                latestNum = Convert.ToDouble(txtResult.Text);
            }
            else if (lblEquation.Text.Contains('-'))
            {
                result -= Convert.ToDouble(txtResult.Text);
                latestNum = Convert.ToDouble(txtResult.Text);
            }
            else if (lblEquation.Text.Contains('/'))
            {
                result /= Convert.ToDouble(txtResult.Text);
                latestNum = Convert.ToDouble(txtResult.Text);
            }
            else if (lblEquation.Text.Contains('*'))
            {
                result *= Convert.ToDouble(txtResult.Text);
                latestNum = Convert.ToDouble(txtResult.Text);
            }
            
            if (lblEquation.Text == "")
            {
                txtResult.Text = Calculate(Convert.ToDouble(txtResult.Text), latestNum).ToString();
            }
            else if(currentOperation != '0')
            {
                txtResult.Text = result.ToString();
            }

            lblEquation.Text = "";
            result = 0;
            isOverwritable = true;
        }
        private void button_backspace_Click(object sender, EventArgs e)
        {
            if (isOverwritable || txtResult.Text.Length == 1)
            {
                txtResult.Text = "0";
            }
            else
            {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);
                if(txtResult.Text.Length == 1)
                {
                    isOverwritable = true;
                }
            }

        }
        private void button_C_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            isOverwritable = true;
        }
        private void button_CE_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            lblEquation.Text = "";
            result = 0;
            currentOperation = '0';
            isOverwritable = true;
        }

        private double Calculate(double a, double b)
        {
            if(currentOperation != '0')
            {
                return Convert.ToDouble(dt.Compute(a.ToString() + currentOperation + b.ToString(), ""));
            }
            return a;
        }
    }
}
