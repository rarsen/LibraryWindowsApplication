using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class E_Book : Books
    {
        private string _format;
        private int _fileSize;

        public E_Book(string title, string author, string category, string format, int fileSize) :
            base(title, author, category, "E-Book")
        {
            Format = format;
            FileSize = fileSize;
        }
        public string Format
        {
            get { return _format; }
            set
            {
                if ((value.Length > 0) && (!String.IsNullOrEmpty(value.Trim())))
                {
                    _format = value;
                }
                else
                {
                    throw new Exception("The Format name can not be empty.");
                }
            }
        }
        public int FileSize
        {
            get { return _fileSize; }
            set
            {
                if (value > 0)
                {
                    _fileSize = value;
                }
                else
                {
                    throw new Exception("The file size can not be less than 1.");
                }
            }
        }
        public E_Book(string data) : base("", "", "", "")
        {
            string[] splitedData = data.Split('$');
            Title = splitedData[0];
            Author = splitedData[1];
            Category = splitedData[2];
            Format = splitedData[3];
            FileSize = Convert.ToInt32(splitedData[4]);

        }
    }
}
