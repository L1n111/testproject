namespace testproject.Views;
using testproject.Models;
using testproject.Services;
using System.Collections.ObjectModel;

public partial class CoLView : ContentPage
{
    private DataRepo _repo = new DataRepo();
	public ObservableCollection<Song> Songs { get; set; } 
    public CoLView()
	{
        LoadSongs();
        BindingContext = this;	
        InitializeComponent();
	}

    private async void LoadSongs()
    {
        var songslst = await DataRepo.GetSongsAsync();
        Songs = new ObservableCollection<Song>(songslst);
    }
    private async void ShowSongInfo(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Song song = (Song)button.BindingContext;
        string genres = string.Join(", ", song.Genres);
        await DisplayAlert("Song Info", $"Name: {song.Name}\nArtist: {song.Artist}\nGenres: {genres}\nDuration: {song.Duration} seconds", "OK");
    }
}