using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBType.SelectedIndex = 0;
        }

        private void PaperBAdd_Click(object sender, EventArgs e)
        {
            string title = txtboxTitle.Text;
            string author = txtBoxAuthor.Text;
            string category = txtBoxCategory.Text;
            int Isbn = Convert.ToInt32(txtBoxISBN.Text);
            int NumOfPages = Convert.ToInt32(txtBoxPages.Text);
            PaperBook PB = new PaperBook(title, author, category, Isbn, NumOfPages);
            Library.books.Add(PB);
            Library.WriteOnFile();
            Library.ReadFromFile();
            MessageBox.Show("The new Paper Book has been added to the database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void E_BookAdd_Click(object sender, EventArgs e)
        {
            string title = txtboxTitle.Text;
            string author = txtBoxAuthor.Text;
            string category = txtBoxCategory.Text;
            string Format = txtboxFormat.Text;
            int FileSize = Convert.ToInt32(txtBoxFileSize.Text);
            E_Book EB = new E_Book(title, author, category, Format, FileSize);
            Library.books.Add(EB);
            Library.WriteOnFile();
            Library.ReadFromFile();
            MessageBox.Show("The new E-Book has been added to the database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AudiBoAdd_Click(object sender, EventArgs e)
        {
            string title = txtboxTitle.Text;
            string author = txtBoxAuthor.Text;
            string category = txtBoxCategory.Text;
            string Narrator = txtBoxNarrator.Text;
            string Duration = txtBoxDuration.Text;
            AudioBook EB = new AudioBook(title, author, category, Narrator, Duration);
            Library.books.Add(EB);
            Library.WriteOnFile();
            Library.ReadFromFile();
            MessageBox.Show("The new Audio Book has been added to the database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void comboBType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBType.SelectedItem.ToString() == "Paper Book")
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
            else if (comboBType.SelectedItem.ToString() == "E-Book")
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
            }
        }
    }
}
