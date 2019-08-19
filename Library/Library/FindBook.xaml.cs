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

            using (LibraryDbEntites books = new LibraryDbEntites())
            {
                Book book = books.Books.FirstOrDefault(x => x.BookName == bookName);

                string result = string.Empty;

                if (book != null)
                {
                    result = $"Place in Library: {book.PlaceInLibrary}";
                }
                else
                {
                    result = "A book with that name does not exist!";
                }
                

                Result.Text = result;

            }
        }

        private void BookName_GotFocus(object sender, RoutedEventArgs e)
        {
            BookName.Text = "";
        }
    }
}
