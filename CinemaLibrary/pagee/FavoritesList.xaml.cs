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
using CinemaLibrary.bd;

namespace CinemaLibrary.pagee
{
    /// <summary>
    /// Логика взаимодействия для FavoritesList.xaml
    /// </summary>
    public partial class FavoritesList : Page
    {
        private readonly Entities entities = new Entities();
        private readonly Users currentUser;
        public FavoritesList(CinemaLibrary.bd.Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadFavorites();
        }
        private void LoadFavorites()
        {
            var favoriteMovies = entities.Lists_Movies
                .Where(l => l.UserID == currentUser.UserID && l.ListType == "Избранное")
                .Select(l => l.Movies)
                .ToList();

            FavoritesListBox.Items.Clear();

            foreach (var movie in favoriteMovies)
            {
                var item = new ListBoxItem
                {
                    Content = movie.Title,
                    Tag = movie // Для хранения объекта фильма
                };
                FavoritesListBox.Items.Add(item);
            }
        }

        private void RemoveFromFavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ListBoxItem)FavoritesListBox.SelectedItem;

            if (selectedItem != null)
            {
                var selectedMovie = (CinemaLibrary.bd.Movies)selectedItem.Tag;

                var favoriteMovie = entities.Lists_Movies.FirstOrDefault(l => l.UserID == currentUser.UserID && l.MovieID == selectedMovie.MovieID && l.ListType == "Избранное");

                if (favoriteMovie != null)
                {
                    entities.Lists_Movies.Remove(favoriteMovie);
                    entities.SaveChanges();

                    FavoritesListBox.Items.Remove(selectedItem);

                    MessageBox.Show("Movie removed from favorites.");
                }
            }
            else
            {
                MessageBox.Show("Please select a movie to remove from favorites.");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Check());
        }
    }
}
