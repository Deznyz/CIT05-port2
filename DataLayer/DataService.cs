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



}
