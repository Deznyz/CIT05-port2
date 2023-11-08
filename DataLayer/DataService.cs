using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using DataLayer.Models;
using DataLayer.PostgresModels;
using Microsoft.EntityFrameworkCore;


namespace DataLayer;

public class DataService : IDataService
{
    /*-------------------------------------------------------------------------------
                                         ------Aliases------
    ---------------------------------------------------------------------------------*/
    public (IList<Aliases>, int count) GetAliases(int page, int pageSize)
    {
        var db = new PostgresDB();
        //var result = db.Aliases.ToList();
        //return result;

        var aliases = db.Aliases.Skip(page*pageSize).Take(pageSize).ToList();
        return (aliases, db.Aliases.Count());
    }

    public (IList<Aliases>, int count) GetAliases(string titleId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.Aliases.Where(x => x.TitleId == titleId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.Aliases.Count());
    }

    public Aliases? GetAlias(string titleId, int? ordering)
    {
        var db = new PostgresDB();
        var result = db.Aliases.Where(x => x.Ordering == ordering).FirstOrDefault(x => x.TitleId == titleId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }



    public Aliases CreateAliases(Aliases newAlias)
    {
        using var db = new PostgresDB();
       
        db.Add(newAlias);
        db.SaveChanges();
        return newAlias;
    }

    public bool DeleteAliases(Aliases alias)
    {
        var db = new PostgresDB();
        var l = db.Aliases.Where(x => x.TitleId == alias.TitleId).ToList();
        var deleteAlias = db.Aliases
            .FirstOrDefault(x => x.TitleId == alias.TitleId && x.Ordering == alias.Ordering);
        if (deleteAlias != null)
        {
            //db.Aliases.Update
            db.Aliases.Remove(alias);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    public bool UpdateAliases(string titleId, int ordering, Aliases updateInfo)
    {
        var db = new PostgresDB();
        var alias = db.Aliases.FirstOrDefault(x => x.TitleId == titleId && x.Ordering == ordering);
        if (alias != null)
        {
            if (updateInfo.TitleId != null){
                alias.TitleId = updateInfo.TitleId;
            }
            if (updateInfo.Ordering != null)
            {
                alias.Ordering = updateInfo.Ordering;
            }
            if (updateInfo.Title != null)
            {
                alias.Title = updateInfo.Title;
            }
            if (updateInfo.Region != null)
            {
                alias.Region = updateInfo.Region;
            }
            if (updateInfo.Language != null)
            {
                alias.Language = updateInfo.Language;
            }
            if (updateInfo.IsOriginalTitle != null)
            {
                alias.IsOriginalTitle = updateInfo.IsOriginalTitle;
            }
            if (updateInfo.Types != null)
            {
                alias.Types = updateInfo.Types;
            }
            if (updateInfo.Attributes != null)
            {
                alias.Attributes = updateInfo.Attributes;
            }
            db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }

    }

    /*-------------------------------------------------------------------------------
                                    ------BookmarksName------
    ---------------------------------------------------------------------------------*/
    public (IList<BookmarksName>, int count) GetBookmarksName(int page, int pageSize)
    {
        var db = new PostgresDB();
        //var result = db.Aliases.ToList();
        //return result;

        var bookmarksName = db.BookmarksNames.Skip(page * pageSize).Take(pageSize).ToList();
        return (bookmarksName, db.BookmarksNames.Count());
    }

    public (IList<BookmarksName>, int count) GetBookmarksName(int userId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.BookmarksNames.Where(x => x.UserId == userId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.BookmarksNames.Count());
    }

    public BookmarksName? GetSpecificBookmarksName(int userId, string nameId)
    {
        var db = new PostgresDB();
        var result = db.BookmarksNames.FirstOrDefault(x => x.UserId == userId && x.NameId == nameId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public BookmarksName CreateBookmarksName(BookmarksName newBookmarksName)
    {
        using var db = new PostgresDB();

        var UserId = newBookmarksName.UserId;
        var nameId = newBookmarksName.NameId;

        db.Database.ExecuteSqlInterpolated($"select CreateBookmarkTitle({UserId}, {nameId})");

        db.SaveChanges();

        return newBookmarksName;

    }

    public bool DeleteBookmarksName(BookmarksName bookmarksName)
    {
        var db = new PostgresDB();
        var deleteBookmarksName = db.BookmarksNames
            .FirstOrDefault(x => x.UserId == bookmarksName.UserId
                            && x.NameId == bookmarksName.NameId);


        if (deleteBookmarksName != null)
        {
            db.Database.ExecuteSqlInterpolated($"select DeleteBookmarkName({bookmarksName.UserId}, {bookmarksName.NameId})");
            return db.SaveChanges() > 0;
        }
        return false;
    }



    /*-------------------------------------------------------------------------------
                                    ------BookmarksTitle------
    ---------------------------------------------------------------------------------*/
    public (IList<BookmarksTitle>, int count) GetBookmarksTitles(int page, int pageSize)
    {
        var db = new PostgresDB();
        //var result = db.Aliases.ToList();
        //return result;

        var bookmarksTitle = db.BookmarksTitles.Skip(page * pageSize).Take(pageSize).ToList();
        return (bookmarksTitle, db.BookmarksTitles.Count());
    }

    public (IList<BookmarksTitle>, int count) GetBookmarksTitles(int userId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.BookmarksTitles.Where(x => x.UserId == userId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.BookmarksTitles.Count());
    }

    public BookmarksTitle? GetSpecificBookmarksTitle(int userId, string titleId)
    {
        var db = new PostgresDB();
        var result = db.BookmarksTitles.FirstOrDefault(x => x.UserId == userId && x.TitleId == titleId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public BookmarksTitle CreateBookmarksTitle(BookmarksTitle newBookmarksTitle)
    {
        using var db = new PostgresDB();

        var UserId = newBookmarksTitle.UserId;
        var titleId = newBookmarksTitle.TitleId;


        db.Database.ExecuteSqlInterpolated($"select CreateBookmarkTitle({UserId}, {titleId})");

        var category = db.BookmarksTitles.Find(UserId, titleId);

        Console.WriteLine($"{UserId}, {titleId}");


        db.SaveChanges();
        return newBookmarksTitle;
    }

    public bool DeleteBookmarksTitle(BookmarksTitle bookmarksTitle)
    {
        var db = new PostgresDB();
        var deleteBookmarksTitle = db.BookmarksTitles
            .FirstOrDefault(x => x.UserId == bookmarksTitle.UserId
                            && x.TitleId == bookmarksTitle.TitleId);


        if (deleteBookmarksTitle != null)
        {
            db.Database.ExecuteSqlInterpolated($"select DeleteBookmarkTitle({bookmarksTitle.UserId}, {bookmarksTitle.UserId})");
            return db.SaveChanges() > 0;
        }
        return false;
    }


    /*-------------------------------------------------------------------------------
                                    ------EpisodeBelongsTo------
    ---------------------------------------------------------------------------------*/
    public (IList<EpisodeBelongsTo>, int count) GetEpisodeBelongsTos(int page, int pageSize)
    {
        var db = new PostgresDB();

        var episodeBelongsTos = db.EpisodeBelongsTos.Skip(page * pageSize).Take(pageSize).ToList();
        return (episodeBelongsTos, db.EpisodeBelongsTos.Count());
    }

    public (IList<EpisodeBelongsTo>, int count) GetEpisodeBelongsTosByParentTvShowTitleId(string parentTvShowTitleId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.EpisodeBelongsTos.Where(x => x.ParentTvShowTitleId == parentTvShowTitleId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.EpisodeBelongsTos.Count());
    }

    public EpisodeBelongsTo? GetEpisodeBelongsToParentTvShowId(string episodeTitleId)
    {
        var db = new PostgresDB();
        var result = db.EpisodeBelongsTos.FirstOrDefault(x => x.ParentTvShowTitleId == episodeTitleId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public EpisodeBelongsTo? GetEpisodeBelongsTo(string episodeTitleId, string parentTvShowTitleId)
    {
        var db = new PostgresDB();
        var result = db.EpisodeBelongsTos.FirstOrDefault(x => x.EpisodeTitleId == episodeTitleId && x.ParentTvShowTitleId == parentTvShowTitleId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public EpisodeBelongsTo CreateEpisodeBelongsTo(EpisodeBelongsTo newEpisodeBelongsTo)
    {
        using var db = new PostgresDB();
        db.Add(newEpisodeBelongsTo);
        db.SaveChanges();
        return newEpisodeBelongsTo;
    }

    public bool DeleteEpisodeBelongsTo(EpisodeBelongsTo episodeBelongsTo)
    {
        var db = new PostgresDB();
        var deleteEpisodeBelongsTo = db.EpisodeBelongsTos
            .FirstOrDefault(x => x.EpisodeTitleId == episodeBelongsTo.EpisodeTitleId
                            && x.ParentTvShowTitleId == episodeBelongsTo.ParentTvShowTitleId);


        if (deleteEpisodeBelongsTo != null)
        {
            db.EpisodeBelongsTos.Remove(deleteEpisodeBelongsTo);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    /*-------------------------------------------------------------------------------
                                    ------Frontend------
    ---------------------------------------------------------------------------------*/
    public (IList<Frontend>, int count) GetFrontends(int page, int pageSize)
    {
        var db = new PostgresDB();

        var frontends = db.Frontends.Skip(page * pageSize).Take(pageSize).ToList();
        return (frontends, db.Frontends.Count());
    }

    public (IList<Frontend>, int count) GetFrontendsByTitleId(string titleId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.Frontends.Where(x => x.TitleId == titleId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.Frontends.Count());
    }

    public Frontend? GetFrontend(string titleId, string poster)
    {
        var db = new PostgresDB();
        var result = db.Frontends.FirstOrDefault(x => x.TitleId == titleId && x.Poster == poster);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public Frontend CreateFrontend(Frontend newFrontend)
    {
        using var db = new PostgresDB();
        db.Add(newFrontend);
        db.SaveChanges();
        return newFrontend;
    }

    public bool DeleteFrontend(Frontend frontend)
    {
        var db = new PostgresDB();
        var deleteFrontend = db.Frontends
            .FirstOrDefault(x => x.TitleId == frontend.TitleId
                            && x.Poster == frontend.Poster);


        if (deleteFrontend != null)
        {
            db.Frontends.Remove(deleteFrontend);
            return db.SaveChanges() > 0;
        }
        return false;
    }


    /*-------------------------------------------------------------------------------
                                    ------Genres------
    ---------------------------------------------------------------------------------*/
    public (IList<Genres>, int count) GetGenres(int page, int pageSize)
    {
        var db = new PostgresDB();

        var genres = db.Genres.Skip(page * pageSize).Take(pageSize).ToList();
        return (genres, db.Genres.Count());
    }

    public (IList<Genres>, int count) GetGenres(string titleId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.Genres.Where(x => x.TitleId == titleId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.Genres.Count());
    }

    public Genres? GetGenre(string titleId, string genre)
    {
        var db = new PostgresDB();
        var result = db.Genres.Where(x => x.Genre == genre).FirstOrDefault(x => x.TitleId == titleId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }



    public Genres CreateGenres(Genres newGenre)
    {
        using var db = new PostgresDB();
        db.Add(newGenre);
        db.SaveChanges();
        return newGenre;
    }

    public bool DeleteGenres(Genres genre)
    {
        var db = new PostgresDB();
        var deleteGenre = db.Genres
            .FirstOrDefault(x => x.TitleId == genre.TitleId && x.Genre == genre.Genre);
        if (genre != null)
        {
            db.Genres.Remove(genre);
            return db.SaveChanges() > 0;
        }
        return false;
    }


    /*-------------------------------------------------------------------------------
                                    ------KnownFor------
    ---------------------------------------------------------------------------------*/
    public (IList<KnownFor>, int count) GetKnownFors(int page, int pageSize)
    {
        var db = new PostgresDB();

        var knownFor = db.KnownFors.Skip(page * pageSize).Take(pageSize).ToList();
        return (knownFor, db.Genres.Count());
    }

    public (IList<KnownFor>, int count) GetKnownFors(string titleId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.KnownFors.Where(x => x.TitleId == titleId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.Genres.Count());
    }

    public KnownFor? GetKnownFor(string titleId, string nameId)
    {
        var db = new PostgresDB();
        var result = db.KnownFors.Where(x => x.NameId == nameId).FirstOrDefault(x => x.TitleId == titleId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public KnownFor CreateKnownFor(KnownFor newKnownFor)
    {
        using var db = new PostgresDB();
        db.Add(newKnownFor);
        db.SaveChanges();
        return newKnownFor;
    }

    public bool DeleteKnownFor(KnownFor knownfor)
    {
        var db = new PostgresDB();
        var DeleteKnownFor = db.KnownFors
            .FirstOrDefault(x => x.TitleId == knownfor.TitleId && x.NameId == knownfor.NameId);
        if (knownfor != null)
        {
            db.KnownFors.Remove(knownfor);
            return db.SaveChanges() > 0;
        }
        return false;
    }


    /*-------------------------------------------------------------------------------
                                    ------MovieRating------
    ---------------------------------------------------------------------------------*/
    public (IList<MovieRatings>, int count) GetMovieRatings(int page, int pageSize)
    {
        var db = new PostgresDB();

        var movieRatings = db.MoviesRatings.Skip(page * pageSize).Take(pageSize).ToList();
        return (movieRatings, db.MoviesRatings.Count());
    }


    public MovieRatings? GetMovieRating(string MovieRatingId)
    {
        var db = new PostgresDB();
        var result = db.MoviesRatings.FirstOrDefault(x => x.TitleId == MovieRatingId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public MovieRatings CreateMovieRating(MovieRatings movieRating)
    {
        using var db = new PostgresDB();
        db.Add(movieRating);
        db.SaveChanges();
        return movieRating;
    }

    public bool DeleteMovieRating(MovieRatings movieRating)
    {
        var db = new PostgresDB();
        var DeletemovieRating = db.MoviesRatings
            .FirstOrDefault(x => x.TitleId == movieRating.TitleId);
        if (movieRating != null)
        {
            db.MoviesRatings.Remove(movieRating);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    /*-------------------------------------------------------------------------------
                                    ------MovieTitles------
    ---------------------------------------------------------------------------------*/
    public (IList<MovieTitles>, int count) GetMovieTitles(int page, int pageSize)
    {
        var db = new PostgresDB();

        var movieTitles = db.MoviesTitles.Skip(page * pageSize).Take(pageSize).ToList();
        return (movieTitles, db.MoviesTitles.Count());
    }


    public MovieTitles? GetMovieTitle(string MovieTitleId)
    {
        var db = new PostgresDB();
        var result = db.MoviesTitles.FirstOrDefault(x => x.TitleId == MovieTitleId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public MovieTitles CreateMovieTitle(MovieTitles movieTitle)
    {
        using var db = new PostgresDB();
        db.Add(movieTitle);
        db.SaveChanges();
        return movieTitle;
    }

    public bool DeleteMovieTitle(MovieTitles movieTitles)
    {
        var db = new PostgresDB();
        var DeletemovieRating = db.MoviesTitles
            .FirstOrDefault(x => x.TitleId == movieTitles.TitleId);
        if (movieTitles != null)
        {
            db.MoviesTitles.Remove(movieTitles);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    /*-------------------------------------------------------------------------------
                                    ------Names------
    ---------------------------------------------------------------------------------*/
    public (IList<Names>, int count) GetNames(int page, int pageSize)
    {
        var db = new PostgresDB();

        var names = db.Names.Skip(page * pageSize).Take(pageSize).ToList();
        return (names, db.Names.Count());
    }


    public Names? GetName(string nameId)
    {
        var db = new PostgresDB();
        var result = db.Names.FirstOrDefault(x => x.NameId == nameId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public Names CreateName(Names name)
    {
        using var db = new PostgresDB();
        db.Add(name);
        db.SaveChanges();
        return name;
    }

    public bool DeleteName(Names name)
    {
        var db = new PostgresDB();
        var DeletemovieRating = db.Names
            .FirstOrDefault(x => x.NameId == name.NameId);
        if (name != null)
        {
            db.Names.Remove(name);
            return db.SaveChanges() > 0;
        }
        return false;
    }



    /*-------------------------------------------------------------------------------
                                    ------DB functions------
    ---------------------------------------------------------------------------------*/

    //D6
    public (IList<CoActors>, int count) GetCoActors(string givenName, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.CoActors
            .FromSqlInterpolated($"select * from get_co_actors({givenName})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var totalCount = db.CoActors
            .FromSqlInterpolated($"select * from get_co_actors({givenName})")
            .Count();

        return (query, totalCount);
    }
}
