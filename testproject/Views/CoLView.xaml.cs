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
}