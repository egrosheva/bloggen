using System;
using System.Collections.Generic;

namespace Bloggen
{
    class Program
    {
        static void PrintMenu()
        {
            //Print menu
            Console.Clear();
            Console.WriteLine("1. Skriv ut blogginlängg");
            Console.WriteLine("2. Skriv nytt inlägg i bloggen");
            Console.WriteLine("3. Sök inlägg bloggen");
            Console.WriteLine("4. Avsluta programmet");
        }
        static void PrintBlog(List<string[]> blogg)
        {
            Console.WriteLine("blogg.Count="+ blogg.Count);
            for (int i = 0; i < blogg.Count; i++)
            {
                //Print Title index +1, print Text index +1 and corresponding blogg entry
                Console.WriteLine("Title:" + (i + 1) + ":" + blogg[i][0]);
                Console.WriteLine("Date:" + (i + 1) + ":" + blogg[i][1]);
                Console.WriteLine("Text:" + (i + 1) + ":" + blogg[i][2]);

            }
            Console.WriteLine("Press a key to continue.");
            Console.ReadLine();

        }
        static void SearchBlogg(List<string[]> blogg)
        {
            //SearchElement variable used for searching a title or a text.
            string searchElement;
            //is Found variable becomes true when searchelement is found in blog
            bool isFound = false;
            Console.WriteLine("Search element:");
            searchElement = Console.ReadLine();
            for (int i = 0; i < blogg.Count; i++)
            {
                // Search all Blog if Title or Text match searchElement
                if ((searchElement == blogg[i][0]) || (searchElement == blogg[i][1]))
                {
                    isFound = true;
                }

            }
            if (isFound == true)
            {
                Console.WriteLine("Success, " + searchElement + "was found!");
            }
            else
            {
                Console.WriteLine("Fail, " + searchElement + "was not found!");
            }
            Console.WriteLine("Pres a key to continue.");
            Console.ReadLine();

        }
        static void AddBlogEntry(List<string[]> blogg)
        {
            //bloggElement variable used for adding new entry to blogg list
            string[] bloggElement = new string[3];
            DateTime bloggDate = DateTime.Now;
            Console.WriteLine("Blogg title:");
            bloggElement[0] = Console.ReadLine();
            bloggElement[1] = bloggDate.ToString();
            Console.WriteLine("Blogg text:");
            bloggElement[2] = Console.ReadLine();
            blogg.Add(bloggElement);
        }
        static void Main(string[] args)
        {
            //blogg variable list af arrays:[[Title1, Text1], [Title2, Text2],...]
            List<string[]> blogg = new List<string[]> { };
            //menuChoice variable used for storing the menu entry
            int menuChoice;
            //programRunning set to false when program finished
            bool programRunning = true;
            while (programRunning == true)
            {
                // call PrintMenu method
                PrintMenu();
                //read menuChoice with TryParse
                Int32.TryParse(Console.ReadLine(), out menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        //call PrintBlog method
                        PrintBlog(blogg);
                        break;
                    case 2:
                        // add new entry to blog
                        AddBlogEntry(blogg);
                        break;
                    case 3:
                        //call SearchBlog method
                        SearchBlogg(blogg);
                        break;
                    case 4:
                        //Exit
                        programRunning = false;
                        break;
                    default:
                        Console.WriteLine("Wrongchoice! Enter a number from 1 to 4");
                        Console.ReadLine();
                        break;

                }

            }
        }
    }
}