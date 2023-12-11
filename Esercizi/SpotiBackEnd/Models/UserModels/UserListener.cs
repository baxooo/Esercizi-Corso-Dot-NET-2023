﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models;

namespace SpotiBackEnd.Models.UserModels
{
    public sealed class UserListener : User
    {
        public Playlist[] Playlists { get; set; }
        public Playlist FavoritesPlaylist { get; set; }
        public Radio[] RadioFavorites { get; set; }
        public Artist[] Artists { get; set; }
        public Album[] Albums { get; set; }
        public MoviePlaylist[] PlaylistMovie { get; set; }
        public Song[] AllUserSongs { get; set; }
        public Movie[] AllMovies { get; set; }
        public int RemainingTime { get; set; }
        public int ListenTime { get; set; }
        public MembershipTypeEnum MembershipType { get; set; } 
        
    }
}
