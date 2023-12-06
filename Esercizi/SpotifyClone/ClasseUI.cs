using System;
using System.Linq;
using System.Globalization;
using System.Xml;
using SpotifyClone.MediaPLayers;
using SpotiLogLibrary;
using SpotiServicesLibrary;
using SpotiServicesLibrary.ModelsDTO;
using SpotiServicesLibrary.Interfaces;
using SpotiServicesLibrary.Services;

namespace SpotifyClone
{
    internal sealed class ClasseUI
    {
        IMediaPlayer _player;
        UserDTO _user;
        private IRating[] _currentSelectionArray;
        private ConsoleColor _currentColor;
        private PlaylistDTO _currentSelectedPlaylist;
        private AlbumDTO _currentSelectedAlbum;
        private Logger _logger;
        private CultureInfo _culture;
        UserSongServices _userServices;
        UserMovieServices _userMovieServices;
        private bool _isMusic;
        private bool _isMedia;


        public ClasseUI()
        {
            _logger = Logger.Instance;

            _userServices = UserSongServices.Instance;
            if (_logger.FilePath == null)
                _logger.FilePath = @"D:/Log.txt";
        }

        private void CreateDefaultMenu()
        {
            if(_isMusic)
                CreateMenu(ConsoleColor.Magenta, _userServices.GetUserArtistArray(_user.Id));
            else
                CreateMenu(ConsoleColor.Magenta, _userMovieServices.GetAllUserMoviePlaylists());
        }

        private bool GetInputFromUser()
        {
            char input = Console.ReadKey().KeyChar;
            input = Char.ToLower(input);
            switch (input)
            {
                case 'm'://menu default 
                    Console.Clear();
                    CreateDefaultMenu();
                    return true;
                case 'c':
                    Console.Clear();
                    //TODO create settings menu
                    return true;
                case 'a'://artists or movie playlists
                    Console.Clear();
                    if (_isMusic)
                        CreateMenu(ConsoleColor.Magenta, _userServices.GetUserArtistArray(_user.Id));
                    else
                        CreateMenu(ConsoleColor.Magenta, _userMovieServices.GetAllUserMoviePlaylists()); 
                    return true;
                case 'd' ://albums or all movies
                    Console.Clear();
                    if (_isMusic)
                        CreateMenu(ConsoleColor.Red, _userServices.GetUserAlbumsArray(_user.Id));
                    else
                       CreateMenu(ConsoleColor.Magenta, _userMovieServices.GetAllUserMovies());
                    return true;
                case 'l'://playlist
                    if (!_isMusic)  return true;
                    Console.Clear();
                    CreateMenu(ConsoleColor.Green, _userServices.GetUserPlaylistsArray(_user.Id));
                    return true;
                case 'r'://radio
                    if (!_isMusic) return true;
                    Console.Clear();
                    CreateMenu(ConsoleColor.Yellow, _userServices.GetUserRadioArray(_user.Id));
                    return true;
                case 'e'://exit
                    TimeSpan timeSpan  = _userServices.GetUserListenTime(_user.Id);
                    _logger.Log(LogTypeEnum.INFO, 
                         $"user closed the app, listening music for a total of {XmlConvert.ToString(timeSpan)}");
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
                    _player.Next(_user.Id);
                    return true;
                case 'b'://previous
                    Console.Clear();
                    CreateMenu(_currentColor, _currentSelectionArray);
                    _player.Previous(_user.Id);
                    return true;
                case 'g'://select whole playlist
                    Console.Clear();
                    CreateMenu(_currentColor, _currentSelectionArray);

                    if (_currentSelectedPlaylist != null)
                        _player.Start(_currentSelectedPlaylist, _user.Id);
                    else if (_currentSelectedAlbum != null)
                        _player.Start(_currentSelectedAlbum, _user.Id);

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
                            if (_isMedia)
                            {
                                _player.Start(array[i - 1], _user.Id);
                                _isMedia = false;
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
                case AlbumDTO album:
                    _currentSelectedAlbum = album;
                    return album.Songs;
                case PlaylistDTO playlist:
                    _currentSelectedPlaylist = playlist;
                    return playlist.Songs;
                case ArtistDTO artist:
                    return artist.Albums;
                case RadioDTO radio:
                    return radio.OnAirPlaylist.Songs;
                case SongDTO:
                    _isMedia = true;
                    return _currentSelectionArray;
                case MoviePlaylistDTO mp:
                    return mp.Movies;
                case MovieDTO:
                    _isMedia = true;
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

            if (_isMusic)
            {
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
                Console.WriteLine(" ║" +
                          "\n║    'a'     'd'       'l'      'r'           ║");
            }
            else
            {
                Console.Write("║ ");
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("     MoviePlaylist     ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("      AllMovies     ");
                Console.ResetColor();
                Console.WriteLine(" ║" +
                           "\n║           'a'                   'd'         ║" );
            }
            string center2 = "╚═════════════════════════════════════════════╝";
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

                switch (oggetto)
                {
                    case AlbumDTO album:
                        Console.Write($" {i}. {album.AlbumTitle}".PadRight(45 - album.Rating.ToString().Length) + album.Rating);
                        break;
                    case ArtistDTO artist:
                        Console.Write($" {i}. {artist.Alias}".PadRight(45 - artist.Rating.ToString().Length) + artist.Rating);
                        break;
                    case RadioDTO radio:
                        Console.Write($" {i}. {radio.Name}".PadRight(45 - radio.Rating.ToString().Length) + radio.Rating);
                        break;
                    case PlaylistDTO playlist:
                        Console.Write($" {i}. {playlist.Name}".PadRight(45 - playlist.Rating.ToString().Length) + playlist.Rating);
                        break;
                    case SongDTO song:
                        Console.Write($" {i}. {song.Title}".PadRight(45 - song.Rating.ToString().Length) + song.Rating);
                        break;
                    case MovieDTO movie:
                        Console.Write($" {i}. {movie.Title}".PadRight(45 - movie.Rating.ToString().Length) + movie.Rating);
                        break;
                    case MoviePlaylistDTO pl:
                        Console.Write($" {i}. {pl.PlaylistName}".PadRight(45 - pl.Rating.ToString().Length) + pl.Rating);
                        break;
                };

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
                        _isMusic = true;
                        _player = MusicMediaPlayer.Instance;
                        Console.Clear();
                        CreateDefaultMenu();
                        while (GetInputFromUser()); // non mi aggrada questo while nel while
                        validInput = true;
                        break;

                    case 'v':
                        _isMusic = false;
                        Console.Clear();
                        _player = MovieMediaPlayer.Instance;
                        CreateDefaultMenu();
                        while (GetInputFromUser());
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Input is not valid, please try again!");
                        break;
                }
            } while (!validInput);
        }

        public void LogMenu()
        {
            AuthenticationServices au = AuthenticationServices.Instance;
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

                UserDTO user = au.Login(credentials[0], credentials[1]);
                if (user != null)
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

            SelectCultureInfo();
            SelectMediaSourceMenu();
        }

        private void SelectCultureInfo()
        {
            Console.Clear();
            string menu = "╔═════════════════════════════════════════════╗" +
                        "\n║          Please select a language           ║" +
                        "\n║                  1.English                  ║" +
                        "\n║                  2.Italian                  ║" +
                        "\n║                  3.French                   ║" +
                        "\n║                  4.German                   ║" +
                        "\n║                  5.Spanish                  ║" +
                        "\n╚═════════════════════════════════════════════╝";
            Console.WriteLine(menu);
            bool validInput = true;
            do
            {
                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case '1':
                        _culture = CultureInfo.CreateSpecificCulture("en-US");
                        validInput = false;
                        break;
                    case '2':
                        _culture = CultureInfo.CreateSpecificCulture("it-IT");
                        validInput = false;
                        break;
                    case '3':
                        _culture = CultureInfo.CreateSpecificCulture("fr-FR");
                        validInput = false;
                        break;
                    case '4':
                        _culture = CultureInfo.CreateSpecificCulture("de-DE");
                        validInput = false;
                        break;
                    case '5':
                        _culture = CultureInfo.CreateSpecificCulture("es-ES");
                        validInput = false;
                        break;
                }
            }
            while (validInput);
        }
    }
}
