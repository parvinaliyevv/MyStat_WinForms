using System;
using System.Windows.Forms;
using System.Drawing;

namespace homework
{
    public partial class StudentBox : UserControl
    {
        public static Label crystals = null;

        public static Image full = Properties.Resources.full;
        public static Image empty = Properties.Resources.crystal;


        public StudentBox(Student student)
        {
            InitializeComponent();

            this.label1.Text = student.ID.ToString();
            this.label2.Text = student.Fullname;
        }

        private void StudentBox_Load(object sender, EventArgs e)
        {
            this.label3.Text = DateTime.Now.ToShortDateString();

            pictureBox1.LoadAsync("https://cdn-icons-png.flaticon.com/512/924/924874.png");

            button1.BackgroundImage = empty;
            button2.BackgroundImage = empty;
            button3.BackgroundImage = empty;

            comboBox1.Items.Add('-');
            comboBox2.Items.Add('-');

            for (int i = 1; i < 13; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }

            comboBox1.SelectedIndexChanged -= comboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged -= comboBox_SelectedIndexChanged;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox_SelectedIndexChanged;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox cb)
            {
                int index = cb.SelectedIndex;
                cb.Items.Clear();
                cb.Items.Add(index);

                for (int i = 1; i < 13; i++)
                {
                    if (index == i) cb.Items.Add('-');
                    else cb.Items.Add(i);
                }

                cb.SelectedIndexChanged -= comboBox_SelectedIndexChanged;
                cb.SelectedIndex = 0;
                cb.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                var crystalCount = Convert.ToInt32(crystals.Text);
                int temp = default;

                if (button1.BackgroundImage == full) temp++;
                if (button2.BackgroundImage == full) temp++;
                if (button3.BackgroundImage == full) temp++;

                if (btn.Name == "button1" & crystalCount >= 1 - temp)
                {
                    if (temp == 0) crystalCount -= 1;
                    else crystalCount -= 1 - temp;

                    button1.BackgroundImage = full;
                    button2.BackgroundImage = empty;
                    button3.BackgroundImage = empty;
                }
                else if (btn.Name == "button2" & crystalCount >= 2 - temp)
                {
                    if (temp == 0) crystalCount -= 2;
                    else crystalCount -= 2 - temp;

                    button1.BackgroundImage = full;
                    button2.BackgroundImage = full;
                    button3.BackgroundImage = empty;
                }
                else if (btn.Name == "button3" & crystalCount >= 3 - temp)
                {
                    if (temp == 0) crystalCount -= 3;
                    else crystalCount -= 3 - temp;

                    button1.BackgroundImage = full;
                    button2.BackgroundImage = full;
                    button3.BackgroundImage = full;
                }
                else return;

                crystals.Text = crystalCount.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                var crystalCount = Convert.ToInt32(crystals.Text);

                if (button1.BackgroundImage == full) crystalCount++;
                if (button2.BackgroundImage == full) crystalCount++;
                if (button3.BackgroundImage == full) crystalCount++;

                button1.BackgroundImage = empty;
                button2.BackgroundImage = empty;
                button3.BackgroundImage = empty;

                crystals.Text = crystalCount.ToString();
            }
        }
    }
}
