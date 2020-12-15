using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HashCode2020
{
    class book
    {
        public static List<book> ListBooks = new List<book>();
        public static List<book> TopBooksList = new List<book>();

        public uint id { get; set; } // book ID
        public ushort Score { get; set; } // Score of Book

        public book(uint id, ushort score)
        {
            this.id = id;
            Score = score;
        }

        public static void createBookList(string ScoreLine)
        {
            string[] ScoreArry = ScoreLine.Split(' ');
            uint i = 0;
            foreach (string j in ScoreArry)
            {
                book b = new book(i, ushort.Parse(j));
                ListBooks.Add(b);
                i++;
            }
        }

        public static List<book> SelectTopBooksID(uint N)
        {
            List<book> OrderedListBooks = ListBooks.OrderByDescending(o => o.Score).ToList();
            ListBooks = OrderedListBooks;
            List<book> topbookslist = new List<book>();
            uint i = 0;
            foreach (book b in ListBooks)
            {
                topbookslist.Add(b);
                i++;
                if(i>=N)
                {
                    break;
                }
            }
            return topbookslist;

        }
    }
}
