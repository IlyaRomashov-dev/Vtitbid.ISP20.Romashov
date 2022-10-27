using System;
using System.IO;
using System.Reflection.PortableExecutable;

namespace Vtitbid.ISP20.Romashov.Console.ListReader
{
    class DataManager
    {
        public static int GetPages(string[] list, int linesOnPage)
        {
            if (list.Length % linesOnPage != 0)
            {
                int x = list.Length % linesOnPage;
                return ((list.Length - x) / linesOnPage) + 1;
            }
            else
            {
                return list.Length / linesOnPage;
            }
        }

        public static void NextPage(ref int page, List<string[]> book)
        {
            page++;
            ShowPage(page, book);
        }
        public static void PrevPage(ref int page, List<string[]> book)
        {
            page--;
            ShowPage(page, book);
        }
        public static void ShowPage(int page, List<string[]> book)
        {
            if (page >= 0 && page < book.Count)
            {
                System.Console.WriteLine($"Страница: {page + 1}/{book.Count}");
                foreach (var item in book[page])
                {
                    System.Console.WriteLine(item);
                }
            }
            else
            {
                System.Console.WriteLine($"Невозможно открыть страницу {page + 1} в книге содержащей {book.Count} страниц");
            }
        }
    }
}
