using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            richTextBox1.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            else
            {
                int t = 0;
                int flag = 0;
                Stack<char> q1 = new Stack<char>();
                q1.Clear();
                char[] num = new char[1000];
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (textBox1.Text[i] >= '0' && textBox1.Text[i] <= '9')
                        num[t++] = textBox1.Text[i];
                    else
                    {
                        num[t++] = 'q';
                        if (flag == 0)
                        {
                            q1.Push(textBox1.Text[i]);
                            flag = 1;
                            continue;
                        }
                        if (q1.Count != 0&&Judge(textBox1.Text[i], q1.Peek()))
                            q1.Push(textBox1.Text[i]);
                        else if(q1.Count != 0)
                        {
                            num[t++] = q1.Pop();
                            while (q1.Count != 0&&!Judge(textBox1.Text[i], q1.Peek()))
                            {
                                num[t++] = q1.Pop();
                            }
                            q1.Push(textBox1.Text[i]);
                        }
                    }
                }
                num[t++] = 'q';
                while (q1.Count!=0)
                {
                    num[t++] = q1.Pop();
                }
                double ans = Cal(num,t);
                if(ans == 1.7976931348623157E308)
                    richTextBox1.Text = "错误!";
                else
                    richTextBox1.Text = ans.ToString();
            }
        }
        private static double Cal(char[] num,int t)
        {
            Stack<double> q2 = new Stack<double>();
            int ans = 0;
            for(int i=0;i<t;i++)
            {
                if (num[i] == 'q')
                {
                    q2.Push(ans);
                    ans = 0;
                }
                else if (num[i] >= '0' && num[i] <= '9')
                {
                    ans = ans * 10 + num[i] - '0';
                }
                else
                {
                    double x1 = q2.Pop();
                    double x2 = q2.Pop();
                    if (num[i] == '+')
                        q2.Push(x2 + x1);
                    else if (num[i] == '-')
                        q2.Push(x2 - x1);
                    else if (num[i] == '*')
                        q2.Push(x2 * x1);
                    else if (num[i] == '/'&&x1!=0)
                        q2.Push(x2 / x1);
                }
            }
            if (q2.Count != 0)
                return q2.Pop();
            else
                return 1.7976931348623157E308;

        }
        private static bool Judge(char s1,char s2)
        {
            if (s1 == '*' && s2 == '+')
                return true;
            else if (s1 == '*' && s2 == '-')
                return true;
            else if (s1 == '/' && s2 == '+')
                return true;
            else if (s1 == '/' && s2 == '-')
                return true;
            else
                return false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text +="4";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
