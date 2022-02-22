using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible) return;

            textBox1.Text = label4.Text;
            label4.Visible = false;
            textBox1.Visible = true;
            button4.Visible = true;
            button1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text;
            textBox1.Text = string.Empty;
            label4.Visible = true;
            textBox1.Visible = false;
            button2.Visible = true;
            button4.Visible = false;
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            label4.Visible = true;
            textBox1.Visible = false;
            button2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StudentBox.crystals = this.label11;
            var students = new List<Student>();

            students.Add(new Student("Aliyev Parvin Vilayat"));
            students.Add(new Student("Bayramov Rustam Bayram"));
            students.Add(new Student("Aliyeva Shabnam Ali"));
            students.Add(new Student("Ibrahimov Camil Mazahir"));
            students.Add(new Student("Musali Murad Taleh"));
            students.Add(new Student("Mustafazade Ramazan Vuqar"));
            students.Add(new Student("Valiyeva Zohra Alim"));

            int startHeight = 195;

            foreach (var item in students)
            {
                Controls.Add(new StudentBox(item) { Location = new Point(1, startHeight) });
                startHeight += 70;
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            foreach (var studentBox in Controls)
            {
                if (studentBox is StudentBox sb)
                {
                    foreach (var components in sb.Controls)
                    {
                        if (components is RadioButton rb)
                        {
                            if (rb.Name == "radioButton1") rb.Checked = true;
                        }
                    }
                }
            }
        }
    }
}
