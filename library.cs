using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HashCode2020
{
    class library
    {
        public uint id { get; set; } // Library ID
        public uint N { get; set; } // the number of books in library
        public uint T { get; set; } // the number of days it takes to finish the library signup process for library
        public  uint M { get; set; } // the number of books that can be shipped from library to the scanning facility per day, once the library is signed up.

        public static List<library> libList = new List<library>();

        public uint[] books;
        public uint score { get; set; }


        public library(uint ID, uint NumberOfBooks, uint NumberOfDays, uint NumberOfBooksPerDay)
        {
            N = NumberOfBooks;
            T = NumberOfDays;
            M = NumberOfBooksPerDay;
            id = ID;
            score = 0;
        }

        public void fillBooks(string listBooks)
        {
            books = new uint[N];
            string[] strings = listBooks.Split(' ');
            books = Array.ConvertAll(strings, s => uint.Parse(s));
        }

        public void CalculScore ()
        {
            foreach(book b in book.TopBooksList)
            {
                if (Array.Exists(books, e => e==b.id))
                {
                    double X = b.Score * ((Program.avgSignDays / (T * 2)) * ((N / Program.avgNumBooks) + (M / Program.avgScanBooks)));
                    score += Convert.ToUInt32(X);
                }
            }
        }

        public static void OrderLibList()
        {
            foreach (library L in libList)
            {
                L.CalculScore();
            }

            List<library> OrderedListLib = libList.OrderByDescending(o => o.score).ToList();
            libList = OrderedListLib;
        }

        public static void unnaturalSelection()
        {
            uint RemainingDays = Program.numDays;

            foreach (library L in libList)
            {
                if (RemainingDays == 0) break;
                if (RemainingDays < L.T) continue;
                RemainingDays -= L.T;

                uint numberOfBooks = L.M * RemainingDays;
                if (numberOfBooks > L.N) numberOfBooks = L.N;

                selected SelectedLib = new selected(L.id, numberOfBooks);
                uint i = 0;
                uint idb;
                    foreach (book b in book.ListBooks)
                    {
                        idb = b.id;
                        if (i >= numberOfBooks) break;

                        idb = b.id;
                        if (Array.Exists(L.books, e => e == idb) && !selected.uidBook.Contains(idb))
                        {
                            SelectedLib.books[i] = idb;
                            selected.uidBook.Add(idb);
                            i++;
                        }
                    }

                selected.libList.Add(SelectedLib);

            }



        }


    }
}
