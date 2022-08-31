using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midterm_project
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        Form3 f3;

        public Form5(Form3 form)
        {
            f3 = form;
            InitializeComponent();
        }

        int scores = 0;
        int foods = 0;
        int single = 0;
        int couple = 0;
        int triple = 0;
        int total = 0;
        int price_a = 250;
        int price_b = 450;
        int price_c = 600;
        bool character;

        public void score(int s,int f,bool c)
        {
            scores = s;
            foods = f;
            character = c;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(scores);
            label4.Text = Convert.ToString(foods);
            label6.Text = "0";
            label7.Text = "";
            if(scores >= price_c)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
            }
            else if(scores >= price_b)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = false;
            }
            else if(scores >= price_a)
            {
                checkBox3.Enabled = false;
                checkBox2.Enabled = false;
                checkBox1.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
            }
            this.TopMost = true;
            this.Refresh();
        }

        public void computer()
        {
            if (character)
            {
                System.Threading.Thread.Sleep(2000);
                f3.updateScore(scores, foods);
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                single = 1;
                total += price_a;
                label6.Text = total.ToString();
                if(total > scores)
                {
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.ForeColor = Color.White;
                }
            }
            else
            {
                label7.Text = "";
                single = 0;
                total -= price_a;
                if(total < 0)
                {
                    total = 0;
                }
                label6.Text = total.ToString();
                if (total > scores)
                {
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.ForeColor = Color.White;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                couple = 1;
                total += price_b;
                label6.Text = total.ToString();
                if (total > scores)
                {
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.ForeColor = Color.White;
                }
            }
            else
            {
                label7.Text = "";
                couple = 0;
                total -= price_b;
                if (total < 0)
                {
                    total = 0;
                }
                label6.Text = total.ToString();
                if (total > scores)
                {
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.ForeColor = Color.White;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                triple = 1;
                total += price_c;
                label6.Text = total.ToString();
                if (total > scores)
                {
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.ForeColor = Color.White;
                }
            }
            else
            {
                label7.Text = "";
                triple = 0;
                total -= price_c;
                if (total < 0)
                {
                    total = 0;
                }
                label6.Text = total.ToString();
                if (total > scores)
                {
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.ForeColor = Color.White;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(total <= scores)
            {
                this.Hide();
                scores -= total;
                foods += single + 2 * couple + 3 * triple;
                this.Hide();
                f3.updateScore(scores, foods);
                this.Dispose();
            }
            else
            {
                label7.Text = "分數不足，無法購買";
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            f3.updateScore(scores, foods);
            this.Dispose();
        }
    }
}
