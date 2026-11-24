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
        public CoLViewViewModel()
        {
            LoadSongs();
        }
        public ObservableCollection<Song> Songs { get; set; }
        private async void LoadSongs()
        {
            var songslst = await DataRepo.GetSongsAsync();
            Songs = new ObservableCollection<Song>(songslst);
        }
    }
}
