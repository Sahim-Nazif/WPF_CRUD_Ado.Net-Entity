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

namespace WPF_CRUD_ADO.NET
{
    /// <summary>
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddMovie : Window
    {
        WPFDBEntities db = new WPFDBEntities();
        public AddMovie()
        {
            InitializeComponent();
        }

        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            movies_table movies = new movies_table()
            {
                Title = txtTitle.Text,
                Release_date = txtDate.SelectedDate,
                Movie_genre = genreCombox.Text
            };
            db.movies_table.Add(movies);
            db.SaveChanges();
            MainWindow.datagrid.ItemsSource = db.movies_table.ToList();
            this.Hide();
            

        }
    }
}
