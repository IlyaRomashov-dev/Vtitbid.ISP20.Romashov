using System;
using System.IO;
using static System.Console;

namespace Vtitbid.ISP20.Romashov.Console.ListReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = new FileInfo("C:\\Users\\student\\Documents\\Vtitbid.ISP20.Romashov\\Vtitbid.ISP20.Romashov.Console.ListReader\\Source\\Source.txt");
            string[] array = File.ReadAllLines(file.FullName);
            int numberOfLines;
            do
            {
                Write("Введите количество строк на странице: ");
            } while (!Int32.TryParse(ReadLine(), out numberOfLines));
            int numberOfPages = DataManager.GetPages(array, numberOfLines);
            var book = new List<string[]>();
            int k = 0;
            for(int i = 0; i < numberOfPages; i++)
            {
                string[] newPage = new string[0];
                for(int j = 0; j < numberOfLines; j++)
                {
                    try
                    {
                        Array.Resize(ref newPage, j + 1);
                        newPage[j] = array[k++];
                    }
                    catch
                    {
                        break;
                    }
                }
                book.Add(newPage);
            }
            string input;
            int page;
            int actualPage = 0;
            DataManager.ShowPage(0,book);
            do
            {                
                Write("Введите команду: ");
                input = ReadLine();
                if(Int32.TryParse(input,out page))
                {
                    Clear();
                    DataManager.ShowPage(page - 1,book);
                }
                else if(input.ToUpper() == "NEXT")
                {
                    Clear();
                    DataManager.NextPage(ref actualPage,book);
                }
                else if (input.ToUpper() == "PREV")
                {
                    Clear();
                    DataManager.PrevPage(ref actualPage, book);
                }
                if(page > 0 && page < book.Count)
                {
                    actualPage = page - 1;
                }
            } while (input.ToUpper() != "STOP");
           
        }
    }
}