using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Books
    {
        private string _title, _author, _category, _type;

        public Books(string title, string author, string category, string type)
        {
            Title = title;
            Author = author;
            Category = category;
            _type = type;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if ((value.Length > 0) && (!String.IsNullOrEmpty(value.Trim())))
                {
                    _title = value.Trim();
                }
                else
                {
                    throw new Exception("The title can not be empty.");
                }
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                if ((value.Length > 0) && (!String.IsNullOrEmpty(value.Trim())))
                {
                    _author = value.Trim();
                }
                else
                {
                    throw new Exception("The author name can not be empty.");
                }
            }
        }
        public string Category
        {
            get { return _category; }
            set
            {
                if ((value.Length > 0) && (!String.IsNullOrEmpty(value.Trim())))
                {
                    _category = value.Trim();
                }
                else
                {
                    throw new Exception("The category name can not be empty.");
                }
            }
        }
        public string Type
        {
            get { return _type; }
        }
    }
}
