using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SpotiAPI.Models
{
    public partial class SpotifyContext : DbContext
    {
        public SpotifyContext()
        {
        }

        public SpotifyContext(DbContextOptions<SpotifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MoviePlaylist> MoviePlaylists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Radio> Radios { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<UserListener> UserListeners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=Spotify; User id = sa ; password = Password.123;Trusted_Connection=False;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasIndex(e => e.ArtistId, "IX_Albums_ArtistId");

                entity.Property(e => e.AlbumName).HasMaxLength(100);
                entity.Property(e => e.Genre).HasMaxLength(50);

                entity.HasOne(d => d.Artist).WithMany(p => p.Albums).HasForeignKey(d => d.ArtistId);
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(100);
                entity.Property(e => e.Genre).HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Resolution).HasMaxLength(20);
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<MoviePlaylist>(entity =>
            {
                entity.HasIndex(e => e.UserListenerId, "IX_MoviePlaylists_UserListenerId");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.UserListener).WithMany(p => p.MoviePlaylists).HasForeignKey(d => d.UserListenerId);

                entity.HasMany(d => d.Movies).WithMany(p => p.MoviePlaylists)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieMoviePlaylist",
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                        l => l.HasOne<MoviePlaylist>().WithMany().HasForeignKey("MoviePlaylistsId"),
                        j =>
                        {
                            j.HasKey("MoviePlaylistsId", "MoviesId");
                            j.ToTable("MovieMoviePlaylist");
                            j.HasIndex(new[] { "MoviesId" }, "IX_MovieMoviePlaylist_MoviesId");
                        });
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasIndex(e => e.UserListenerId, "IX_Playlists_UserListenerId");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.UserListener).WithMany(p => p.Playlists).HasForeignKey(d => d.UserListenerId);

                entity.HasMany(d => d.Songs).WithMany(p => p.Playlists)
                    .UsingEntity<Dictionary<string, object>>(
                        "PlaylistSong",
                        r => r.HasOne<Song>().WithMany().HasForeignKey("SongsId"),
                        l => l.HasOne<Playlist>().WithMany().HasForeignKey("PlaylistsId"),
                        j =>
                        {
                            j.HasKey("PlaylistsId", "SongsId");
                            j.ToTable("PlaylistSong");
                            j.HasIndex(new[] { "SongsId" }, "IX_PlaylistSong_SongsId");
                        });
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.HasIndex(e => e.OnAirPlaylistId, "IX_Radios_OnAirPlaylistId");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.OnAirPlaylist).WithMany(p => p.Radios).HasForeignKey(d => d.OnAirPlaylistId);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasIndex(e => e.AlbumId, "IX_Songs_AlbumId");

                entity.Property(e => e.Genre).HasMaxLength(50);
                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Album).WithMany(p => p.Songs).HasForeignKey(d => d.AlbumId);
            });

            modelBuilder.Entity<UserListener>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
