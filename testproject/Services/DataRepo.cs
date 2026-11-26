using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testproject.Models;

namespace testproject.Services
{
    internal class DataRepo
    {
        static List<Song> songlst = new List<Song>();
        static Dictionary<string, Genre> genres = new Dictionary<string, Genre>();
        static List<User> users = new List<User>();

        // Fake Data For Testing before we learn about DataBase
        public static void Init()
        {
            AddGenreAsync("Rock", new Genre() { Name = "Rock", Icon = "*", Color = Colors.Blue });
            AddGenreAsync("Indie", new Genre() { Name = "Indie", Icon = "*", Color = Colors.Green });
            AddGenreAsync("Jazz", new Genre() { Name = "Jazz", Icon = "*", Color = Colors.Purple });
            AddGenreAsync("Rap", new Genre() { Name = "Rap", Icon = "*", Color = Colors.Red });
            AddGenreAsync("Shoegaze", new Genre() { Name = "Shoegaze", Icon = "*", Color = Colors.Orange });
            AddGenreAsync("AltRock", new Genre() { Name = "AltRock", Icon = "*", Color = Colors.Yellow });

            AddSongAsync(new Song() { Name = "Cherry Waves", Duration = 120, Artist = "Deftones", Icon = "cherrywaves.jpg", Genres = new List<Genre>() { genres["AltRock"], genres["Shoegaze"] } });
            AddSongAsync(new Song() { Name = "Be Quiet and Drive (Far Away)", Duration = 308, Artist = "Deftones", Icon = "bequietanddrive.jfif", Genres = new List<Genre>() { genres["AltRock"], genres["Shoegaze"] } });
            AddSongAsync(new Song() { Name = "Stressed Out", Duration = 202, Artist = "Twenty One Pilots", Icon = "stressedout.jfif", Genres = new List<Genre>() { genres["Indie"], genres["AltRock"] } });
            AddSongAsync(new Song() { Name = "gladiator", Duration = 175, Artist = "Kai Angel", Icon = "gladiator.png", Genres = new List<Genre>() { genres["Rap"], genres["Indie"] } });
            AddSongAsync(new Song() { Name = "Everlong", Duration = 250, Artist = "Foo Fighters", Icon = "everlong.jfif", Genres = new List<Genre>() { genres["Rock"], genres["AltRock"] } });
            AddSongAsync(new Song() { Name = "Do I Wanna Know?", Duration = 263, Artist = "Arctic Monkeys", Icon = "doiwannaknow.jfif", Genres = new List<Genre>() { genres["Indie"], genres["Rock"] } });
            AddSongAsync(new Song() { Name = "Alright", Duration = 219, Artist = "Kendrick Lamar", Icon = "alright.jpg", Genres = new List<Genre>() { genres["Rap"], genres["Jazz"] } });
            AddSongAsync(new Song() { Name = "Lose Yourself", Duration = 321, Artist = "Eminem", Icon = "loseyourself.jpg", Genres = new List<Genre>() { genres["Rap"], genres["Rock"] } });
            AddSongAsync(new Song() { Name = "The Less I Know The Better", Duration = 219, Artist = "Tame Impala", Icon = "thelessiknowthebetter.jpeg", Genres = new List<Genre>() { genres["Indie"], genres["AltRock"] } });
            AddSongAsync(new Song() { Name = "HUMBLE.", Duration = 177, Artist = "Kendrick Lamar", Icon = "humble.png", Genres = new List<Genre>() { genres["Rap"], genres["Indie"] } });
        }
        public static async Task<bool> AddSongAsync(Song song)
        {
            songlst.Add(song);
            return true;
        }
        public static async Task<bool> RemoveSongAsync(Song song)
        {
            songlst.Remove(song);
            return true;
        }   
        public static async void AddGenreAsync(string key, Genre genre)
        {
            genres.Add(key, genre);
        }
        public static Dictionary<string, Genre> GetGenresAsync()
        {
            return genres;
        }
        public static async Task<List<Song>> GetSongsAsync()
        {
            return songlst;
        }
        public static async Task<List<User>> GetUsersAsync()
        {
            return users;
        }
        public static async Task<bool> RegisterNewUserAsync(string name, string email, string password, DateTime birthday)
        {
            User foundUser = users.Find(user => user.Email.ToLower() == email.ToLower());
            if (foundUser == null)
            {
                users.Add(new User() { Name = name, Email = email, Password = password, BirthDate = birthday });
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
