using System;
using System.Collections.Generic;
using System.Text;

namespace HashCode2020
{
    class selected
    {
        public static List<selected> libList = new List<selected>();
        public uint idLib { get; set; } // Library ID
        public uint sNumOfBook { get; set; }

        public uint[] books;

        public static List<uint> uidBook = new List<uint>();
        public selected(uint idLib, uint sNumOfBooks)
        {
            this.idLib = idLib;
            this.sNumOfBook = sNumOfBooks;
            books = new uint[sNumOfBooks];
        }
    }
}
