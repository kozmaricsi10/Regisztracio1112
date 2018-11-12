using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hobbies.Items.Add("Uszas");
            hobbies.Items.Add("Football");
            hobbies.Items.Add("Basketball");

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (!nameTextBox.Text.Equals("") && hobbies.SelectedItem != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter("adat.txt");
                    sw.WriteLine(nameTextBox.Text);
                    sw.WriteLine(dateTimePicker.Text);

                    if (radioButtonMale.Checked = true)
                    {
                        sw.WriteLine("Ferfi");
                    }
                    else if (radioButtonFemale.Checked = true)
                    {
                        sw.WriteLine("No");
                    }
                    else
                    {
                        sw.WriteLine("Semleges");
                    }

                    sw.WriteLine(hobbies.SelectedItem);

                    MessageBox.Show("Sikeres adatfelvétel.");

                    sw.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Nem jól töltötted ki az űrlapot.");
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string newHobby = this.newHobby.Text;
            hobbies.Items.Add(newHobby);
            System.Windows.Forms.MessageBox.Show(newHobby);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

            try
            {
                StreamReader sr = new StreamReader("adat.txt");

                nameTextBox.Text = sr.ReadLine();

                sr.ReadLine();

                String nem = sr.ReadLine();

                if (nem.Equals("Ferfi")){
                    radioButtonMale.Checked = true;
                }else if (nem.Equals("No"))
                {
                    radioButtonFemale.Checked = true;
                }

                hobbies.Items.Add(sr.ReadLine());

                sr.Close();
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
