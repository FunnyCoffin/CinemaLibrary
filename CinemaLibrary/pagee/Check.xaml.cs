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
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Page
    {

        Entities entities = new Entities();

        public Check()
        {
            InitializeComponent();
            LoadMoviesData(); // Вызов метода загрузки фильмов при инициализации страницы
        }

        private void LoadMoviesData()
        {
            // Загрузка всех фильмов и установка их в качестве источника данных для ListView
            MoviesListView.ItemsSource = entities.Movies.ToList();
        }

    

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ReleaseYearTextBox.Text, out int releaseYear) &&
                decimal.TryParse(RatingTextBox.Text, out decimal rating))
            {
                // Применить фильтры по году выпуска, рейтингу и стране производства
                var filteredMovies = entities.Movies
                    .Where(m => m.ReleaseYear >= releaseYear &&
                                m.Rating >= rating)
                    .ToList();

                // Отобразить отфильтрованные фильмы
                MoviesListView.ItemsSource = filteredMovies;
            }
            else
            {
                MessageBox.Show("Введите корректные значения для года выпуска и рейтинга.");
            }
        }
        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранного фильма из ListView
            var selectedMovie = MoviesListView.SelectedItem as Movies;

            // Проверка, что фильм был выбран
            if (selectedMovie != null)
            {
                // Создание новой страницы для отображения подробной информации о фильме


                // Переход на новую страницу
                NavigationService.Navigate(new MovieDetailsPage(selectedMovie));
            }
            else
            {
                MessageBox.Show("Выберите фильм для просмотра подробной информации.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
