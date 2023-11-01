using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public class PostgresDB : DbContext
    {
        /*----------------
         -----DbSets------
         ---------------*/
        public DbSet<Models.Aliases> Aliases { get; set; }
        public DbSet<Models.BookmarksName> BookmarksNames { get; set; }
        public DbSet<Models.BookmarksTitle> BookmarksTitles { get; set; }
        public DbSet<Models.EpisodeBelongsTo> EpisodeBelongsTos { get; set; }
        public DbSet<Models.Frontend> Frontends { get; set; }
        public DbSet<Models.Genres> Genres { get; set; }
        public DbSet<Models.KnownFor> KnownFors { get; set; }
        public DbSet<Models.MovieRatings> MoviesRatings { get; set;}
        public DbSet<Models.MovieTitles> MoviesTitles { get; set; }
        public DbSet<Models.Names> Names { get; set; }
        public DbSet<Models.NameWorkedAs> NameWorkedAs { get; set; }
        public DbSet<Models.Principals> Principals { get; set; }
        public DbSet<Models.SearchHistory> SearchHistories { get; set; }
        public DbSet<Models.UserRatings> UserRatings { get; set; }
        public DbSet<Models.Users> Users { get; set; }
        public DbSet<Models.Wi> Wis { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder
                .LogTo(Console.Out.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseNpgsql("host=localhost;db=Portfolio1;uid=postgres;pwd=postgres");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*-------------------------------------------------------------------------------
                                         ------Aliases------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.Aliases>().ToTable("aliases");
            modelBuilder.Entity<Models.Aliases>().HasKey(x => new { x.TitleId, x.Ordering });
            modelBuilder.Entity<Models.Aliases>()
                .Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Models.Aliases>()
                .Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Models.Aliases>()
                .Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<Models.Aliases>()
                .Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<Models.Aliases>()
                .Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<Models.Aliases>()
                .Property(x => x.IsOriginalTitle).HasColumnName("is_original_title");
            modelBuilder.Entity<Models.Aliases>()
                .Property(x => x.Types).HasColumnName("types");
            modelBuilder.Entity<Models.Aliases>()
                .Property(x => x.Attributes).HasColumnName("attributes");




            /*-------------------------------------------------------------------------------
                                    ------BookmarksName------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.BookmarksName>().ToTable("bookmarks_name");
            modelBuilder.Entity<Models.BookmarksName>().HasKey(x => new { x.UserId, x.NameId });
            modelBuilder.Entity<Models.BookmarksName>()
                .Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Models.BookmarksName>()
                .Property(x => x.NameId).HasColumnName("name_id");



            /*-------------------------------------------------------------------------------
                                    ------BookmarksTitle------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.BookmarksTitle>().ToTable("bookmarks_title");
            modelBuilder.Entity<Models.BookmarksTitle>().HasKey(x => new { x.TitleId, x.UserId });
            modelBuilder.Entity<Models.BookmarksTitle>()
                .Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Models.BookmarksTitle>()
                .Property(x => x.TitleId).HasColumnName("title_id");



            /*-------------------------------------------------------------------------------
                                    ------EpisodeBelongsTo------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.EpisodeBelongsTo>().ToTable("episode_belongs_to");
            modelBuilder.Entity<Models.EpisodeBelongsTo>().HasKey(x => new { x.EpisodeTitleId, x.ParentTvShowTitleId });
            modelBuilder.Entity<Models.EpisodeBelongsTo>()
                .Property(x => x.EpisodeTitleId).HasColumnName("episode_title_id");
            modelBuilder.Entity<Models.EpisodeBelongsTo>()
                .Property(x => x.ParentTvShowTitleId).HasColumnName("parent_tv_show_title_id");
            modelBuilder.Entity<Models.EpisodeBelongsTo>()
                .Property(x => x.SeasonNumber).HasColumnName("season_number");
            modelBuilder.Entity<Models.EpisodeBelongsTo>()
                .Property(x => x.EpisodeNumber).HasColumnName("episode_number");



            /*-------------------------------------------------------------------------------
                                    ------Frontend------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.Frontend>().ToTable("frontend");
            modelBuilder.Entity<Models.Frontend>().HasKey(x => new { x.TitleId, x.Poster });
            modelBuilder.Entity<Models.Frontend>()
                .Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Models.Frontend>()
                .Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<Models.Frontend>()
                .Property(x => x.Plot).HasColumnName("plot");


            /*-------------------------------------------------------------------------------
                                    ------Genres------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.Genres>().ToTable("genres");
            modelBuilder.Entity<Models.Genres>().HasKey(x => new { x.TitleId, x.Genre });
            modelBuilder.Entity<Models.Genres>()
                .Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Models.Genres>()
                .Property(x => x.Genre).HasColumnName("genre");



            /*-------------------------------------------------------------------------------
                                    ------KnownFor------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.KnownFor>().ToTable("known_for");
            modelBuilder.Entity<Models.KnownFor>().HasKey(x => new { x.TitleId, x.NameId });
            modelBuilder.Entity<Models.KnownFor>()
                .Property(x => x.NameId).HasColumnName("name_id");
            modelBuilder.Entity<Models.KnownFor>()
                .Property(x => x.TitleId).HasColumnName("title_id");



            /*-------------------------------------------------------------------------------
                                    ------MovieRatings------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.MovieRatings>().ToTable("movie_ratings");
            modelBuilder.Entity<Models.MovieRatings>().HasKey(x => new { x.TitleId });
            
            modelBuilder.Entity<Models.MovieRatings>()
                .Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Models.MovieRatings>()
                .Property(x => x.AverageRating).HasColumnName("average_rating");
            modelBuilder.Entity<Models.MovieRatings>()
                .Property(x => x.NumVotes).HasColumnName("num_votes");
            modelBuilder.Entity<Models.MovieRatings>()
                .HasOne(rating => rating.MovieTitles)
                .WithOne(title => title.MovieRatings)  
                .HasForeignKey<Models.MovieRatings>(rating => rating.TitleId);


            /*-------------------------------------------------------------------------------
                                    ------MovieTitles------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.MovieTitles>().ToTable("movie_titles");
            modelBuilder.Entity<Models.MovieTitles>().HasKey(x => new { x.TitleId });
            modelBuilder.Entity<Models.MovieTitles>()
                .Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<Models.MovieTitles>()
                .Property(x => x.TitleType).HasColumnName("title_type");
            modelBuilder.Entity<Models.MovieTitles>()
                .Property(x => x.PrimaryTitle).HasColumnName("primary_title");
            modelBuilder.Entity<Models.MovieTitles>()
                .Property(x => x.OriginalTitle).HasColumnName("original_title");
            modelBuilder.Entity<Models.MovieTitles>()
                .Property(x => x.IsAdult).HasColumnName("is_adult");
            modelBuilder.Entity<Models.MovieTitles>()
                .Property(x => x.StartYear).HasColumnName("start_year");
            modelBuilder.Entity<Models.MovieTitles>()
                .Property(x => x.EndYear).HasColumnName("end_year");
            modelBuilder.Entity<Models.MovieTitles>()
                .Property(x => x.RuntimeMinutes).HasColumnName("runtime_minutes");



            /*-------------------------------------------------------------------------------
                                    ------Names------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.Names>().ToTable("names");
            modelBuilder.Entity<Models.Names>().HasKey(x => new { x.NameId });
            modelBuilder.Entity<Models.Names>()
                .Property(x => x.NameId).HasColumnName("name_id");
            modelBuilder.Entity<Models.Names>()
                .Property(x => x.Name).HasColumnName("name");
            modelBuilder.Entity<Models.Names>()
                .Property(x => x.BirthYear).HasColumnName("birth_year");
            modelBuilder.Entity<Models.Names>()
                .Property(x => x.DeathYear).HasColumnName("death_year");
            modelBuilder.Entity<Models.Names>()
                .Property(x => x.AvgNameRating).HasColumnName("avg_name_rating");


            /*-------------------------------------------------------------------------------
                                    ------NameWorkedAs------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity<Models.NameWorkedAs>().ToTable("name_worked_as");
            modelBuilder.Entity<Models.NameWorkedAs>().HasKey(x => new { x.NameId, x.Profession });
            modelBuilder.Entity<Models.NameWorkedAs>()
                .Property(x => x.NameId).HasColumnName("name_id");
            modelBuilder.Entity < Models.NameWorkedAs> ()
                .Property(x => x.Profession).HasColumnName("profession");



            /*-------------------------------------------------------------------------------
                                    ------Principals------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity < Models.Principals> ().ToTable("principals");
            modelBuilder.Entity<Models.Principals>().HasKey(x => new { x.PrincipalsId });
            modelBuilder.Entity<Models.Principals>()
                .Property(x => x.PrincipalsId).HasColumnName("principals_id");
            modelBuilder.Entity < Models.Principals> ()
                .Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity < Models.Principals> ()
                .Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity < Models.Principals> ()
                .Property(x => x.NameId).HasColumnName("name_id");
            modelBuilder.Entity < Models.Principals> ()
                .Property(x => x.JobCategory).HasColumnName("job_category");
            modelBuilder.Entity < Models.Principals> ()
                .Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity < Models.Principals> ()
                .Property(x => x.Role).HasColumnName("role");




            /*-------------------------------------------------------------------------------
                                    ------SearchHistory------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity < Models.SearchHistory> ().ToTable("search_history");
            modelBuilder.Entity<Models.SearchHistory>().HasKey(x => new { x.SearchHistoryId });
            modelBuilder.Entity < Models.SearchHistory> ()
                .Property(x => x.SearchHistoryId).HasColumnName("sh_id");
            modelBuilder.Entity < Models.SearchHistory> ()
                .Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity < Models.SearchHistory> ()
                .Property(x => x.Searched).HasColumnName("searched");



            /*-------------------------------------------------------------------------------
                                    ------UserRatings------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity < Models.UserRatings> ().ToTable("user_ratings");
            modelBuilder.Entity<Models.UserRatings>().HasKey(x => new { x.TitleId, x.UserId });
            modelBuilder.Entity < Models.UserRatings> ()
                .Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity < Models.UserRatings> ()
                .Property(x => x.UserRating).HasColumnName("user_rating");
            modelBuilder.Entity < Models.UserRatings> ()
                .Property(x => x.TitleId).HasColumnName("title_id");




            /*-------------------------------------------------------------------------------
                                    ------Users------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity < Models.Users> ().ToTable("users");
            modelBuilder.Entity<Models.Users>().HasKey(x => new { x.UserId });
            modelBuilder.Entity < Models.Users> ()
                .Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity < Models.Users> ()
                .Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity < Models.Users> ()
                .Property(x => x.Password).HasColumnName("password");




            /*-------------------------------------------------------------------------------
                                    ------Wi------
            ---------------------------------------------------------------------------------*/
            modelBuilder.Entity < Models.Wi> ().ToTable("wi");
            modelBuilder.Entity<Models.Wi>().HasKey(x => new { x.TitleId, x.Word, x.Field });
            modelBuilder.Entity < Models.Wi> ()
                .Property(x => x.TitleId).HasColumnName("tconst");
            modelBuilder.Entity < Models.Wi> ()
                .Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity < Models.Wi> ()
                .Property(x => x.Field).HasColumnName("field");
            modelBuilder.Entity < Models.Wi> ()
                .Property(x => x.Lexeme).HasColumnName("lexeme");
        }
    }
}
