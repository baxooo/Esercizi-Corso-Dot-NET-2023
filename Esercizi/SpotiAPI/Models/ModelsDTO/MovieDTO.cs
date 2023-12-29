﻿using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Models.ModelsDTO
{
    public class MovieDTO
    {
        public MovieDTO(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Rating = movie.Rating;
            Resolution = movie.Resolution;
            MoviePlaylists = movie.MoviePlaylists.Select(mp=> new MoviePlaylistDTO(mp)).ToList();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Rating { get; set; }
        public string Resolution { get; set; }
        public List<MoviePlaylistDTO>  MoviePlaylists { get; set; }
    }
}
