using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string authorName = null;
            string givenTo = null;
            var bookName = nameBox.Text.ToString();
            if (nameBox.ToString() != null)
            {
                authorName = authorBox.Text.ToString();
            }
            var placeInLibrary = placeBox.Text.ToString();
            if (givenBox.ToString() != null)
            {
                givenTo = givenBox.Text.ToString();
            }

            using (LibraryDbEntites books = new LibraryDbEntites())
            {
                Book book = new Book()
                {
                    AuthorName = authorName,
                    BookName = bookName,
                    PlaceInLibrary = placeInLibrary,
                    GivenTo = givenTo,
                };
                books.Books.Add(book);
                
                books.SaveChanges();
            }


            

        }
    }
}
