using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using testproject.Models;
using testproject.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;

namespace testproject.ViewModels
{
    internal class CoLViewViewModel : ViewModelBase
    {
        public ICommand AddSongCommand { get; set; }
        public ICommand RemoveSongCommand { get; set; }

        public CoLViewViewModel()
        {
            LoadSongs();
            AddSongCommand = new Command<Song>(AddSong);
            RemoveSongCommand = new Command<Song>(RemoveSong);
        }
        public ObservableCollection<Song> Songs { get; set; }
        private async void LoadSongs()
        {
            var songslst = await DataRepo.GetSongsAsync();
            Songs = new ObservableCollection<Song>(songslst);
        }
        private async void AddSong(Song song)
        {
            await DataRepo.AddSongAsync(song);
            Songs.Add(song);
                
        }
        private async void RemoveSong(Song song)
        {
            await DataRepo.RemoveSongAsync(song);
            Songs.Remove(song);
        }
    }
}
