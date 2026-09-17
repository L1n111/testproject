namespace testproject.Views;

using System.Linq;
using testproject.Models;
using testproject.Services; 
public partial class MainPage : ContentPage
{
    Dictionary<string, Genre> genres;
    List<Song> songlst;
    public MainPage()
    {
        InitializeComponent();
        genres = Services.DataRepo.GetGenres();
        songlst = Services.DataRepo.GetSongs();
        GenerateGenreButtons();
    }
    public void GenerateGenreButtons()
    {
        
        foreach (var gnr in genres)
        {
            Button genreButton = new Button
            {
                Text = gnr.Key,
                TextColor = Colors.White,
                BackgroundColor = gnr.Value.Color,
                CornerRadius = 10,
                Margin = new Thickness(5),
                Padding = new Thickness(10, 5),
            };
            genreButton.Clicked += GenreButtonClicked; 
            GenresButtons.Children.Add(genreButton);
        }
    }
    public void GenreButtonClicked(object sender, EventArgs e)
    {
        string genreKey;
        if (sender is Button clickedButton)
        {
            genreKey = clickedButton.Text;
            ShowSongLst(genreKey);
        }
    }
    private void ShowSongLst(string genreKey)
    {
        SongLst.Children.Clear();
        Genre targetGenre = genres[genreKey];
        var results = songlst.Where(song => song.Genres.Contains(targetGenre));
        foreach (var song in results)
        {
            Label songLabel = new Label
            {
                Text = $"{song.Name} - {song.Artist} ({song.Duration}s)",
                TextColor = Colors.Black,
                FontSize = 25,
                Margin = new Thickness(5),
            };
            SongLst.Children.Add(songLabel);
        }
    }
}