﻿using SpotifyClone.Models;
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

            List<string> list = ReadDataFromCsv(songsFilePath,logger);
            if (list == null || list.Count == 0)
            {
                logger.Log(LogTypeEnum.WARNING, "Unable to read dataset, using default songs");
                user = GenerateData();
            }
            else
            {
                logger.Log( LogTypeEnum.INFO, "creating dataset for user");
                List<Data> csv = CsvReader<Data>.CreateObject(list, logger);
                user = ObjectMapper.MapSongsData(csv);
            }
            user = GenerateMoviesData(user);
            ClasseUI classe = new ClasseUI(user);
            classe.LogMenu();
        }

        private static UserListener GenerateMoviesData(UserListener user)
        {
            Movie[] allMovies = new Movie[10]
            {
                new Movie(2, new int[] { 1920, 1080 }, "Harry Potter e Il Prigioniero di Azkaban"),
                new Movie(5, new int[] { 1280, 720 }, "BeetleJuice"),
                new Movie(8, new int[] { 3840, 2160 }, "John Wick"),
                new Movie(1, new int[] { 1920, 928 }, "Zombie Land"),
                new Movie(4, new int[] { 1920, 1080 }, "Back to the Future"),
                new Movie(3, new int[] { 1920, 1080 }, "Il Grande Lebowski"),
                new Movie(3, new int[] { 1920, 1080 }, "The Wolf of Wall Street"),
                new Movie(2, new int[] { 1280, 720 }, "Le Iene"),
                new Movie(11, new int[] { 3840, 2160 }, "DJANGO"),
                new Movie(5, new int[] { 1280, 720 }, "Vacanze di Natale 2000")
            };
             

            MoviePlaylist p1 = new MoviePlaylist("Azione");
            p1.AddMovie(allMovies[2]);
            p1.AddMovie(allMovies[3]);
            p1.AddMovie(allMovies[8]);
            p1.UpdateScore();
            MoviePlaylist p2 = new MoviePlaylist("Fantasia");
            p2.AddMovie(allMovies[0]);
            p2.AddMovie(allMovies[1]);
            p2.AddMovie(allMovies[4]);
            p2.UpdateScore();
            MoviePlaylist p3 = new MoviePlaylist("Mix");
            p3.AddMovie(allMovies[5]);
            p3.AddMovie(allMovies[6]);
            p3.AddMovie(allMovies[9]);
            p3.UpdateScore();

            allMovies.ToList().ForEach(movie => user.AddMovie(movie));
            user.AddMoviePlaylist(p1);
            user.AddMoviePlaylist(p2);
            user.AddMoviePlaylist(p3);

            return user;
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

        public static List<string> ReadDataFromCsv(string path,Logger logger)
        {
            if (!File.Exists(path))
            {
                logger.Log(LogTypeEnum.WARNING, "csv file does not exist");
                return null; // TODO - log
            }

            return File.ReadAllLines(path).ToList();
        }
    }
}
