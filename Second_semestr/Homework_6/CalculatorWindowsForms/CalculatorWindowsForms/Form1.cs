using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StackCalculatorNamespace;

namespace CalculatorWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnButtonNumbersClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            buffer += button.Text;
            display.Text += button.Text;
        }

        private void OnOperationClick(object sender, EventArgs e)
        {
            if (buffer == "")
            {
                return;
            }

            try
            {
                calculator.Push(Convert.ToDouble(buffer));
            }
            catch (FormatException)
            {
                this.OnCClick(1, e);
                display.Text = "Ошибка:";
                display2.Text = "Вы ввели число в некорректном формате";
                return;
            }
            
            if (sign != '\0')
            {
                try
                {
                    calculator.Operation(sign);
                }
                catch (MyDivideByZeroException)
                {
                    this.OnCClick(sender, e);
                    display2.Text = "Ошибка: Делить на ноль нельзя";
                    return;
                }

                display2.Text = Convert.ToString(calculator.Result());
                display.Text = display2.Text;
            }

            buffer = "";
            var button = (Button)sender;
            sign = button.Text[0];
            display.Text += button.Text;
        }

        private void OnEqualClick(object sender, EventArgs e)
        {
            if (calculator.IsEmpty())
            {
                return;
            }

            if (buffer != "")
            {
                try
                {
                    calculator.Push(Convert.ToDouble(buffer));
                    calculator.Operation(sign);
                }
                catch (FormatException)
                {
                    this.OnCClick(sender, e);
                    display2.Text = "Ошибка: Вы ввели число в некорректном формате";
                    return;
                }
                catch (MyDivideByZeroException)
                {
                    this.OnCClick(sender, e);
                    display2.Text = "Ошибка: Делить на ноль нельзя";
                    return;
                }
            }

            display.Text = Convert.ToString(calculator.Result());
            display2.Text = "";
            buffer = display.Text;
            sign = '\0';
        }

        private void OnCClick(object sender, EventArgs e)
        {
            buffer = "";
            display.Text = "";
            display2.Text = "";
            sign = '\0';
            calculator.Clear();
        }

        private string buffer = "";
        private StackCalculator calculator = new StackCalculator();
        private char sign = '\0';
    }
}
