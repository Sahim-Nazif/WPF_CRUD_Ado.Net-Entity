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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CRUD_ADO.NET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WPFDBEntities db = new WPFDBEntities();
        public static DataGrid datagrid;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            MyMovies.ItemsSource = db.movies_table.ToList();

            datagrid = MyMovies;
        }

        private void addBtn(object sender, RoutedEventArgs e)
        {
            //this is reference to Add
            AddMovie addMovie = new AddMovie();

            addMovie.ShowDialog();

        }

        private void updateBtn(object sender, RoutedEventArgs e)
        {
            int Id= (MyMovies.SelectedItem as movies_table).Id;
            UpageMoviePage upageMovie = new UpageMoviePage(Id);
            upageMovie.ShowDialog();


        }

        private void deleteBtn(object sender, RoutedEventArgs e)
        {
            int Id = (MyMovies.SelectedItem as movies_table).Id;
            var deleteMovie = db.movies_table.Where(m => m.Id == Id).Single();

            db.movies_table.Remove(deleteMovie);
            db.SaveChanges();
            MyMovies.ItemsSource = db.movies_table.ToList();
           
        }
    }
}
