using SpotifyClone.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal static class ObjectMapper
    {
        public static UserListener MapSongsData(List<Data> data)
        {
            UserListener user = new UserListener(1,"Carlo");

            List<Artist> artists = data
                .Where(d => !string.IsNullOrEmpty(d.Artist))
                .GroupBy(d => d.Artist)
                .Select(d => new Artist(d.First().Artist, d.First().Artist, d.First().Genre))
                .ToList();

            List<Album> albums = data
                .Where(d => !string.IsNullOrEmpty(d.Album))
                .GroupBy(d => d.Album)
                .Select(d => new Album(d.First().Album, GetArtist(artists, d.First().Artist), null, d.First().Genre))
                .ToList();

            List<Song> songs = data
                .Where(d => !string.IsNullOrEmpty(d.Title))
                .Select(d => new Song(d.Id, d.Title, 
                                       GetArtist(artists, d.Artist), 
                                       GetAlbum(albums, d.Album), 
                                       0,d.Rating, d.PlaylistId
                )).ToList();

            foreach(var album in albums)
            {
                Song[] songsArr = songs.Where(s => s.Album == album).ToArray();

                album.AddSongs(songsArr);
            }

            foreach(var artist in artists)
            {
                Album[] albumi = albums.Where(a => a.Artist == artist).ToArray();

                foreach (var album in albumi)
                    artist.AddAlbum(album);
            }

            List<Playlist> playlists = data
                .Where(d => !string.IsNullOrEmpty(d.Playlist))
                .GroupBy(d => d.PlaylistId)
                .Select(d => new Playlist(d.First().PlaylistId,d.First().Playlist))
                .ToList();

            foreach(var playlist in playlists)
            {
                Song[] songs1 = songs.Where(i => i.PlaylistId == playlist.PlaylistId).ToArray();

                foreach(var song in songs1)
                    playlist.AddSong(song);

                user.CreateNewPlaylist(playlist);
            }

                

            return user;
        }

        private static Album GetAlbum(List<Album> albums, string albumName)
        {
            return albums.FirstOrDefault(a => a.AlbumName == albumName);
        }

        private static Artist GetArtist(List<Artist> artists, string artistName)
        {
            return artists.FirstOrDefault(a => a.Name == artistName);
        }
    }
}
