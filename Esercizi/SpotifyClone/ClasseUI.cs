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

namespace SpotifyClone
{
    internal sealed class ClasseUI
    {
        MediaPlayer _player;
        UserListener _user;
        private object[] _currentSelectionArray;
        private ConsoleColor _currentColor;
        private Album[] _albums;
        private Artist[] _artists;
        private Playlist[] _playlists;
        private Radio[] _radio;
        private Playlist _currentSelectedPlaylist;
        private Album _currentSelectedAlbum;
        private bool _isSong = false;

        public ClasseUI(UserListener user)
        {
            _player = new MediaPlayer();
            _user = user;

            try
            {
                _albums = _user.Albums;
                _artists = _user.Artists;
                _playlists = _user.Playlists;
                _radio = _user.RadioFavorites;
            }
            catch (NullReferenceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();
                Console.Read();
            }
            
            SelectMediaSourceMenu();
        }

        private void CreateDefaultMenu()
        {
            CreateMenu(ConsoleColor.Magenta, _artists);
        }

        private bool GetInputFromUser()
        {
            char input = Console.ReadKey().KeyChar;
            input = Char.ToLower(input);
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
                    CreateMenu(ConsoleColor.Magenta, _artists);
                    return true;
                case 'd'://albums
                    Console.Clear();
                    CreateMenu(ConsoleColor.Red, _albums);
                    return true;
                case 'l'://playlist
                    Console.Clear();
                    CreateMenu(ConsoleColor.Green, _playlists);
                    return true;
                case 'r'://radio
                    Console.Clear();
                    try
                    {
                        CreateMenu(ConsoleColor.Yellow, _radio);
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

        private object[] GetNestedArray(object o)
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

        private void CreateMenu(ConsoleColor consoleColor, object[] array)
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
            foreach (var oggetto in array)
            {
                if (i == 10) break;
                i++;
                Console.Write("║");
                Console.BackgroundColor = consoleColor;
                Console.ForegroundColor = ConsoleColor.Black;

                if (oggetto is Album album)
                    Console.Write($" {i}. {album.AlbumName}".PadRight(45));
                else if (oggetto is Artist artist)
                    Console.Write($" {i}. {artist.Alias}".PadRight(45));
                else if(oggetto is Radio radio)
                    Console.Write($" {i}. {radio.Name}".PadRight(45));
                else if(oggetto is Playlist playlist)
                    Console.Write($" {i}. {playlist.Name}".PadRight(45));
                else if(oggetto is Song song)
                    Console.Write($" {i}. {song.Title}".PadRight(45));
                else if(oggetto is string st)
                    Console.Write($" {i}. {st}".PadRight(45));

                Console.ResetColor();
                Console.Write("║\n");
            }
            Console.WriteLine("╚═════════════════════════════════════════════╝");
        }

        private void SelectMediaSourceMenu()
        {
            string top =    "╔═════════════════════════════════════════════╗";
            string center = "║              Select Media Source            ║" +
                          "\n║         'M' for Music, 'V' for Movies       ║";
            string bottom = "╚═════════════════════════════════════════════╝";
            bool validInput = false;
            Console.WriteLine(top);
            Console.WriteLine(center);
            Console.WriteLine(bottom);
            
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

        private void Choose()
        {
            
        }
    }
}
