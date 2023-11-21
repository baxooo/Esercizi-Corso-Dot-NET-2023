using SpotifyClone.UserModels;
using System;

namespace SpotifyClone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserListener user = new UserListener(1,"Carlo");

            Artist greenDay = new Artist(1, "Geen Day", "Green Day");
            Song[] greenSongs = new Song[3];
            Album AmericanIdiot = new Album("American Idiot", greenDay,greenSongs);

            var AmIdiot = new Song("American Idiot", greenDay, AmericanIdiot, "2004", 174);
            var WakeSeptember = new Song("Wake Me up When September Ends", greenDay, AmericanIdiot, "2004", 285);
            var holyday = new Song("Holyday", greenDay, AmericanIdiot, "2004", 232);

            greenSongs[0] = AmIdiot; 
            greenSongs[1] = WakeSeptember; 
            greenSongs[2] = holyday;

            Artist Salmo = new Artist(2, "Maurizio", "Salmo");
            Song[] salmoSongs= new Song[2];
            Album playlistSalmo = new Album("Playlist", Salmo,salmoSongs);

            var novantaMin = new Song("90MIN", Salmo, playlistSalmo, "2018", 231);
            var pxm = new Song("PMX",Salmo,playlistSalmo,"2018",184);

            salmoSongs[0] = novantaMin;
            salmoSongs[1] = pxm;

            Playlist playlist = new Playlist("misto");
            playlist.AddSong(AmIdiot);
            playlist.AddSong(WakeSeptember);
            playlist.AddSong(holyday);
            playlist.AddSong(pxm);
            playlist.AddSong(novantaMin);
            user.CreateNewPlaylist(playlist);


            ClasseUI classe = new ClasseUI(user);

            




            Console.Read();
        }
    }
}
