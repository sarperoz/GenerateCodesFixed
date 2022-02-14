using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateCodes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> passList = new List<string>();
        public void RandomPassword()
        {
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                const string chars = "ACDEFGHKLMNPRTXYZ234579";
                StringBuilder sb = new StringBuilder();

                for (int f = 0; f < 8; f++)
                {
                    int index = rnd.Next(chars.Length);
                    sb.Append(chars[index]);

                }
                passList.Add(sb.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomPassword();

            IEnumerable<string> uniqueCodes = passList.Distinct();
            foreach (string pass in uniqueCodes)
            {
                listBox1.Items.Add(pass);
            }

            MessageBox.Show("1000 Adet Kod Generate Edilmiştir.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string chosenCode = textBox1.Text;
            int counter = 0;
            for (int i = 0; i < passList.Count; i++)
            {

                if (chosenCode == passList[i])
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                MessageBox.Show("Kodunuz eşsiz değildir.");
            }
            if (counter == 1)
            {
                MessageBox.Show("Kodunuz eşsizdir.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = listBox1.GetItemText(listBox1.SelectedItem);
            textBox1.Text = select;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("İlk olarak Generate Codes butonu ile kodları oluşturun");
        }
    }
}
