using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Spotify; User id = sa ; password = Password.123;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__Album__ArtistId__398D8EEE");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.MoviePlaylist)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.MoviePlaylistId)
                    .HasConstraintName("FK__Movie__MoviePlay__3E52440B");
            });

            modelBuilder.Entity<MoviePlaylist>(entity =>
            {
                entity.ToTable("MoviePlaylist");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("Playlist");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Radio>(entity =>
            {
                entity.ToTable("Radio");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK__Song__AlbumId__45F365D3");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__Song__ArtistId__44FF419A");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.PlaylistId)
                    .HasConstraintName("FK__Song__PlaylistId__46E78A0C");
            });

            modelBuilder.Entity<UserListener>(entity =>
            {
                entity.ToTable("UserListener");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
