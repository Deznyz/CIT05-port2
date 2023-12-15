using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using DataLayer.Models;
using DataLayer.PostgresModels;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DataLayer;

public class DataService : IDataService
{

    /*-------------------------------------------------------------------------------
                                         ------Aliases------
    ---------------------------------------------------------------------------------*/

    public (IList<Aliases>, int count) GetAliases(int page, int pageSize)
    {
        var db = new PostgresDB();
        var aliases = db.Aliases.Skip(page * pageSize).Take(pageSize).ToList();
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
        var deleteAlias = db.Aliases
            .FirstOrDefault(x => x.TitleId == alias.TitleId && x.Ordering == alias.Ordering);
        if (deleteAlias != null)
        {
            //db.Aliases.Update
            db.Aliases.Remove(deleteAlias);
            return db.SaveChanges() > 0;
        }
        return false;
    }


    public bool UpdateAliases(string titleId, int ordering, Aliases updateInfo)
    {
        var db = new PostgresDB();
        var alias = db.Aliases
            .FirstOrDefault(x => x.TitleId == titleId && x.Ordering == ordering);
        if (alias != null)
        {

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
                                    ------Genres------
    ---------------------------------------------------------------------------------*/

    public (IList<Genres>, int count) GetGenres(int page, int pageSize)
    {
        var db = new PostgresDB();
        //var result = db.Aliases.ToList();
        //return result;

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
        var l = db.Genres.Where(x => x.TitleId == genre.TitleId).ToList();
        var deleteGenre = db.Genres
            .FirstOrDefault(x => x.TitleId == genre.TitleId && x.Genre == genre.Genre);
        if (genre != null)
        {
            //db.Aliases.Update
            db.Genres.Remove(genre);
            return db.SaveChanges() > 0;
        }
        return false;
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

    public BookmarksName GetSpecificBookmarksName(int userId, string nameId)
    {
        var db = new PostgresDB();
        var result = db.BookmarksNames.FirstOrDefault(x => x.UserId == userId && x.NameId == nameId);
        return result;
    }

    public BookmarksName CreateBookmarksName(BookmarksName newBookmarksName)
    {
        using var db = new PostgresDB();
        db.Add(newBookmarksName);
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
            db.BookmarksNames.Remove(deleteBookmarksName);
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
        return (knownFor, db.KnownFors.Count());
    }

    public (IList<KnownFor>, int count) GetKnownForTitle(string titleId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.KnownFors.Where(x => x.TitleId == titleId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.KnownFors.Count());
    }

    public (IList<KnownFor>, int count) GetKnownForName(string nameId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.KnownFors.Where(x => x.NameId == nameId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.KnownFors.Where(x => x.NameId == nameId).Count());
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
                                    ------BookmarksTitle------
    ---------------------------------------------------------------------------------*/
    public (IList<BookmarksTitle>, int count) GetBookmarksTitles(int page, int pageSize)

    {
        var db = new PostgresDB();
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
        db.Add(newBookmarksTitle);
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
            db.BookmarksTitles.Remove(deleteBookmarksTitle);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    /*-------------------------------------------------------------------------------
                                    ------MovieRatings------
    ---------------------------------------------------------------------------------*/
    public (IList<MovieRatings>, int count) GetMovieRatings(int page, int pageSize)
    {
        var db = new PostgresDB();
        var movieRatings = db.MoviesRatings.Where(x => x.NumVotes>10000).OrderByDescending(p => p.AverageRating ?? double.MinValue).Skip(page * pageSize).Take(pageSize).ToList();
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
            //db.Aliases.Update
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
        var movieTitles = db.MoviesTitles.Skip(page * pageSize).Take(pageSize).OrderBy(p => p.MovieRatings).ToList();
        return (movieTitles, db.MoviesTitles.Count());
    }


    public MovieTitles GetMovieTitle(string movieTitleId)
    {
        var db = new PostgresDB();
        var result = db.MoviesTitles.FirstOrDefault(x => x.TitleId == movieTitleId);
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

        var names = db.Names.OrderByDescending(p => p.AvgNameRating ?? double.MinValue).Skip(page * pageSize).Take(pageSize).ToList();
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

    public bool UpdateEpisodeBelongsTo(string episodeTitleId, string parentTvShowTitleId, EpisodeBelongsTo updateInfo)
    {
        var db = new PostgresDB();
        var episodeBelongsTo = db.EpisodeBelongsTos
            .FirstOrDefault(x => x.EpisodeTitleId == episodeTitleId
                        && x.ParentTvShowTitleId == parentTvShowTitleId);
        if (episodeBelongsTo != null)
        {
            if (updateInfo.EpisodeTitleId != null)
            {
                episodeBelongsTo.EpisodeTitleId = updateInfo.EpisodeTitleId;
            }
            if (updateInfo.ParentTvShowTitleId != null)
            {
                episodeBelongsTo.ParentTvShowTitleId = updateInfo.ParentTvShowTitleId;
            }
            if (updateInfo.SeasonNumber != null)
            {
                episodeBelongsTo.SeasonNumber = updateInfo.SeasonNumber;
            }
            if (updateInfo.EpisodeNumber != null)
            {
                episodeBelongsTo.EpisodeNumber = updateInfo.EpisodeNumber;
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
                                   ------NameWorkedAs------
   ---------------------------------------------------------------------------------*/

    public (IList<NameWorkedAs>, int count) GetNameWorkedAs(int page, int pageSize)
    {
        var db = new PostgresDB();

        var nameWorkedAs = db.NameWorkedAs.Skip(page * pageSize).Take(pageSize).ToList();
        return (nameWorkedAs, db.NameWorkedAs.Count());
    }

    public (IList<NameWorkedAs>, int count) GetNameWorkedAsByNameId(string nameId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.NameWorkedAs.Where(x => x.NameId == nameId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.NameWorkedAs.Count());
    }

    public NameWorkedAs? GetSpecificNameWorkedAs(string nameId, string? profession)
    {
        var db = new PostgresDB();
        var result = db.NameWorkedAs.Where(x => x.NameId == nameId).FirstOrDefault(x => x.Profession == profession);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public NameWorkedAs CreateNameWorkedAs(NameWorkedAs newNameWorkedas)
    {
        using var db = new PostgresDB();
        db.Add(newNameWorkedas);
        db.SaveChanges();
        return newNameWorkedas;
    }

    public bool DeleteNameworkedAs(NameWorkedAs nameWorkedAs)
    {
        var db = new PostgresDB();
        var deleteNameworkedAs = db.NameWorkedAs
            .FirstOrDefault(x => x.NameId == nameWorkedAs.NameId && x.Profession == nameWorkedAs.Profession);
        if (nameWorkedAs != null)
        {
            db.NameWorkedAs.Remove(nameWorkedAs);
            return db.SaveChanges() > 0;
        }
        return false;
    }


    public bool UpdateNameWorkedAs(string nameId, NameWorkedAs updateInfo)
    {
        var db = new PostgresDB();
        var nameWorkedAs = db.NameWorkedAs
            .FirstOrDefault(x => x.NameId == nameId);
        if (nameWorkedAs != null)
        {

            if (updateInfo.NameId != null)
            {
                nameWorkedAs.NameId = updateInfo.NameId;
            }
            if (updateInfo.Profession != null)
            {
                nameWorkedAs.Profession = updateInfo.Profession;
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
                                   ------Principals------
   ---------------------------------------------------------------------------------*/
    public (IList<Principals>, int count) GetPrincipals(int page, int pageSize)
    {
        var db = new PostgresDB();
        var principals = db.Principals.Skip(page * pageSize).Take(pageSize).ToList();

        return (principals, db.Principals.Count());
    }

    public Principals? GetPrincipal(int principalsId)
    { 
        var db = new PostgresDB();
    var result = db.Principals.FirstOrDefault(x => x.PrincipalsId == principalsId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }


    public Principals CreatePrincipals(Principals principals)
    {
        using var db = new PostgresDB();

        db.Add(principals);
        db.SaveChanges();
        return principals;
    }

    public bool DeletePrincipals(Principals principals)
    {
        var db = new PostgresDB();
        var DeletePrincipals = db.Principals
            .FirstOrDefault(x => x.PrincipalsId == principals.PrincipalsId);
        if (principals != null)
        {
            db.Principals.Remove(principals);

            return db.SaveChanges() > 0;
        }
        return false;
    }

    public bool UpdatePrincipals(int principalsId, Principals updateInfo)
    {
        var db = new PostgresDB();
        var principals = db.Principals
            .FirstOrDefault(x => x.PrincipalsId == principalsId);
        if (principals != null)
        {

            if (updateInfo.PrincipalsId != null)
            {
                principals.PrincipalsId = updateInfo.PrincipalsId;
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

    public bool UpdateFrontend(string titleId, string poster, Frontend updateInfo)
    {
        var db = new PostgresDB();
        var frontend = db.Frontends
            .FirstOrDefault(x => x.TitleId == titleId
                        && x.Poster == poster);
        if (frontend != null)
        {
            if (updateInfo.Plot != null)
            {
                frontend.Plot = updateInfo.Plot;
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
                                    ------SearchHistory------
    ---------------------------------------------------------------------------------*/


    public (IList<SearchHistory>, int count) GetSearchHistory(int page, int pageSize)
    {
        var db = new PostgresDB();
        var searchHistory = db.SearchHistories.Skip(page * pageSize).Take(pageSize).ToList();

        return (searchHistory, db.SearchHistories.Count());
    }

    public (IList<SearchHistory>, int count) GetSearchHistory(int searchHistoryId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.SearchHistories.Where(x => x.SearchHistoryId == searchHistoryId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.SearchHistories.Count());

    }

    public SearchHistory? GetSearchHistoryId(int searchHistoryId, int userId)
    {
        var db = new PostgresDB();
        var result = db.SearchHistories.Where(x => x.SearchHistoryId == searchHistoryId).FirstOrDefault(x => x.UserId == userId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }

    }


    public SearchHistory CreateSearchHistory(SearchHistory searchHistory)
    {
        using var db = new PostgresDB();

        db.Add(searchHistory);
        db.SaveChanges();
        return searchHistory;
    }

    public bool DeleteSearchHistory(SearchHistory searchHistory)
    {
        var db = new PostgresDB();
        var DeleteSearchHistory = db.SearchHistories
            .FirstOrDefault(x => x.SearchHistoryId == searchHistory.SearchHistoryId);
        if (searchHistory != null)
        {
            db.SearchHistories.Remove(searchHistory);
            return db.SaveChanges() > 0;
        }
        return false;
    }
    
    
    public bool UpdateSearchHistory(int searchHistoryId, SearchHistory updateInfo)
    {
        var db = new PostgresDB();
        var searchHistory = db.SearchHistories
            .FirstOrDefault(x => x.SearchHistoryId == searchHistoryId);
        if (searchHistory != null)
        {

            if (updateInfo.SearchHistoryId != null)
            {
                searchHistory.SearchHistoryId = updateInfo.SearchHistoryId;
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
                                    ------UserRating------
    ---------------------------------------------------------------------------------*/
    public (IList<UserRatings>, int count) GetUserRatings(int page, int pageSize)
    {
        var db = new PostgresDB();

        var userRatings = db.UserRatings.Skip(page * pageSize).Take(pageSize).ToList();
        return (userRatings, db.UserRatings.Count());
    }

    public (IList<UserRatings>, int count) GetUserRatings(int? userId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.UserRatings.Where(x => x.UserId == userId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.UserRatings.Count());
    }

    public UserRatings? GetUserRatings(int userId, string? titleId)
    {
        var db = new PostgresDB();
        var result = db.UserRatings.Where(x => x.UserId == userId).FirstOrDefault(x => x.TitleId == titleId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public bool UpdateUserRating(int userId, string titleId, UserRatings updateInfo)
    {
        var db = new PostgresDB();
        var userRatings = db.UserRatings
            .FirstOrDefault(x => x.UserRating == userId);
        if (userRatings != null)
        {

            if (updateInfo.UserId != null)
            {
                userRatings.UserId = updateInfo.UserId;
            }
            db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public UserRatings CreateUserRatings(UserRatings newUserRating)
    {
        using var db = new PostgresDB();
        db.Add(newUserRating);
        db.SaveChanges();
        return newUserRating;
    }

    public bool DeleteUserRatings(UserRatings userRatings)
    {
        var db = new PostgresDB();
        var l = db.UserRatings.Where(x => x.UserId == userRatings.UserId).ToList();
        var deleteUserRatings = db.UserRatings
            .FirstOrDefault(x => x.UserId == userRatings.UserId && x.TitleId == userRatings.TitleId);
        if (userRatings != null)
        {
            db.UserRatings.Remove(userRatings);
            return db.SaveChanges() > 0;
        }
        return false;
    }
    
    
    
    /*-------------------------------------------------------------------------------
                                    ------Users------
    ---------------------------------------------------------------------------------*/
    public (IList<Users>, int count) GetUsers(int page, int pageSize)
    {
        var db = new PostgresDB();
        var users = db.Users.Skip(page * pageSize).Take(pageSize).ToList();

        return (users, db.Users.Count());
    }

    public Users? GetUsers(int userId)
    {
        var db = new PostgresDB();
        var result = db.Users.FirstOrDefault(x => x.UserId == userId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    public bool UpdateUser(int userId, Users updateInfo)
    {
        var db = new PostgresDB();
        var user = db.Users
            .FirstOrDefault(x => x.UserId == userId);
        if (user != null)
        {

            if (updateInfo.UserId != null)
            {
                user.UserId = updateInfo.UserId;
            }
            db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public Users CreateUsers(Users users)
    {
        using var db = new PostgresDB();

        db.Add(users);
        db.SaveChanges();
        return users;
    }

    public Users CreateUser(Users user)
    {
        using var db = new PostgresDB();

        var newUser = new Users
        {
            UserName = user.UserName,
            Password = user.Password
        };

        try
        {
            db.Add(newUser);
            db.SaveChanges();
            return newUser;
        }
        catch (DbUpdateException ex)
        {
            // tjekker om inner exception er en unique constraint violation
            if (ex.InnerException is PostgresException postgresException &&
                postgresException.SqlState == "23505") // 23505 er koden for unique violation i PostgreSQL
            {
                // vi kaster InvalidOperationException med en sigende besked, der er brugervenlig
                throw new InvalidOperationException($"En bruger findes allerede med følgende brugernavn {newUser.UserName}.");
            }

            // Hvis der ikke er tale om en unique constraint violation, rethrow'er vi den originale exception
            throw;
        }
    }

    public Users GetUserByUsername(string username)
    {
        using var db = new PostgresDB();

        var user = db.Users.FirstOrDefault(u => u.UserName == username);

        return user ?? throw new KeyNotFoundException($"Der findes ikke nogle brugere med brugernavn {username}");
    }

    public bool VerifyPassword(Users user, string providedPassword)
    {
        // todo: vi bør overveje at gøre brug af hashing her. Vi kan med fordel bruge PasswordHasher
        // man vil aldrig gemme plain text adgangskoder i produktion
        return user.Password == providedPassword;
    }

    public bool DeleteUsers(Users users)
    {
        var db = new PostgresDB();
        var DeleteUsers = db.Users
            .FirstOrDefault(x => x.UserId == users.UserId);
        if (users != null)
        {
            db.Users.Remove(users);
            return db.SaveChanges() > 0;
        }
        return false;
    }
    
   
    /*-------------------------------------------------------------------------------
                                    ------DB functions------
    ---------------------------------------------------------------------------------*/
    //D1
    public bool IsUsernameTaken(string username)
    {
        var db = new PostgresDB();
        var connection = db.Database.GetDbConnection();
        connection.Open();
        var cmd = new NpgsqlCommand();
        cmd.CommandText = $"select * from IsUsernameTaken('{username}')";
        cmd.Connection=(NpgsqlConnection)connection;
        var result = cmd.ExecuteScalar() as bool?;

        return result??false;
    }


    public bool CreateUser(string username, string password) {
        using var db = new PostgresDB();


        if (!IsUsernameTaken(username) && password != null)
        {
            var connection = db.Database.GetDbConnection();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.CommandText = $"select * from CreateUser('{username}', '{password}')";
            cmd.Connection = (NpgsqlConnection)connection;
            cmd.ExecuteScalar();
            return true;
        }
        return false;
    }

    public bool UpdateUserPassword(int id, string newPassword) {
        var db = new PostgresDB();
        var connection = db.Database.GetDbConnection();
        connection.Open();
        var cmd = new NpgsqlCommand();
        cmd.CommandText = $"select * from UpdateUserPassword('{id}', '{newPassword}')";
        cmd.Connection = (NpgsqlConnection)connection;
        var result = cmd.ExecuteScalar() as bool?;

        return result ?? false;
    }

    //D2
    public (IList<SearchTitleResult>, int count) SearchTitle(int userId, string queryString, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.SearchTitleResults
            .FromSqlInterpolated($"select * from SearchTitle({userId}, {queryString})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var totalCount = db.SearchTitleResults
            .FromSqlInterpolated($"select * from SearchTitle({userId}, {queryString})")
            .Count();

        return (query, totalCount);
    }


    //D4
    public (IList<StructuredStringSearch>, int count) GetStructuredStringSearch(string tconst, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.StructuredStringSearch
            .FromSqlInterpolated($"StructuredStringSearch")

            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
            
        var totalCount = db.StructuredStringSearch
            .FromSqlInterpolated($"StructuredStringSearch")
            .Count();

        return (query, totalCount);
    }

    //D5
    public (IList<NameSearchResult>, int count) NameSearch(string givenName, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.NameSearchResults
            .FromSqlInterpolated($"select * from name_search({givenName})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var totalCount = db.NameSearchResults
            .FromSqlInterpolated($"select * from name_search({givenName})")
            .Count();

        return (query, totalCount);
    }
    
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
    
    //D7
    public WeightedAverage GetWeightedAverage(string nameId)
    {
        using var db = new PostgresDB();

        var query = db.WeightedAverages
            .FromSqlInterpolated($"select * from get_weighted_average({nameId})").FirstOrDefault();

        return query;
    }

    //D8.1
    public (IList<CastRatingsMovieId>, int count) GetCastRatingsMovieId(string movieId, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.CastRatingsMovieIds
            .FromSqlInterpolated($"select * from get_cast_ratings_movie_id({movieId})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var totalCount = db.CastRatingsMovieIds
            .FromSqlInterpolated($"select * from get_cast_ratings_movie_id({movieId})")
            .Count();

        return (query, totalCount);
    }

    //D8.2
    public (IList<CastRatingsMovieTitles>, int count) GetCastRatingsMovieTitles(string movieTitle, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.CastRatingsMovieTitles
            .FromSqlInterpolated($"select * from get_cast_ratings_movie_title({movieTitle})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
            
        var totalCount = db.CastRatingsMovieTitles
            .FromSqlInterpolated($"select * from get_cast_ratings_movie_title({movieTitle})")  
            .Count();

        return (query, totalCount);
    }
           
    //D10
    public (IList<AssociatedWords>, int count) GetAssociatedWords(string titleId, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.AssociatedWords
            .FromSqlInterpolated($"SELECT * FROM associated_words({titleId})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var totalCount = db.AssociatedWords
            .FromSqlInterpolated($"SELECT * FROM associated_words({titleId})")
            .Count();

        return (query, totalCount);
    }

    //D11  skal rettes i
    public (IList<ExactSearch>, int count) GetExactSearch(string titleId, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.ExactSearch
            .FromSqlInterpolated($"SELECT wi.tconst, movie_titles.original_title({titleId})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var totalCount = db.ExactSearch
            .FromSqlInterpolated($"SELECT wi.tconst, movie_titles.original_title({titleId})")
            .Count();

        return (query, totalCount);

    }


        //D12
        public (IList<AssociatedTitle>, int count) GetAssociatedTitle(string titleId, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.AssociatedTitle
            .FromSqlInterpolated($"SELECT a.title_id, a.title, count(a.title_id) as number_of_matches({titleId})")
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var totalCount = db.AssociatedTitle
            .FromSqlInterpolated($"SELECT a.title_id, a.title, count(a.title_id) as number_of_matches({titleId})")
            .Count();

        return (query, totalCount);
    }

        public (IList<BestMatchSearch>, int count) GetBestMatchSearch(string searchString, int page, int pageSize)
    {
        using var db = new PostgresDB();

        var query = db.BestMatchSearch
    .FromSqlInterpolated($"SELECT * from best_match_search({searchString})")
    .Skip(page * pageSize)
    .Take(pageSize)
    .ToList();




        var totalCount = db.BestMatchSearch
            .FromSqlInterpolated($"SELECT * from best_match_search({searchString})")
            .Count();

        return (query, totalCount);
    }

}
