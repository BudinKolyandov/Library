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
            string authorName = string.Empty;
            string givenTo = string.Empty;
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

            using (LibraryDbEntities books = new LibraryDbEntities())
            {


                if (bookName == "" || placeInLibrary == "")
                {
                    MessageBox.Show("You have to type the name of the book and it's place in the library", "Error", MessageBoxButton.OK);
                    InitializeComponent();
                }
        
                    
                else
                {
                    if (bookName.Length > 150)
                    {
                        MessageBox.Show("The name of the book can not be more than 150 characters", "Error", MessageBoxButton.OK);
                        InitializeComponent();
                    }
                    else if (authorName.Length > 100)
                    {
                        MessageBox.Show("The name of the author can not be more than 100 characters", "Error", MessageBoxButton.OK);
                        InitializeComponent();
                    }
                    else if (placeInLibrary.Length > 100)
                    {
                        MessageBox.Show("The place in the library can not be more than 100 characters", "Error", MessageBoxButton.OK);
                        InitializeComponent();
                    }
                    else if (givenTo.Length > 100)
                    {
                        MessageBox.Show("The name of the person that the books is given to can not be more than 100 characters", "Error", MessageBoxButton.OK);
                        InitializeComponent();
                    }
                    else
                    {
                        Table book = new Table()
                        {
                            AuthorName = authorName,
                            BookName = bookName,
                            PlaceInLibrary = placeInLibrary,
                            GivenTo = givenTo,
                        };
                        books.Tables.Add(book);

                        books.SaveChanges();
                    }
                    
                    
                }                
            }
            nameBox.Text = string.Empty;
            authorBox.Text = string.Empty;
            placeBox.Text = string.Empty;
            givenBox.Text = string.Empty;

        }
    }
}
