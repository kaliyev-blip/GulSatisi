using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GulSatisi
{
    public partial class Form1 : Form
    {
        double toplam = 0;

        public Form1()
        {
            InitializeComponent();
            if (File.Exists("gul.png")) pictureBox1.Image = Image.FromFile("gul.png");
            if (File.Exists("dibcek.png")) pictureBox2.Image = Image.FromFile("dibcek.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Xanalar boş olmamalıdır!");
                return;
            }

            int count;
            double price;
            if (!int.TryParse(textBox2.Text, out count) ||
                !double.TryParse(textBox3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out price))
            {
                MessageBox.Show("Say və qiymət düzgün ədəd olmalıdır!");
                return;
            }

            if (count <= 0 || price <= 0)
            {
                MessageBox.Show("Mənfi və sıfır say və qiymət olmaz!");
                return;
            }

            double result = count * price;
            dataGridView1.Rows.Add(textBox1.Text, count.ToString(), price.ToString(), result.ToString("F2"));

            toplam += result;
            label4.Text = "Toplam gəlir:  " + toplam.ToString("F2");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıxış edilsinmi?", "Çıxış", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }
    }
}