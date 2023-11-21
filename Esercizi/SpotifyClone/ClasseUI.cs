using SpotifyClone.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal sealed class ClasseUI
    {
        MediaPlayer _player;
        UserListener _user;

        public ClasseUI(UserListener user)
        {
            _player = new MediaPlayer();
            _user = user;

            SelectMediaSourceMenu();
        }

        private void CreateMenu()
        {
            CreateMenuBase();
            string top = "╔═════════════════════════════════════════════╗";
            string bottom = "╚═════════════════════════════════════════════╝";
            Console.WriteLine();
            Console.WriteLine(top);
            //47
            for (int i = 0; i < _user.Artists.Length &&  i <= 9; i++)
            {
                string artistName = _user.Artists[i].Alias;
                Console.Write("║"); 
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($" {i+1}. {artistName}".PadRight(45));
                Console.ResetColor();
                Console.Write("║\n");
            }
            Console.ResetColor();
            Console.WriteLine(bottom);
        }

        private void CreateMenuBase()
        {
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
        }

        private void UpdateMenu()
        {

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
            string input;

            do
            {

                input = Console.ReadLine();
                if (String.Equals(input, "M", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    CreateMenu();
                    validInput = true;
                }
                else if (String.Equals(input, "v", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Movies are not available yet!");
                }
                else
                    Console.WriteLine("Input is not valid, please try again!");


            } while (!validInput);
            

        }

        private void Choose()
        {
            
        }
    }
}
