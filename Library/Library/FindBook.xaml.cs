using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for FindBook.xaml
    /// </summary>
    public partial class FindBook : Window
    {
        public FindBook()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bookName = BookName.Text.ToString();

            using (LibraryDbEntities books = new LibraryDbEntities())
            {
                Table book = books.Tables.FirstOrDefault(x => x.BookName == bookName);

                string result = string.Empty;

                if (book != null)
                {
                    if (book.GivenTo != "")
                    {
                        result = $"Place in Library: {book.PlaceInLibrary}"
                            + Environment.NewLine +
                            $"Given to: {book.GivenTo}";
                        TakeBack.Visibility = Visibility.Visible; 
                        TakeBack.Content = "Return the book to the library";
                    }
                    else
                    {
                        result = $"Place in Library: {book.PlaceInLibrary}";
                        GiveTo.Text = "Give the book to";
                        GiveButton.Visibility = Visibility.Visible;
                        GiveButton.Content = "Give";
                    }                    
                }
                else
                {
                    result = "A book with that name does not exist!";
                }

                Result.Text = result;
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(sender, e);
            }
        }

        private void BookName_GotFocus(object sender, RoutedEventArgs e)
        {
            BookName.Text = "";
        }
        private void GiveTo_GotFocus(object sender, RoutedEventArgs e)
        {
            GiveTo.Text = string.Empty;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string bookName = BookName.Text.ToString();
            using (LibraryDbEntities books = new LibraryDbEntities())
            {
                Table book = books.Tables.FirstOrDefault(x => x.BookName == bookName);

                string giveTo = GiveTo.Text.ToString();

                book.GivenTo = giveTo;

                books.SaveChanges();
                GiveTo.Text = string.Empty;
                Result.Text = $"Place in Library: {book.PlaceInLibrary}"
                            + Environment.NewLine +
                            $"Given to: {book.GivenTo}";
                GiveButton.Content = string.Empty;
            }
        }

        private void TakeBack_Click(object sender, RoutedEventArgs e)
        {
            string bookName = BookName.Text.ToString();
            using (LibraryDbEntities books = new LibraryDbEntities())
            {
                Table book = books.Tables.FirstOrDefault(x => x.BookName == bookName);

                TakeBack.Content = "Return the book to the library";
                book.GivenTo = "";
                books.SaveChanges();
                Result.Text = $"Place in Library: {book.PlaceInLibrary}";
            }
        }
    }
}
