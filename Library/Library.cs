using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    static class Library
    {

        public static List<Books> books = new List<Books>();
        public static void WriteOnFile()
        {
            // Clear the file before writing to it
            File.WriteAllText("file.txt", string.Empty);

            StreamWriter sw = new StreamWriter("file.txt", true);

            foreach (var book in books)
            {
                if (book.Type == "PaperBook")
                {
                    PaperBook pb = (PaperBook)book;
                    sw.WriteLine($"{pb.Title}${pb.Author}${pb.Category}${pb.Type}${pb.Isbn}${pb.NumOfPages}");
                }
                else if (book.Type == "AudioBook")
                {
                    AudioBook ab = (AudioBook)book;
                    sw.WriteLine($"{ab.Title}${ab.Author}${ab.Category}${ab.Type}${ab.Narrator}${ab.Duration}");
                }
                else if (book.Type == "E-Book")
                {
                    E_Book eb = (E_Book)book;
                    sw.WriteLine($"{eb.Title}${eb.Author}${eb.Category}${eb.Type}${eb.Format}${eb.FileSize}");
                }
            }
            sw.Close();
        }

        public static void ReadFromFile()
        {
            books.Clear();

            FileStream fs = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] data = line.Split('$');
                string title = data[0];
                string author = data[1];
                string category = data[2];
                string type = data[3];

                switch (type)
                {
                    case "PaperBook":
                        PaperBook paperBook = new PaperBook(title, author, category, Convert.ToInt32(data[4]), Convert.ToInt32(data[5]));
                        books.Add(paperBook);
                        break;
                    case "AudioBook":
                        AudioBook audioBook = new AudioBook(title, author, category, data[4], data[5]);
                        books.Add(audioBook);
                        break;
                    case "E-Book":
                        E_Book eBook = new E_Book(title, author, category, data[4], Convert.ToInt32(data[5]));
                        books.Add(eBook);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid book type found in file.");
                }
            }
            sr.Close();
            fs.Close();
        }


    }
}
