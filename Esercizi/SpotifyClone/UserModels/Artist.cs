namespace SpotifyClone.UserModels
{
    internal class Artist : User
    {
        protected string _alias;
        protected Album[] _albums;

        public string Alias { get { return _alias; } }
        public Album[] Albums { get { return _albums; } }

        public Artist(int id, string name, string alias) : base(id, name)
        {
            _alias = alias;
        }

    }
}