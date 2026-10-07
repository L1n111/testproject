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
            AddGenre("Rock", new Genre() { Name = "Rock", Icon = "*", Color = Colors.Blue });
            AddGenre("Indie", new Genre() { Name = "Indie", Icon = "*", Color = Colors.Green });
            AddGenre("Jazz", new Genre() { Name = "Jazz", Icon = "*", Color = Colors.Purple });
            AddGenre("Rap", new Genre() { Name = "Rap", Icon = "*", Color = Colors.Red });
            AddGenre("Shoegaze", new Genre() { Name = "Shoegaze", Icon = "*", Color = Colors.Orange });
            AddGenre("AltRock", new Genre() { Name = "AltRock", Icon = "*", Color = Colors.Yellow });

            AddSong(new Song() { Name = "Cherry Waves", Duration = 120, Artist = "Deftones", Genres = new List<Genre>() { genres["AltRock"], genres["Shoegaze"] } });
            AddSong(new Song() { Name = "Be Quiet and Drive (Far Away)", Duration = 308, Artist = "Deftones", Genres = new List<Genre>() { genres["AltRock"], genres["Shoegaze"] } });
            AddSong(new Song() { Name = "Stressed Out", Duration = 202, Artist = "Twenty One Pilots", Genres = new List<Genre>() { genres["Indie"], genres["AltRock"] } });
            AddSong(new Song() { Name = "gladiator", Duration = 175, Artist = "Kai Angel", Genres = new List<Genre>() { genres["Rap"], genres["Indie"] } });
            AddSong(new Song() { Name = "Everlong", Duration = 250, Artist = "Foo Fighters", Genres = new List<Genre>() { genres["Rock"], genres["AltRock"] } });
            AddSong(new Song() { Name = "Do I Wanna Know?", Duration = 263, Artist = "Arctic Monkeys", Genres = new List<Genre>() { genres["Indie"], genres["Rock"] } });
            AddSong(new Song() { Name = "Alright", Duration = 219, Artist = "Kendrick Lamar", Genres = new List<Genre>() { genres["Rap"], genres["Jazz"] } });
            AddSong(new Song() { Name = "Lose Yourself", Duration = 321, Artist = "Eminem", Genres = new List<Genre>() { genres["Rap"], genres["Rock"] } });
            AddSong(new Song() { Name = "The Less I Know The Better", Duration = 219, Artist = "Tame Impala", Genres = new List<Genre>() { genres["Indie"], genres["AltRock"] } });
            AddSong(new Song() { Name = "HUMBLE.", Duration = 177, Artist = "Kendrick Lamar", Genres = new List<Genre>() { genres["Rap"], genres["Indie"] } });
        }
        public static void AddSong(Song song)
        {
            songlst.Add(song);
        }
        public static void AddGenre(string key, Genre genre)
        {
            genres.Add(key, genre);
        }
        public static Dictionary<string, Genre> GetGenres()
        {
            return genres;
        }
        public static List<Song> GetSongs()
        {
            return songlst;
        }
        public static List<User> GetUsers()
        {
            return users;
        }
        public static bool RegisterNewUser(string name, string email, string password, DateTime birthday)
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
