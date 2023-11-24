namespace SpotifyClone
{
    internal class Radio
    {
        private readonly string _name;
        private Playlist _onAirPlaylist;

        public string Name { get { return _name; } }
        public Playlist OnAirPlaylist {  get { return _onAirPlaylist; } }
        public int Score { get { return _onAirPlaylist.Score; } }

        public Radio(string name)
        {
            _name = name;
        }

        public void GetPlaylist()
        {

        }
    }
}