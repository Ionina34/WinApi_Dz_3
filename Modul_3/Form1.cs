using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.ForeColor = Color.Red;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NameTextBox.TextChanged += TextChenged;
            LastNameTextBox.TextChanged += TextChenged;
            MailTextBox.TextChanged += TextChenged;
            PhoneTextBox.TextChanged += TextChenged;
        }
        private void TextChenged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text != "")
                text.BackColor = Color.White;
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (removeToolStripMenuItem.Checked == false)
            {
                removeToolStripMenuItem.Checked = true;
                editToolStripMenuItem.Checked = false;
                if (listBox.Items.Count != 0)
                {
                    if (listBox.SelectedItems != null)
                    {
                        for (int i = 0; i < listBox.SelectedItems.Count; i++)
                            listBox.Items.Remove(listBox.SelectedItems[i]);
                        removeToolStripMenuItem.Checked = false;
                    }
                }
            }
            else
                removeToolStripMenuItem.Checked = false;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string user;
            if (editToolStripMenuItem.Checked == false)
            {
                editToolStripMenuItem.Checked = true;
                removeToolStripMenuItem.Checked = false;
                if (listBox.Items.Count != 0)
                {
                    if (listBox.SelectedItems!= null)
                    {
                        for (int i = 0; i < listBox.SelectedItems.Count; i++)
                        {
                            user = listBox.SelectedItems[i].ToString();
                            string[] strok = user.Split(' ');
                            NameTextBox.Text = strok[1];
                            LastNameTextBox.Text = strok[2];
                            MailTextBox.Text = strok[3];
                            PhoneTextBox.Text = strok[4];
                            listBox.Items.Remove(listBox.SelectedItems[i]);
                            editToolStripMenuItem.Checked = false;
                        }
                    }
                }
            }
            else
                editToolStripMenuItem.Checked = false;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text Files (*.txt;*.xml)|*.txt;*.xml||";
            if (save.ShowDialog() == DialogResult.OK)
            {
                TextWriter writer = new StreamWriter(save.FileName);
                foreach (var item in listBox.Items)
                    writer.WriteLine(item.ToString());
                writer.Close();
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt;*.xml)|*.txt;*.xml|All files (*.*)|*.*||";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listBox.Items.AddRange(File.ReadAllLines(ofd.FileName, Encoding.UTF8));
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            if (NameTextBox.Text != "" && LastNameTextBox.Text != "" &&
                MailTextBox.Text != "" && PhoneTextBox.Text != "")
            {
                listBox.Items.Add($"Пользователь: {NameTextBox.Text} {LastNameTextBox.Text}" +
                    $" {MailTextBox.Text} {PhoneTextBox.Text}");

                NameTextBox.Text = "";
                LastNameTextBox.Text = "";
                MailTextBox.Text = "";
                PhoneTextBox.Text = "";

                LastNameTextBox.BackColor = Color.White;
                MailTextBox.BackColor = Color.White;
                PhoneTextBox.BackColor = Color.White;
            }
            else
            {
                if (NameTextBox.Text == "")
                    NameTextBox.BackColor = Color.FromArgb(255, 98, 90);
                if (LastNameTextBox.Text == "")
                    LastNameTextBox.BackColor = Color.FromArgb(255, 98, 90);
                if (MailTextBox.Text == "")
                    MailTextBox.BackColor = Color.FromArgb(255, 98, 90);
                if (PhoneTextBox.Text == "")
                    PhoneTextBox.BackColor = Color.FromArgb(255, 98, 90);

                MessageBox.Show("Не все поля зополнены!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
