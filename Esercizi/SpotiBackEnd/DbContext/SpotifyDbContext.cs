using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models.UserModels;
using SpotiLogLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.DbContext
{
    
    public class SpotifyDbContext : DbContext
    {
        public List<UserListener> UserListeners { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
        public List<Radio> Radios { get; set; }
        public List<Playlist> Playlists { get; set; }

        public SpotifyDbContext(string path) : base(path) 
        {
            Logger logger = Logger.Instance;
            UserListeners = ReadDataFromCsv<UserListener>(path + typeof(UserListener).Name.ToString() + ".csv", logger);
            Artists = ReadDataFromCsv<Artist>(path + typeof(Artist).Name.ToString() + ".csv", logger);
            Albums = ReadDataFromCsv<Album>(path + typeof(Album).Name.ToString() + ".csv", logger);
            Songs = ReadDataFromCsv<Song>(path +  typeof(Song).Name.ToString() + ".csv", logger);    
            Radios = ReadDataFromCsv<Radio>(path + typeof(Radio).Name.ToString() + ".csv", logger);
            Playlists = ReadDataFromCsv<Playlist>(path + typeof(Playlist).Name.ToString() + ".csv", logger);
            MapSongsData();
        }

        private void MapSongsData()
        {
            foreach (var playlist in Playlists)
            {
                Song[] songs = Songs.Where(i => i.PlaylistId == playlist.PlaylistId).ToArray();

                playlist.Songs = songs;
            }

            foreach (var album in Albums)
            {
                Song[] songsArr = Songs.Where(s => s.Album == album).ToArray();

                album.Songs = songsArr;
            }
            
            foreach (var artist in Artists)
            {
                Album[] albums = Albums.Where(a => a.Artist == artist).ToArray();

                artist.Albums = albums;
            }
        }
    }
}
