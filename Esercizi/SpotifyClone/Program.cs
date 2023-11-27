using SpotifyClone.Models;
using SpotifyClone.UserModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpotifyClone
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Logger logger = Logger.Instance;
            string loggerFilePath = @"D:/Log.txt";
            logger.FilePath = loggerFilePath;

            UserListener user = null; 
            string songsFilePath = @"D:/songs.csv";

            List<string> list = ReadDataFromCsv(songsFilePath);
            if (list == null || list.Count == 0)
            {
                logger.Log(LogTypeEnum.WARNING, "Unable to read dataset, using default songs");
                user = GenerateData();
            }
            else
            {
                logger.Log(loggerFilePath, LogTypeEnum.INFO, "creating data for user");
                List<Data> csv = CsvReader<Data>.CreateObject(list, logger);
                user = ObjectMapper.MapSongsData(csv);
            }

            ClasseUI classe = new ClasseUI(user);
        }

        static UserListener GenerateData()
        {
            UserListener user = new UserListener(1, "Carlo", MembershipTypeEnum.FREE);
            Artist greenDay = new Artist("Geen Day", "Green Day", "Rock");
            Song[] greenSongs = new Song[3];
            Album AmericanIdiot = new Album("American Idiot", greenDay, greenSongs, "2004");
            greenDay.AddAlbum(AmericanIdiot);

            var AmIdiot = new Song(43, "American Idiot", greenDay, AmericanIdiot, 174, 0,1);
            var WakeSeptember = new Song(44, "Wake Me up When September Ends", greenDay, AmericanIdiot, 285,0, 1);
            var holyday = new Song(45, "Holyday", greenDay, AmericanIdiot, 232, 0, 1);

            greenSongs[0] = AmIdiot;
            greenSongs[1] = WakeSeptember;
            greenSongs[2] = holyday;

            Artist Salmo = new Artist("Maurizio", "Salmo", "Rap");
            Song[] salmoSongs = new Song[2];
            Album playlistSalmo = new Album("Playlist", Salmo, salmoSongs, "2018");
            Salmo.AddAlbum(playlistSalmo);

            var novantaMin = new Song(46, "90MIN", Salmo, playlistSalmo, 231, 0 , 1);
            var pxm = new Song(47, "PMX", Salmo, playlistSalmo, 184, 0, 1);

            salmoSongs[0] = novantaMin;
            salmoSongs[1] = pxm;

            Playlist playlist = new Playlist(1,"misto");
            playlist.AddSong(AmIdiot);
            playlist.AddSong(WakeSeptember);
            playlist.AddSong(holyday);
            playlist.AddSong(pxm);
            playlist.AddSong(novantaMin);
            user.CreateNewPlaylist(playlist);
            return user;
        }

        public static List<string> ReadDataFromCsv(string path)
        {
            if (!File.Exists(path))
            {
                return null; // TODO - log
            }

            return File.ReadAllLines(path).ToList();
        }
    }
}
