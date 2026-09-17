namespace testproject.Views;

using System.Linq;
using testproject.Models;
public partial class MainPage : ContentPage
{
    List<Song> songlst = new List<Song>();
    Dictionary<string, Genre> genres = new Dictionary<string, Genre>();
    public MainPage()
    {
        InitializeComponent();
        GenerateGenreButtons();
    }
    public void GenerateGenreButtons()
    {
        genres.Add("Rock", new Genre() { Name = "Rock", Icon = "*", Color = Colors.Blue });
        genres.Add("Indie", new Genre() { Name = "Indie", Icon = "*", Color = Colors.Green });
        genres.Add("Jazz", new Genre() { Name = "Jazz", Icon = "*", Color = Colors.Purple });
        genres.Add("Rap", new Genre() { Name = "Rap", Icon = "*", Color = Colors.Red });
        genres.Add("Shoegaze", new Genre() { Name = "Shoegaze", Icon = "*", Color = Colors.Orange });
        genres.Add("AltRock", new Genre() { Name = "AltRock", Icon = "*", Color = Colors.Yellow });

        songlst.Add(new Song() { Name = "Cherry Waves", Duration = 120, Artist = "Deftones", Genres = new List<Genre>() { genres["AltRock"], genres["Shoegaze"] } });
        songlst.Add(new Song() { Name = "Be Quiet and Drive (Far Away)", Duration = 308, Artist = "Deftones", Genres = new List<Genre>() { genres["AltRock"], genres["Shoegaze"] } });
        songlst.Add(new Song() { Name = "Stressed Out", Duration = 202, Artist = "Twenty One Pilots", Genres = new List<Genre>() { genres["Indie"], genres["AltRock"] } });
        songlst.Add(new Song() { Name = "gladiator", Duration = 175, Artist = "Kai Angel", Genres = new List<Genre>() { genres["Rap"], genres["Indie"] } });
        songlst.Add(new Song() { Name = "Everlong", Duration = 250, Artist = "Foo Fighters", Genres = new List<Genre>() { genres["Rock"], genres["AltRock"] } });
        songlst.Add(new Song() { Name = "Do I Wanna Know?", Duration = 263, Artist = "Arctic Monkeys", Genres = new List<Genre>() { genres["Indie"], genres["Rock"] } });
        songlst.Add(new Song() { Name = "Alright", Duration = 219, Artist = "Kendrick Lamar", Genres = new List<Genre>() { genres["Rap"], genres["Jazz"] } });
        songlst.Add(new Song() { Name = "Lose Yourself", Duration = 321, Artist = "Eminem", Genres = new List<Genre>() { genres["Rap"], genres["Rock"] } });
        songlst.Add(new Song() { Name = "The Less I Know The Better", Duration = 219, Artist = "Tame Impala", Genres = new List<Genre>() { genres["Indie"], genres["AltRock"] } });
        songlst.Add(new Song() { Name = "HUMBLE.", Duration = 177, Artist = "Kendrick Lamar", Genres = new List<Genre>() { genres["Rap"], genres["Indie"] } });

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