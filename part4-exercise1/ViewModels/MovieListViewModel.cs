using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieCatalog.ViewModels;

public class MovieListViewModel: ObservableObject
{
    private MovieViewModel _selectedMovie;

    public MovieViewModel SelectedMovie
    {
        get => _selectedMovie;
        set => SetProperty(ref _selectedMovie, value);
    }

    public ObservableCollection<MovieViewModel> Movies { get; set; }

    public ICommand GiveBonus { get; private set; }

    public MovieListViewModel()
    {
        Movies = [];

        _selectedMovie = new (
            new Models.Movie(string.Empty, 
                string.Empty, 
                string.Empty, 
                DateTime.Now.Year));

        GiveBonus = new Command(GiveBonusExecute, GiveBonusCanExecute);

    }

    async void GiveBonusExecute()
    {
        //logic for giving bonus
        await 
    }

    bool GiveBonusCanExecute()
    {
        //logic for deciding if "give bonus" button should be enabled.
        return false;
    }


    public async Task RefreshMovies()
    {
        IEnumerable<Models.Movie> moviesData = await Models.MoviesDatabase.GetMovies();

        foreach (Models.Movie movie in moviesData)
            Movies.Add(new MovieViewModel(movie));

    }

    public void DeleteMovie(MovieViewModel movie) =>
        Movies.Remove(movie);
}
