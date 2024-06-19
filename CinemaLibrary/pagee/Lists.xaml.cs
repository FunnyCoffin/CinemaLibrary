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
    /// Логика взаимодействия для Lists.xaml
    /// </summary>
    public partial class Lists : Page
    {
        private Users currentUser;
        private Entities entities = new Entities();
        public Lists(CinemaLibrary.bd.Users user)
        {
            InitializeComponent();
            currentUser = user;

            // Загрузка списка всех фильмов при создании страницы
            LoadMovies();
        }
        private void LoadMovies()
        {
            // Получаем список всех фильмов из базы данных
            var allMovies = entities.Movies.ToList();

            // Очищаем ListBox перед добавлением новых элементов
            MoviesListBox.Items.Clear();

            // Добавляем каждый фильм в ListBox
            foreach (var movie in allMovies)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = movie.Title;
                item.Tag = movie; // Для хранения объекта фильма
                MoviesListBox.Items.Add(item);
            }
        }

        private void AddToFavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный элемент из ListBox
            ListBoxItem selectedItem = (ListBoxItem)MoviesListBox.SelectedItem;

            if (selectedItem != null)
            {
                // Получаем объект фильма из Tag
                var selectedMovie = (Movies)selectedItem.Tag;

                // Проверяем, существует ли фильм в списке избранных для текущего пользователя
                var existingFavorite = entities.Lists_Movies.FirstOrDefault(l => l.MovieID == selectedMovie.MovieID && l.ListType == "Избранное" && l.UserID == currentUser.UserID);

                if (existingFavorite == null)
                {
                    // Если фильм еще не добавлен в избранное, добавляем его
                    Lists_Movies favoriteMovie = new Lists_Movies
                    {
                        MovieID = selectedMovie.MovieID,
                        ListType = "Избранное",
                        UserID = currentUser.UserID
                    };

                    entities.Lists_Movies.Add(favoriteMovie);
                    entities.SaveChanges();

                    MessageBox.Show("Movie added to favorites.");
                }
                else
                {
                    MessageBox.Show("This movie is already in favorites.");
                }
            }
            else
            {
                MessageBox.Show("Please select a movie to add to favorites.");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Check());
        }
        private void ViewFavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход к странице FavoritesList с передачей текущего пользователя
            NavigationService.Navigate(new FavoritesList(currentUser));
        }


    }
}
