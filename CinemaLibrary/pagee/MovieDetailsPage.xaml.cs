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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaLibrary.bd;

namespace CinemaLibrary.pagee
{
    /// <summary>
    /// Логика взаимодействия для MovieDetailsPage.xaml
    /// </summary>
    public partial class MovieDetailsPage : Page
    {
        public MovieDetailsPage(Movies movie)
        {
            InitializeComponent();
            DataContext = movie; // Установка контекста данных для страницы
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Check());
        }
    }
}
