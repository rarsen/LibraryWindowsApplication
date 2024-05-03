using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class AudioBook : Books
    {
        private string _narrator, _duration;

        public AudioBook(string title, string author, string category, string narrator, string duration) :
            base(title, author, category, "AudioBook")
        {
            Narrator = narrator;
            Duration = duration;
        }

        public string Narrator
        {
            get { return _narrator; }
            set
            {
                if ((value.Length > 0) && (!String.IsNullOrEmpty(value.Trim())))
                {
                    _narrator = value.Trim();
                }
                else
                {
                    throw new Exception("The title can not be empty.");
                }
            }
        }
        public string Duration
        {
            get { return _duration; }
            set
            {
                if ((value.Length > 0) && (!String.IsNullOrEmpty(value.Trim())))
                {
                    _duration = value.Trim();
                }
                else
                {
                    throw new Exception("The duration can not be empty.");
                }
            }
        }
        public AudioBook(string data) : base("", "", "", "")
        {
            string[] splitedData = data.Split('$');
            Title = splitedData[0];
            Author = splitedData[1];
            Category = splitedData[2];
            Narrator = splitedData[3];
            Duration = splitedData[4];
        }
    }
}
