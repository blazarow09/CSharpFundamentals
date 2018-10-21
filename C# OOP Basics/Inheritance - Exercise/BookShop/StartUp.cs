using System;

namespace BookShop
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var author = Console.ReadLine();
            var title = Console.ReadLine();
            var price = double.Parse(Console.ReadLine());

            try
            {
                var book = new Book(title, author, price);
                var goldenEditionBook = new GoldenEditionBook(title, author, price);

                Console.WriteLine(book);
                Console.WriteLine();
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}