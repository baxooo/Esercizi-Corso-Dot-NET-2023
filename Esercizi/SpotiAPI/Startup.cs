using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SpotiAPI.Models;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;
using System;
using SpotiAPI.Interfaces;
using SpotiAPI.Models.ModelsDTO;
using SpotiAPI.Repositories;

namespace SpotiAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var logger = Log.Logger = new LoggerConfiguration()
                    .ReadFrom
                    .Configuration(Configuration)
                    .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(logger);
            });

            services.AddDbContext<SpotifyContext>(o =>   o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))     /* o.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection"))*/);
            services.AddControllers();

            //services.AddTransient<IPlaylistsRepository<Playlist, PlaylistDTO>,GenericPlaylistRepository<Playlist, PlaylistDTO>>();
            //services.AddTransient<IPlaylistsRepository<MoviePlaylist, MoviePlaylistDTO>, GenericPlaylistRepository<MoviePlaylist, MoviePlaylistDTO>>();
            services.AddTransient<IBasicRepository<ArtistDTO>, ArtistRepository>();
            //services.AddTransient<IBasicRepository<MovieDTO>, GenericBasicRepository<Movie, MovieDTO>>();
            services.AddTransient<IBasicRepository<AlbumDTO>, AlbumRepository>();
            services.AddTransient<IBasicRepository<RadioDTO>, RadioRepository>();
            //services.AddTransient<IBasicRepository<SongDTO>, GenericBasicRepository<Song, SongDTO>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpotiAPI", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpotiAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
