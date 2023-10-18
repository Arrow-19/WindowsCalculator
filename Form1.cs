using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Programmers_Calculator
{
    public partial class Form1 : Form
    {
        private const int Count = 1;
        string option="";
        decimal total;
        decimal num1;
        decimal num2;
        bool flag=false;
        public Form1()
        {
            InitializeComponent();
            ttl.KeyPress += ttl_KeyPress; // Attach the event handler
        }
        private void ttl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit (0-9) or a control key (e.g., Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If it's not a digit or control key, suppress the key press
                e.Handled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ttl.Text = ttl.Text + button1.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ttl.Text = ttl.Text + button2.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ttl.Text = ttl.Text + button3.Text;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ttl.Text = ttl.Text + button4.Text;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ttl.Text = ttl.Text + button6.Text;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ttl.Text = ttl.Text + button8.Text;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            ttl.Text = ttl.Text + button9.Text;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            ttl.Text = ttl.Text;
        }
        private void buttonclr_Click(object sender, EventArgs e)
        {
            ttl.Text = "";
            total = 0;
            num1 = 0;
            num2 = 0;
            flag = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ttl.Text += button5.Text;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ttl.Text += button7.Text;
        }
        private void button0_Click(object sender, EventArgs e)
        {
            ttl.Text += button0.Text;
        }
        private void buttoneq_Click(object sender, EventArgs e) //Only eql button has capability to set flag as false
        {
            try
            {
                num2 = decimal.Parse(ttl.Text);
            }
            catch (Exception) { ttl.Text = ""; }
            try
            {
                switch (option)
                {
                    case "+":
                        total = num1 + num2;
                        num1 = total;
                        ttl.Text = total.ToString();
                        flag = false;
                        option = "";
                        break;
                    case "-":
                        total = num1 - num2;
                        num1 = total;
                        ttl.Text = total.ToString();
                        flag = false;
                        option = "";
                        break;
                    case "*":
                        total = num1 * num2;
                        num1 = total;
                        ttl.Text = total.ToString();
                        flag = false;
                        option = "";
                        break;
                    case "/":
                        if (num1 == 0 && num2 == 0)
                            ttl.Text = "";
                        else
                        {
                            if (num1 == 04 && num2 == 05)
                            {
                                ttl.Text = "🍩";
                                break;
                            }
                            total = num1 / (decimal)num2;
                            num1 = total;
                            ttl.Text = total.ToString();
                            flag = false;
                        }
                        option = "";
                        break;
                }

            } catch(Exception ex) { MessageBox.Show("An error occured '"+ex.Message+ "'", "MATH ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ttl.Text = "";
            }
        }
        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (num1 != 0 && ttl.Text != "" && flag==true) {
                    num2 = decimal.Parse(ttl.Text);
                    switch (option) //switch to perform previously entered calculation before further calculation
                    {
                        case "+": num1 = num1 + num2; break;
                        case "-": num1 = num1 - num2; break;
                        case "*": num1 = num1 * num2; break;
                        case "/": num1 = num1 / num2; break;
                    }
                    option = "+";
                    flag = true;
                    ttl.Text = "";
                }
                else if(num1 != 0 && ttl.Text != "" && flag == false) //For continous calculation after equal btn click
                {
                    option = "+";
                    num1 = decimal.Parse(ttl.Text);
                    flag = true;
                    ttl.Text = "";
                }
                else
                { 
                option = "+";
                num1 = decimal.Parse(ttl.Text);
                ttl.Text = "";
                flag = true;
                }
            }
            catch (Exception) { ttl.Text = ""; }
        }
        private void buttonsub_Click(object sender, EventArgs e)
        {
            try
            {
                if (ttl.Text == "")
                {
                    ttl.Text = "-";
                    flag = false;
                }
                else if (num1 != 0 && ttl.Text != "" && flag==true)
                {
                    num2 = decimal.Parse(ttl.Text);
                    switch (option) //switch to perform previously entered calculation before further calculation
                    {
                        case "+":num1 = num1 + num2; break;
                        case "-":num1 = num1 - num2; break; 
                        case "*":num1 = num1 * num2; break;
                        case "/":num1 = num1 / num2; break;
                    }
                    option = "-";
                    flag = true;
                    ttl.Text = "";
                }
                else if(num1!=0 && ttl.Text !="" && flag == false)
                { 
                    option = "-";
                    num1 = decimal.Parse(ttl.Text);
                    flag = true;
                    ttl.Text = "";
                }
                else
                {
                    option = "-";
                    num1 = decimal.Parse(ttl.Text);
                    ttl.Text = "";
                    flag = true;
                }
            }
            catch (Exception) { ttl.Text = ""; }
        }
        private void buttonmul_Click(object sender, EventArgs e)
        {
            try
            {
                if (num1 != 0 && ttl.Text != "" && flag == true)
                {
                    num2 = decimal.Parse(ttl.Text);
                    switch (option) //switch to perform previously entered calculation before further calculation
                    {
                        case "+": num1 = num1 + num2; break;
                        case "-": num1 = num1 - num2; break; 
                        case "*": num1 = num1 * num2; break;
                        case "/": num1 = num1 / num2; break;
                    }
                    option = "*";
                    flag = true;
                    ttl.Text = "";
                }
                else if (num1 != 0 && ttl.Text != "" && flag == false)
                {
                    option = "*";
                    num1 = decimal.Parse(ttl.Text);
                    ttl.Text = "";
                    flag = true;
                }
                else
                {
                    option = "*";
                    num1 = decimal.Parse(ttl.Text);
                    ttl.Text = "";
                    flag= true;
                }
            }
            catch (Exception) { ttl.Text = ""; }
        }
        private void buttondiv_Click(object sender, EventArgs e)
        {
            try
            {
                if (num1 != 0 && ttl.Text != "" && flag == true)
                {
                    num2 = decimal.Parse(ttl.Text);
                    switch (option) //switch to perform previously entered calculation before further calculation
                    {
                        case "+": num1 = num1 + num2; break;
                        case "-": num1 = num1 - num2; break;
                        case "*": num1 = num1 * num2; break;
                        case "/": num1 = num1 / num2; break;
                    }
                    option = "/";
                    flag = true;
                    ttl.Text = "";
                }
                else if (num1 != 0 && ttl.Text != "" && flag == false)
                {
                    option = "/";
                    num1 = decimal.Parse(ttl.Text);
                    ttl.Text = "";
                    flag = true;
                }
                else
                {
                    option = "/";
                    num1 = decimal.Parse(ttl.Text);
                    ttl.Text = "";
                    flag = true;
                }
            }
            catch (Exception) { ttl.Text = ""; }
        }
        private void buttonpt_Click(object sender, EventArgs e)
        {
            if (ttl.Text.Contains("."))
                ttl.Text = ttl.Text;
            else
                ttl.Text += ".";
        }
        private void buttonbck_Click(object sender, EventArgs e)
        {
            try { 
            ttl.Text = ttl.Text.Remove(ttl.Text.Length - 1, Count);
            }
            catch(Exception) { ttl.Text = ""; }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
