using SpotifyClone.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Timers;
using System.Runtime.InteropServices;
using System.Transactions;
using SpotifyClone.Interfaces;
using SpotifyClone.Models;
using SpotifyClone.Authentication;

namespace SpotifyClone
{
    internal sealed class ClasseUI
    {
        MediaPlayer _player;
        UserListener _user;
        private IRating[] _currentSelectionArray;
        private ConsoleColor _currentColor;
        private Playlist _currentSelectedPlaylist;
        private Album _currentSelectedAlbum;
        private bool _isSong = false;
        private Logger _logger;

        public ClasseUI(UserListener user)
        {
            _player = new MediaPlayer(this);
            _user = user;
            
            _logger = Logger.Instance;
            if (_logger.FilePath == null)
                _logger.FilePath = @"D:/Log.txt";

            LogMenu();
        }

        private void CreateDefaultMenu()
        {
            CreateMenu(ConsoleColor.Magenta, _user.Artists.OrderByDescending(a=> a.Rating).ToArray());
        }

        private bool GetInputFromUser()
        {
            char input = Console.ReadKey().KeyChar;
            input = Char.ToLower(input);
            _user.UpdateArraySort();
            switch (input)
            {
                case 'm'://menu musica already default con default Artists
                    Console.Clear();
                    CreateDefaultMenu();
                    return true;
                case 'c':
                    Console.Clear();
                    //TODO create settings menu
                    return true;
                case 'a'://artists
                    Console.Clear();
                    CreateMenu(ConsoleColor.Magenta, _user.Artists);
                    return true;
                case 'd'://albums
                    Console.Clear();
                    CreateMenu(ConsoleColor.Red, _user.Albums);
                    return true;
                case 'l'://playlist
                    Console.Clear();
                    CreateMenu(ConsoleColor.Green, _user.Playlists);
                    return true;
                case 'r'://radio
                    Console.Clear();
                    try
                    {
                        CreateMenu(ConsoleColor.Yellow, _user.RadioFavorites);
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.StackTrace);
                        Console.ResetColor();
                        Console.WriteLine("Press any key to continue");
                        Console.Read();
                    }
                    return true;
                case 'e'://exit
                    return false;
                case 'p':// play/pause
                    Console.Clear();
                    CreateMenu(_currentColor, _currentSelectionArray);
                    _player.PlayPause();
                    return true;
                case 's'://stop
                    Console.Clear();
                    CreateMenu(_currentColor, _currentSelectionArray);
                    _player.Stop();
                    return true;
                case 'n'://next
                    Console.Clear();
                    CreateMenu(_currentColor, _currentSelectionArray);
                    _player.Next();
                    return true;
                case 'b'://previous
                    Console.Clear();
                    CreateMenu(_currentColor, _currentSelectionArray);
                    _player.Previous();
                    return true;
                case 'g'://select whole playlist
                    Console.Clear();
                    CreateMenu(_currentColor, _currentSelectionArray);

                    if (_currentSelectedPlaylist != null)
                        _player.Start(_currentSelectedPlaylist);
                    else if (_currentSelectedAlbum != null)
                        _player.Start(_currentSelectedAlbum);

                    return true;
                case var _ when char.IsDigit(input):
                    int n = Int32.Parse(input.ToString());
                    if (n > _currentSelectionArray.Length)
                        return true;
                    for (int i = 1; i < _currentSelectionArray.Length + 1 && n != 0; i++)
                    {
                        if (i == n ) 
                        {
                            //in questo caso è stata trovata l'album/radio/playlist che ci
                            //serve la prendiamo e la mandiamo a create menu 
                            var array = GetNestedArray(_currentSelectionArray[i - 1]);
                            Console.Clear();
                            CreateMenu(_currentColor, array);
                            if (_isSong) // ho aggiunto questa soluzione poco elegante al problema dello
                                         // stampare "is now playing X", in quanto antecedentemente nello
                                         // switch case in GetNestedArray(x) andavo a stampare su console
                                         // ma subito dopo c'è un clear e poi ristampa la console e non
                                         // si vedeva.
                            {
                                _player.Start((Song)_currentSelectionArray[i - 1]);
                                _isSong = false;
                            }
                            break;
                        }
                    }
                    return true;
                default:
                    Console.Clear();
                    CreateDefaultMenu();
                    Console.WriteLine("Input is not valid, please try again!");
                    return true;
            }
        }

        private IRating[] GetNestedArray(object o)
        {
            switch (o)
            {
                case Album album:
                    _currentSelectedAlbum = album;
                    return album.Songs;
                case Playlist playlist:
                    _currentSelectedPlaylist = playlist;
                    return playlist.Songs;
                case Artist artist:
                    return artist.Albums;
                case Radio radio:
                    return radio.OnAirPlaylist.Songs;
                case Song song:
                    _isSong = true;
                    return _currentSelectionArray;
            }
            return null;
        }

        private void CreateMenu(ConsoleColor consoleColor, IRating[] array)
        {
            _currentColor = consoleColor;
            _currentSelectionArray = array;
            string top = "╔═════════════════════════════════════════════╗" +
                       "\n║       ╔═════════╗         ╔═════════╗       ║" +
                       "\n║       ║  MUSIC  ║         ║ PROFILE ║       ║" +
                       "\n║       ╚═════════╝         ╚═════════╝       ║" +
                       "\n╚═════════════════════════════════════════════╝"
                          ;
            Console.WriteLine(top);

            string center1 = "╔═════════════════════════════════════════════╗" +
                           "\n║                                             ║";
            Console.WriteLine(center1);
            Console.Write("║ ");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" Artists ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" Albums ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(" Playlists ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(" Radio ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" Search ");
            Console.ResetColor();

            string center2 = " ║" +
                      "\n║                                             ║" +
                      "\n╚═════════════════════════════════════════════╝";

            Console.Write(center2);

            Console.WriteLine();

            Console.WriteLine("╔═════════════════════════════════════════════╗");
            int i = 0;

            array = array.OrderByDescending(a => a.Rating).ToArray();
            foreach (var oggetto in array)
            {
                if (i == 10) break;
                i++;
                Console.Write("║");
                Console.BackgroundColor = consoleColor;
                Console.ForegroundColor = ConsoleColor.Black;

                if (oggetto is Album album)
                    Console.Write($" {i}. {album.AlbumName}".PadRight(45 - album.Rating.ToString().Length) + album.Rating);
                else if (oggetto is Artist artist)
                    Console.Write($" {i}. {artist.Alias}".PadRight(45 - artist.Rating.ToString().Length) + artist.Rating);
                else if(oggetto is Radio radio)
                    Console.Write($" {i}. {radio.Name}".PadRight(45- radio.Rating.ToString().Length) + radio.Rating);
                else if(oggetto is Playlist playlist)
                    Console.Write($" {i}. {playlist.Name}".PadRight(45- playlist.Rating.ToString().Length) + playlist.Rating);
                else if(oggetto is Song song)
                    Console.Write($" {i}. {song.Title}".PadRight(45- song.Rating.ToString().Length) + song.Rating);

                Console.ResetColor();
                Console.Write("║\n");
            }
            Console.WriteLine("╚═════════════════════════════════════════════╝");
        }

        private void SelectMediaSourceMenu()
        {
            Console.Clear();
            string menu = "╔═════════════════════════════════════════════╗" +
                        "\n║              Select Media Source            ║" +
                        "\n║         'M' for Music, 'V' for Movies       ║" +
                        "\n╚═════════════════════════════════════════════╝";
            bool validInput = false;
            Console.WriteLine(menu);
            
            do
            {
                char input = Console.ReadKey().KeyChar;
                input = Char.ToLower(input);
                switch (input)
                {
                    case 'm':
                        Console.Clear();
                        CreateDefaultMenu();
                        while (GetInputFromUser()) ;//non mi aggrada questo while nel while
                        validInput = true;
                        break;

                    case 'v':

                        Console.WriteLine("Movies are not available yet!");
                        break;
                    default:
                        Console.WriteLine("Input is not valid, please try again!");
                        break;
                }
            } while (!validInput);
        }

        private void LogMenu()
        {

            string[] credentials = new string[2];
            bool loggedIn = false;
            do
            {
                Console.Clear();

                string menu = "╔═════════════════════════════════════════════╗" +
                            "\n║        Please Insert User Credentials       ║" +
                            "\n║             Separated by a comma            ║" +
                            "\n╚═════════════════════════════════════════════╝";
                Console.WriteLine(menu);


                string userInput = Console.ReadLine();
                
                credentials = userInput.Split(',');

                if(credentials.Length != 2)
                {
                    Console.WriteLine("Insert User credentials separated by a comma es. \"user,user\"");
                    _logger.Log(LogTypeEnum.INFO, "Failed attempt to log in");

                    Console.WriteLine("press any key to restart");
                    Console.ReadKey();
                    continue;
                }
                if(Login.ValidateLogin(credentials[0], credentials[1]))
                {
                    loggedIn= true;
                    _logger.Log(LogTypeEnum.INFO, "successfull log in attempt from user");
                }
                else
                {
                    Console.WriteLine("Invalid credentials, please try again");
                    _logger.Log(LogTypeEnum.INFO, "Failed attempt to log in");

                    Console.WriteLine("press any key to restart");
                    Console.ReadKey();
                }
            }
            while (!loggedIn);

            SelectMediaSourceMenu();
        }
    }
}
