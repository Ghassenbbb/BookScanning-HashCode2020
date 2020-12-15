using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode2020
{
    class Program
    {
        public static string InputFilePath, filename;

        public static uint numBooks, numLib, numDays;

        public static uint avgNumBooks, avgSignDays, avgScanBooks, avgTopBooks, avgLibNum; // Averge per library


        static void Main(string[] args)
        {

            /* Selection of FilePath */
            string val;
            Console.WriteLine(" # Problem solution (Book scanning) - Online Qualication Round of Hash Code 2020 #");
            Console.WriteLine(" --- By B. Ghassen ---");
            Console.WriteLine("");
            Console.WriteLine(" Choose an input file : ");
            Console.WriteLine("     1. a_example.txt");
            Console.WriteLine("     2. b_read_on.txt");
            Console.WriteLine("     3. c_incunabula.txt");
            Console.WriteLine("     4. d_tough_choices.txt");
            Console.WriteLine("     5. e_so_many_books.txt");
            Console.WriteLine("     6. f_libraries_of_the_world.txt");
            Console.Write(" Enter integer (1-6) : ");
            val = Console.ReadLine();
            int SelectFilePath = Convert.ToInt32(val);
            switch (SelectFilePath)
            {
                case 1:
                    filename = "a_example";
                    break;
                case 2:
                    filename = "b_read_on";
                    break;
                case 3:
                    filename = "c_incunabula";
                    break;
                case 4:
                    filename = "d_tough_choices";
                    break;
                case 5:
                    filename = "e_so_many_books";
                    break;
                case 6:
                    filename = "f_libraries_of_the_world";
                    break;
            }

            InputFilePath = @"..\..\..\Resources\inputFiles\"+filename+".txt";


            if (!File.Exists(InputFilePath))
            {
                return;
            }
            /* End Selection of FilePath */
            Console.Clear();



            /* Library List Creation */
            using (StreamReader file = new StreamReader(InputFilePath))
            {
                string[] lnArray;
                // Line 1 :
                lnArray = file.ReadLine().Split(' ');
                numBooks = uint.Parse(lnArray[0]);
                numLib = uint.Parse(lnArray[1]);
                numDays = uint.Parse(lnArray[2]);

                ulong sumNumBooks = 0;
                ulong sumSignDays = 0;
                ulong sumScanBooks = 0;
                avgTopBooks = 0;

                //line 2 :
                string ln = file.ReadLine();
                book.createBookList(ln);
                ln = "";

                // Library lines
                for (uint i=0; i<numLib; i++)
                {
                    string libinfo = file.ReadLine();
                    lnArray = libinfo.Split(' ');

                    uint N = uint.Parse(lnArray[0]);
                    sumNumBooks += N;

                    uint D = uint.Parse(lnArray[1]);
                    sumSignDays += D;

                    uint M = uint.Parse(lnArray[2]);
                    sumScanBooks += M;

                    library lib = new library(i, N, D, M);

                    string bookscollection = file.ReadLine();
                    lib.fillBooks(bookscollection);

                    library.libList.Add(lib);
                }
                file.Close();

                // Average Calculation
                avgNumBooks = Convert.ToUInt32(sumNumBooks / numLib);
                avgScanBooks = Convert.ToUInt32(sumScanBooks / numLib);
                avgSignDays = Convert.ToUInt32(sumSignDays / numLib);
                avgLibNum = Convert.ToUInt32(numDays / avgSignDays);
                avgTopBooks = avgScanBooks * avgSignDays * (numDays / 2);
                if (avgTopBooks > numBooks) avgTopBooks = numBooks;

                //top books by average number and order books list
                book.TopBooksList = book.SelectTopBooksID(avgTopBooks);


            }
            /* End List Creation */



            Console.WriteLine($"INPUT FILE has {numBooks} Books, {numLib} Libraries, {numDays} Days.");
            Console.WriteLine($"AVG : {avgNumBooks} is avgNumBooks, {avgSignDays} is avgSignDays, {avgScanBooks} is avgScanBooks, {avgTopBooks} is avgTopBooks");
            Console.WriteLine($"Number of library objects in the libraries list : {library.libList.Count}");
            Console.WriteLine($"Number of book objects in the books list : {book.ListBooks.Count}");

            library.OrderLibList();

            library.unnaturalSelection();

            string datetime = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string outputPath = @"..\..\..\Resources\outputFiles\Solution__" + filename+"__"+datetime+".txt";

            StreamWriter sw = new StreamWriter(outputPath);
            sw.WriteLine(selected.libList.Count);

            foreach(selected S in selected.libList)
            {
                sw.WriteLine(S.idLib.ToString()+" "+S.sNumOfBook.ToString());
                sw.WriteLine(string.Join(" ", S.books));
            }

            sw.Close();

            Console.WriteLine(filename+" Solution File Created !");

        }
    }
}
