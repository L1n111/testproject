namespace testproject.Views;
using System.Collections.ObjectModel;
using testproject.Models;
using testproject.Services;
using testproject.ViewModels;

public partial class CoLView : ContentPage
{
    CoLViewViewModel vm;
    public CoLView()
	{
        InitializeComponent();
        vm = new CoLViewViewModel();
        BindingContext = vm;
    }
    private async void ShowSongInfo(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Song song = (Song)button.BindingContext;
        string genres = string.Join(", ", song.Genres);
        await DisplayAlert("Song Info", $"Name: {song.Name}\nArtist: {song.Artist}\nGenres: {genres}\nDuration: {song.Duration} seconds", "OK");
    }
}