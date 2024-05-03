using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form3 : Form
    {
        int CurrentBookIndex = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txtBoxTitle.Enabled = false;
            txtBoxAuthor.Enabled = false;
            txtBoxChange1.Enabled = false;
            txtBoxCategory.Enabled = false;
            txtBoxType.Enabled = false;
            txtBoxChange2.Enabled = false;
            Library.ReadFromFile();

            lbltotalofbooks.Text = Library.books.Count.ToString();
            if (Library.books.Count > 0)
            {
                lblCurrentBook.Text = (CurrentBookIndex + 1).ToString();
                ShowData();
            }

        }
        private void ShowData()
        {
            txtBoxTitle.Text = Library.books[CurrentBookIndex].Title;
            txtBoxAuthor.Text = Library.books[CurrentBookIndex].Author;
            txtBoxCategory.Text = Library.books[CurrentBookIndex].Category;
            txtBoxType.Text = Library.books[CurrentBookIndex].Type;
            if (Library.books[CurrentBookIndex].Type == "PaperBook")
            {
                PaperBook pb = (PaperBook)Library.books[CurrentBookIndex];
                lblChange1.Text = "ISBN:";
                txtBoxChange1.Text = pb.Isbn.ToString();
                lblChange2.Text = "Pages:";
                txtBoxChange2.Text = pb.NumOfPages.ToString();
            }
            else if (Library.books[CurrentBookIndex].Type == "AudioBook")
            {
                AudioBook au = (AudioBook)Library.books[CurrentBookIndex];
                lblChange1.Text = "Narrator:";
                txtBoxChange1.Text = au.Narrator;
                lblChange2.Text = "Duration:";
                txtBoxChange2.Text = au.Duration;
            }
            else if (Library.books[CurrentBookIndex].Type == "E-Book")
            {
                E_Book eb = (E_Book)Library.books[CurrentBookIndex];
                lblChange1.Text = "Format:";
                txtBoxChange1.Text = eb.Format;
                lblChange2.Text = "File Size:";
                txtBoxChange2.Text = eb.FileSize.ToString();
            }
        }


        private void UpdateNavigationButtons()
        {
            if (CurrentBookIndex == 0)
            {
                previousbutt.Enabled = false;
            }
            else
            {
                previousbutt.Enabled = true;
            }

            if (CurrentBookIndex == Library.books.Count - 1)
            {
                nextbut.Enabled = false;
            }
            else
            {
                nextbut.Enabled = true;
            }
        }
        private void previousbutt_Click(object sender, EventArgs e)
        {
            if (CurrentBookIndex > 0)
            {
                CurrentBookIndex--;
                ShowData();
                UpdateNavigationButtons();
                UpdateCurrentBookLabel();
            }
        }

        private void nextbut_Click(object sender, EventArgs e)
        {
            if (CurrentBookIndex < Library.books.Count - 1)
            {
                CurrentBookIndex++;
                ShowData();
                UpdateNavigationButtons();
                UpdateCurrentBookLabel();
            }
        }

        private void UpdateCurrentBookLabel()
        {
            lblCurrentBook.Text = (CurrentBookIndex + 1).ToString();
        }

        private void deletebutt_Click(object sender, EventArgs e)
        {
            FileStream fs1 = new FileStream("file.txt", FileMode.Open, FileAccess.Read);
            FileStream fs2 = new FileStream("temp.txt", FileMode.Create, FileAccess.Write);
            StreamReader sr = new StreamReader(fs1);
            StreamWriter sw = new StreamWriter(fs2);

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] data = s.Split('$');
                string title = data[0];
                string author = data[1];
                string category = data[2];
                string type = data[3];

                if (!(Library.books[CurrentBookIndex].Title == title &&
                        Library.books[CurrentBookIndex].Author == author &&
                        Library.books[CurrentBookIndex].Category == category &&
                        Library.books[CurrentBookIndex].Type == type))
                {
                    sw.WriteLine(s);
                }
            }
            sw.Close();
            sr.Close();
            fs2.Close();
            fs1.Close();

            // Replace the main file with the contents of the temporary file
            File.Delete("file.txt");
            File.Move("temp.txt", "file.txt");

            Library.ReadFromFile();
            lbltotalofbooks.Text = Library.books.Count.ToString();
            if (Library.books.Count > 0)
            {
                if (CurrentBookIndex >= Library.books.Count)
                {
                    CurrentBookIndex = Library.books.Count - 1;
                }
                lblCurrentBook.Text = (CurrentBookIndex + 1).ToString();
                ShowData();
            }
            else
            {
                txtBoxTitle.Clear();
                txtBoxAuthor.Clear();
                txtBoxCategory.Clear();
                txtBoxType.Clear();
                txtBoxChange1.Clear();
                txtBoxChange2.Clear();
                lblCurrentBook.Text = "0";
            }
            MessageBox.Show("The book has been deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool isEditing = false;

        private void editbutt_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                editbutt.Text = "Apply";
                EnableTextBoxes();
            }
            else
            {
                editbutt.Text = "Edit";
                DisableTextBoxes();
                UpdateData();
            }
            isEditing = !isEditing;
        }

        private void EnableTextBoxes()
        {
            txtBoxTitle.Enabled = true;
            txtBoxAuthor.Enabled = true;
            txtBoxCategory.Enabled = true;
            txtBoxChange1.Enabled = true;
            txtBoxChange2.Enabled = true;
        }

        private void DisableTextBoxes()
        {
            txtBoxTitle.Enabled = false;
            txtBoxAuthor.Enabled = false;
            txtBoxCategory.Enabled = false;
            txtBoxChange1.Enabled = false;
            txtBoxChange2.Enabled = false;
        }

        private void UpdateData()
        {
            // Update the data with the new values
            Library.books[CurrentBookIndex].Title = txtBoxTitle.Text;
            Library.books[CurrentBookIndex].Author = txtBoxAuthor.Text;
            Library.books[CurrentBookIndex].Category = txtBoxCategory.Text;

            // Check the type of the book to update the specific properties
            if (Library.books[CurrentBookIndex].Type == "PaperBook")
            {
                PaperBook pb = (PaperBook)Library.books[CurrentBookIndex];
                pb.Isbn = Convert.ToInt32(txtBoxChange1.Text);
                pb.NumOfPages = Convert.ToInt32(txtBoxChange2.Text);
            }
            else if (Library.books[CurrentBookIndex].Type == "AudioBook")
            {
                AudioBook ab = (AudioBook)Library.books[CurrentBookIndex];
                ab.Narrator = txtBoxChange1.Text;
                ab.Duration = txtBoxChange2.Text;
            }
            else if (Library.books[CurrentBookIndex].Type == "E-Book")
            {
                E_Book eb = (E_Book)Library.books[CurrentBookIndex];
                eb.Format = txtBoxChange1.Text;
                eb.FileSize = Convert.ToInt32(txtBoxChange2.Text);
            }

            // Update text boxes with the new data
            ShowData();

            // Save changes back to the file
            Library.WriteOnFile();
            MessageBox.Show("The changes has been applied!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
