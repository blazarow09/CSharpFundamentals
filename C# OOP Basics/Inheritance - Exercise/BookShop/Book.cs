using System;

namespace BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string title, string author, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        protected string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        protected string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                var tokens = value.Split();
                if (char.IsDigit(tokens[0][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        protected virtual double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}\n" +
                $"Title: {this.Title}\n" +
                $"Author: {this.Author}\n" +
                $"Price: {this.Price:f2}";
        }
    }
}