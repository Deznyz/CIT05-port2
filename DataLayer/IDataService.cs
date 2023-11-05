using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataService
    {
        (IList<Aliases>, int count) GetAliases(int page, int pageSize);
        (IList<Aliases>, int count) GetAliases(string titleId, int page, int pageSize);
        Aliases GetAlias(string titleId, int? ordering);
        Aliases CreateAliases(Aliases alias);
        bool DeleteAliases(Aliases alias);
        (IList<Genres>, int count) GetGenres(int page, int pageSize);
        (IList<Genres>, int count) GetGenres(string titleId, int page, int pageSize);
        Genres GetGenre(string titleId, string genre);
        Genres CreateGenres(Genres genre);
        bool DeleteGenres(Genres genre);
        (IList<KnownFor>, int count) GetKnownFors(int page, int pageSize);
        (IList<KnownFor>, int count) GetKnownFors(string titleId, int page, int pageSize);
        KnownFor GetKnownFor(string titleId, string nameId);
        KnownFor CreateKnownFor(KnownFor knownfor);
        bool DeleteKnownFor(KnownFor knownfor);



        //Skal rettes
        (IList<MovieRatings>, int count) GetMovieRatings(int page, int pageSize);
        MovieRatings GetMovieRating(string MovieRatingId);
        MovieRatings CreateMovieRating(MovieRatings movieRatings);
        bool DeleteMovieRating(MovieRatings movieRatings);
        (IList<MovieTitles>, int count) GetMovieTitles(int page, int pageSize);
        MovieTitles GetMovieTitle(string movieTitleId);
        MovieTitles CreateMovieTitle(MovieTitles movieTitles);
        bool DeleteMovieTitle(MovieTitles movieTitles);
        (IList<Names>, int count) GetNames(int page, int pageSize);
        Names GetName(string nameId);
        Names CreateName(Names name);
        bool DeleteName(Names name);


        //Ida skriver under
        //Known for lave 3 lister.
        //Henter alle
        //Finde på name id
        //finde på Titel id

        (IList<NameWorkedAs>, int count) GetNameWorkedAs(int page, int pageSize);
        (IList<NameWorkedAs>, int count) GetNameWorkedAs(string nameId, int page, int pageSize);
        NameWorkedAs GetNameWorkedAs(string nameId, string? profession);
        NameWorkedAs CreateNameWorkedAs(NameWorkedAs nameWorkedAs);
        bool DeleteNameWorkedAs(NameWorkedAs nameWorkedAs);



        (IList<Principals>, int count) GetPrincipals(int page, int pageSize);
        Names GetPrincipals(int principalsId);
        Names CreatePrincipals(Principals principals);
        bool DeletePrincipals(Principals principals);


        (IList<SearchHistory>, int count) GetSearchHistory(int page, int pageSize);
        SearchHistory GetSearchHistory(int searchHistoryId);
        SearchHistory CreateSearchHistory(SearchHistory searchHistory);
        bool DeleteSearchHistory(SearchHistory searchHistory);



        (IList<UserRatings>, int count) GetUserRatings(int page, int pageSize);
        (IList<UserRatings>, int count) GetUserRatings(int? userId, int page, int pageSize);
        UserRatings GetUserRatings(int userId, string? titleId);
        UserRatings GetUserRatings(UserRatings userRatings);
        bool DeleteUserRatings(UserRatings userRatings);


        (IList<Users>, int count) GetUsers(int page, int pageSize);
        Users GetUsers(int userId);
        Users CreateUsers(Users users);
        bool DeleteUsers(Users users);

    }
}
