using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataLayer;

public class DataService : IDataService
{

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
        //var newAlias = new Aliases
        //{
        //    TitleId = titleId,
        //    Ordering = ordering,
        //    Title = title,
        //    Region = region,
        //    Language = language,
        //    IsOriginalTitle = isOriginalTitle,
        //    Types = types,
        //    Attributes = attributes
        //};
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
        if (alias != null)
        {
            //db.Aliases.Update
            db.Aliases.Remove(alias);
            return db.SaveChanges() > 0;
        }
        return false;
    }
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
        //var newAlias = new Aliases
        //{
        //    TitleId = titleId,
        //    Ordering = ordering,
        //    Title = title,
        //    Region = region,
        //    Language = language,
        //    IsOriginalTitle = isOriginalTitle,
        //    Types = types,
        //    Attributes = attributes
        //};
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
    public (IList<KnownFor>, int count) GetKnownFors(int page, int pageSize)
    {
        var db = new PostgresDB();
        //var result = db.Aliases.ToList();
        //return result;

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
        //var newAlias = new Aliases
        //{
        //    TitleId = titleId,
        //    Ordering = ordering,
        //    Title = title,
        //    Region = region,
        //    Language = language,
        //    IsOriginalTitle = isOriginalTitle,
        //    Types = types,
        //    Attributes = attributes
        //};
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
            //db.Aliases.Update
            db.KnownFors.Remove(knownfor);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    public (IList<MovieRatings>, int count) GetMovieRatings(int page, int pageSize)
    {
        var db = new PostgresDB();
        //var result = db.Aliases.ToList();
        //return result;

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
        //var newAlias = new Aliases
        //{
        //    TitleId = titleId,
        //    Ordering = ordering,
        //    Title = title,
        //    Region = region,
        //    Language = language,
        //    IsOriginalTitle = isOriginalTitle,
        //    Types = types,
        //    Attributes = attributes
        //};
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

    public (IList<MovieTitles>, int count) GetMovieTitles(int page, int pageSize)
    {
        var db = new PostgresDB();
        //var result = db.Aliases.ToList();
        //return result;

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
        //var newAlias = new Aliases
        //{
        //    TitleId = titleId,
        //    Ordering = ordering,
        //    Title = title,
        //    Region = region,
        //    Language = language,
        //    IsOriginalTitle = isOriginalTitle,
        //    Types = types,
        //    Attributes = attributes
        //};
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
            //db.Aliases.Update
            db.MoviesTitles.Remove(movieTitles);
            return db.SaveChanges() > 0;
        }
        return false;
    }

    public (IList<Names>, int count) GetNames(int page, int pageSize)
    {
        var db = new PostgresDB();
        //var result = db.Aliases.ToList();
        //return result;

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
        //var newAlias = new Aliases
        //{
        //    TitleId = titleId,
        //    Ordering = ordering,
        //    Title = title,
        //    Region = region,
        //    Language = language,
        //    IsOriginalTitle = isOriginalTitle,
        //    Types = types,
        //    Attributes = attributes
        //};
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
            //db.Aliases.Update
            db.Names.Remove(name);
            return db.SaveChanges() > 0;
        }
        return false;
    }












    //NameWorkedAs

    public (IList<NameWorkedAs>, int count) GetNameWorkedAs(int page, int pageSize)
    {
        var db = new PostgresDB();
      
        var nameWorkedAs = db.NameWorkedAs.Skip(page * pageSize).Take(pageSize).ToList();
        return (nameWorkedAs, db.NameWorkedAs.Count());
    }

    public (IList<NameWorkedAs>, int count) GetNameWorkedAs(string nameId, int page, int pageSize)
    {
        var db = new PostgresDB();
        var result = db.NameWorkedAs.Where(x => x.NameId == nameId).Skip(page * pageSize).Take(pageSize).ToList();
        return (result, db.NameWorkedAs.Count());
    }

    public NameWorkedAs? GetNameWorkedAs(string nameId, string? profession)
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

    public NameWorkedAs CreateNamedWorkedAs(NameWorkedAs newNameWorkedas)
    {
        using var db = new PostgresDB();
        db.Add(newNameWorkedas);
        db.SaveChanges();
        return newNameWorkedas;
    }

    public bool DeleteNameworkedAs(NameWorkedAs nameWorkedAs)
    {
        var db = new PostgresDB();
        var l = db.NameWorkedAs.Where(x => x.NameId == nameWorkedAs.NameId).ToList();
        var deleteNameworkedAs = db.NameWorkedAs
            .FirstOrDefault(x => x.NameId == nameWorkedAs.NameId && x.Profession == nameWorkedAs.Profession);
        if (nameWorkedAs != null)
        {
            db.NameWorkedAs.Remove(nameWorkedAs);
            return db.SaveChanges() > 0;
        }
        return false;
    }



// Pricipals

    public (IList<Principals>, int count) GetPrincipals(int page, int pageSize)
    {
        var db = new PostgresDB();
        var principals = db.Principals.Skip(page * pageSize).Take(pageSize).ToList();

        return (principals, db.Principals.Count());
    }

    public Principals? GetPrincipals(int principalsId)
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



    //Search History

    public (IList<SearchHistory>, int count) GetSearchHistory(int page, int pageSize)
    {
        var db = new PostgresDB();
        var searchHistory = db.SearchHistories.Skip(page * pageSize).Take(pageSize).ToList();

        return (searchHistory, db.SearchHistories.Count());
    }

    public SearchHistory? GetSearchHistory(int searchHistoryId)
    {
        var db = new PostgresDB();
        var result = db.SearchHistories.FirstOrDefault(x => x.SearchHistoryId == searchHistoryId);
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


    //User Rating
    public (IList<UserRatings>, int count) GetUserRating(int page, int pageSize)
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





    //Users
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

    public Users CreateUsers(Users users)
    {
        using var db = new PostgresDB();

        db.Add(users);
        db.SaveChanges();
        return users;
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

}
