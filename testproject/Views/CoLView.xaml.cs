namespace testproject.Views;
using testproject.Models;
using testproject.Services;

public partial class CoLView : ContentPage
{
	public List<Song> songs { get; set; } 
    public CoLView()
	{
		songs = DataRepo.GetSongs();
        BindingContext = this;	
        InitializeComponent();
	}

    private async void ShowSongInfo(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Song song = (Song)button.BindingContext;
        string genres = string.Join(", ", song.Genres);
        await DisplayAlert("Song Info", $"Name: {song.Name}\nArtist: {song.Artist}\nGenres: {genres}\nDuration: {song.Duration} seconds", "OK");
    }
}