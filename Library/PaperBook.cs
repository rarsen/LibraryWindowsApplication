using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class PaperBook : Books
    {
        private int _isbn, _numOfPages;

        public PaperBook(string title, string author, string category, int ISBN, int numOfPages) :
            base(title, author, category, "PaperBook")
        {
            Isbn = ISBN;
            NumOfPages = numOfPages;
        }
        public int Isbn
        {
            get { return _isbn; }
            set
            {
                if (value > 0)
                {
                    _isbn = value;
                }
                else
                {
                    throw new Exception("The ISBN can not be less than 1.");
                }
            }
        }
        public int NumOfPages
        {
            get { return _numOfPages; }
            set
            {
                if (value > 0)
                {
                    _numOfPages = value;
                }
                else
                {
                    throw new Exception("The number of pages can not be less than 1.");
                }
            }
        }

        public PaperBook(string data) : base("", "", "", "")
        {
            string[] splitedData = data.Split('$');
            Title = splitedData[0];
            Author = splitedData[1];
            Category = splitedData[2];
            Isbn = Convert.ToInt32(splitedData[3]);
            NumOfPages = Convert.ToInt32(splitedData[4]);

        }
    }
}
