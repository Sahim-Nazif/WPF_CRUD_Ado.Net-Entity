﻿using System;
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
    /// Interaction logic for UpageMoviePage.xaml
    /// </summary>
    public partial class UpageMoviePage : Window
    {
        WPFDBEntities db = new WPFDBEntities();

        int Id;
        public UpageMoviePage(int movieID)
        {
            InitializeComponent();
            Id = movieID;

        }

        private void btnUpdateMovie_Click(object sender, RoutedEventArgs e)
        {
            
            movies_table updateMovie = (from m in db.movies_table
                                        where m.Id == Id
                                        select m).Single();

            

            updateMovie.Title = txtTitle.Text;
            updateMovie.Release_date = txtDate.SelectedDate;
            updateMovie.Movie_genre = genreCombox.Text;
            db.SaveChanges();
            MainWindow.datagrid.ItemsSource = db.movies_table.ToList();
            this.Hide();

        }
    }
}
