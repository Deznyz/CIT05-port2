using DataLayer.Models;
using DataLayer.PostgresModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Generic;

namespace DataLayer
{
    
    public interface IDataService
    {
        /*-------------------------------------------------------------------------------
                                         ------Aliases------
        ---------------------------------------------------------------------------------*/
        (IList<Aliases>, int count) GetAliases(int page, int pageSize);
        (IList<Aliases>, int count) GetAliases(string titleId, int page, int pageSize);
        Aliases GetAlias(string titleId, int? ordering);
        Aliases CreateAliases(Aliases alias);
        bool DeleteAliases(Aliases alias);
        bool UpdateAliases(string titleId, int ordering, Aliases updateInfo);

        /*-------------------------------------------------------------------------------
                                    ------BookmarksName------
        ---------------------------------------------------------------------------------*/
        (IList<BookmarksName>, int count) GetBookmarksName(int page, int pageSize);
        (IList<BookmarksName>, int count) GetBookmarksName(int userId, int page, int pageSize);
        BookmarksName? GetSpecificBookmarksName(int userId, string nameId);
        BookmarksName CreateBookmarksName(BookmarksName bookmarksName);
        bool DeleteBookmarksName(BookmarksName bookmarksName);


        /*-------------------------------------------------------------------------------
                                    ------BookmarksTitle------
        ---------------------------------------------------------------------------------*/
        (IList<BookmarksTitle>, int count) GetBookmarksTitles(int page, int pageSize);
        (IList<BookmarksTitle>, int count) GetBookmarksTitles(int userId, int page, int pageSize);
        BookmarksTitle GetSpecificBookmarksTitle(int userId, string titleId);
        BookmarksTitle CreateBookmarksTitle(BookmarksTitle bookmarksTitle);
        bool DeleteBookmarksTitle(BookmarksTitle bookmarksTitle);


        /*-------------------------------------------------------------------------------
                                    ------GetEpisodeBelongsTo------
        ---------------------------------------------------------------------------------*/
        (IList<EpisodeBelongsTo>, int count) GetEpisodeBelongsTos(int page, int pageSize);
        (IList<EpisodeBelongsTo>, int count) GetEpisodeBelongsTosByParentTvShowTitleId(string parentTvShowTitleId, int page, int pageSize);
        EpisodeBelongsTo GetEpisodeBelongsToParentTvShowId(string episodeTitleId);
        EpisodeBelongsTo GetEpisodeBelongsTo(string episodeTitleId, string parentTvShowTitleId);
        EpisodeBelongsTo CreateEpisodeBelongsTo(EpisodeBelongsTo episodeBelongsTo);
        bool DeleteEpisodeBelongsTo(EpisodeBelongsTo episodeBelongsTo);
        bool UpdateEpisodeBelongsTo(string episodeTitleId, string ParentTvShowTitleId, EpisodeBelongsTo updateInfo);

        /*-------------------------------------------------------------------------------
                                    ------Frontend------
        ---------------------------------------------------------------------------------*/
        (IList<Frontend>, int count) GetFrontends(int page, int pageSize);
        (IList<Frontend>, int count) GetFrontendsByTitleId(string titleId, int page, int pageSize);
        Frontend GetFrontend(string titleId, string poster);
        Frontend CreateFrontend(Frontend frontend);
        bool DeleteFrontend(Frontend frontend);
        bool UpdateFrontend(string titleId, string poster, Frontend frontend);




       /*-------------------------------------------------------------------------------
                                   ------GetStructuredStringSearch------
       ---------------------------------------------------------------------------------*/
        (IList<StructuredStringSearch>, int count) GetStructuredStringSearch(string tconst, int page, int pageSize);



        /*-------------------------------------------------------------------------------
                                    ------Actors------
        ---------------------------------------------------------------------------------*/
        (IList<SearchTitleResult>, int count) SearchTitle(int userId, string queryString, int page, int pageSize);
        //D5
        (IList<NameSearchResult>, int count) NameSearch(string givenName, int page, int pageSize);
        //D6
        (IList <CoActors>, int count) GetCoActors(string givenName, int page, int pageSize);
        //D7
        WeightedAverage GetWeightedAverage(string nameId);
        //D8.1
        (IList<CastRatingsMovieId>, int count) GetCastRatingsMovieId(string movieId, int page, int pageSize);
        //D8.2
        (IList<CastRatingsMovieTitles>, int count) GetCastRatingsMovieTitles(string movieTitle, int page, int pageSize);




        /*-------------------------------------------------------------------------------
                                  ------GetAssociatedWords------
      ---------------------------------------------------------------------------------*/
        (IList<AssociatedWords>, int count) GetAssociatedWords(string titleId, int page, int pageSize);


        /*-------------------------------------------------------------------------------
                         ------GetExactSearch------
        ---------------------------------------------------------------------------------*/
        (IList<ExactSearch>, int count) GetExactSearch(string titleId, int page, int pageSize);


        /*-------------------------------------------------------------------------------
                           ------GetAssociatedTitle------
        ---------------------------------------------------------------------------------*/
        (IList<AssociatedTitle>, int count) GetAssociatedTitle(string titleId, int page, int pageSize);

  
        /*-------------------------------------------------------------------------------
                                    ------Genres------
        ---------------------------------------------------------------------------------*/
        (IList<Genres>, int count) GetGenres(int page, int pageSize);
        (IList<Genres>, int count) GetGenres(string titleId, int page, int pageSize);
        Genres GetGenre(string titleId, string genre);
        Genres CreateGenres(Genres genre);
        bool DeleteGenres(Genres genre);
      
        /*-------------------------------------------------------------------------------
                                    ------KnownFor------
        ---------------------------------------------------------------------------------*/
        (IList<KnownFor>, int count) GetKnownFors(int page, int pageSize);
        (IList<KnownFor>, int count) GetKnownForTitle(string titleId, int page, int pageSize);
        (IList<KnownFor>, int count) GetKnownForName(string nameId, int page, int pageSize);
        KnownFor GetKnownFor(string titleId, string nameId);
        KnownFor CreateKnownFor(KnownFor knownfor);
        bool DeleteKnownFor(KnownFor knownfor);



        /*-------------------------------------------------------------------------------
                                    ------MovieRatings------
        ---------------------------------------------------------------------------------*/
        (IList<MovieRatings>, int count) GetMovieRatings(int page, int pageSize);
        MovieRatings GetMovieRating(string MovieRatingId);
        MovieRatings CreateMovieRating(MovieRatings movieRatings);
        bool DeleteMovieRating(MovieRatings movieRatings);
      
      
        /*-------------------------------------------------------------------------------
                                    ------MovieTitles------
        ---------------------------------------------------------------------------------*/
        (IList<MovieTitles>, int count) GetMovieTitles(int page, int pageSize);
        MovieTitles GetMovieTitle(string movieTitleId);
        MovieTitles CreateMovieTitle(MovieTitles movieTitles);
        bool DeleteMovieTitle(MovieTitles movieTitles);
      
        /*-------------------------------------------------------------------------------
                                    ------Names------
        ---------------------------------------------------------------------------------*/
        (IList<Names>, int count) GetNames(int page, int pageSize);
        Names GetName(string nameId);
        Names CreateName(Names name);
        bool DeleteName(Names name);


        /*-------------------------------------------------------------------------------
                                    ------NameWorkedAs------
        ---------------------------------------------------------------------------------*/
        (IList<NameWorkedAs>, int count) GetNameWorkedAs(int page, int pageSize);
        (IList<NameWorkedAs>, int count) GetNameWorkedAsByNameId(string nameId, int page, int pageSize);
        NameWorkedAs GetSpecificNameWorkedAs(string nameId, string? profession);
        NameWorkedAs CreateNameWorkedAs(NameWorkedAs newNameWorkedas);
        bool DeleteNameworkedAs(NameWorkedAs nameWorkedAs);
        bool UpdateNameWorkedAs(string nameId, NameWorkedAs updateInfo);

        /*-------------------------------------------------------------------------------
                                    ------Principals------
        ---------------------------------------------------------------------------------*/
        (IList<Principals>, int count) GetPrincipals(int page, int pageSize);
        Principals? GetPrincipal(int principalsId);
        Principals CreatePrincipals(Principals principals);
        bool DeletePrincipals(Principals principals);
        bool UpdatePrincipals(int principalsId, Principals updateInfo);




        /*-------------------------------------------------------------------------------
                                    ------SearchHistory------
        ---------------------------------------------------------------------------------*/
        (IList<SearchHistory>, int count) GetSearchHistory(int page, int pageSize);
        (IList<SearchHistory>, int count) GetSearchHistory(int searchHistoryId, int page, int pageSize);
        SearchHistory GetSearchHistoryId(int searchHistoryId, int userId);
        SearchHistory CreateSearchHistory(SearchHistory searchHistory);
        bool DeleteSearchHistory(SearchHistory searchHistory);
        bool UpdateSearchHistory(int searchHistoryId, SearchHistory updateInfo);


        /*-------------------------------------------------------------------------------
                                    ------UserRatings------
        ---------------------------------------------------------------------------------*/
        (IList<UserRatings>, int count) GetUserRatings(int page, int pageSize);
        (IList<UserRatings>, int count) GetUserRatings(int? userId, int page, int pageSize);
        UserRatings GetUserRatings(int userId, string? titleId);
        UserRatings CreateUserRatings(UserRatings userRatings);
        bool DeleteUserRatings(UserRatings userRatings);
        bool UpdateUserRating(int userId, string titleId, UserRatings updateInfo);

        /*-------------------------------------------------------------------------------
                                    ------Users------
        ---------------------------------------------------------------------------------*/
        (IList<Users>, int count) GetUsers(int page, int pageSize);
        Users GetUsers(int userId);
        Users CreateUsers(Users users);
        bool DeleteUsers(Users users);
        bool UpdateUser(int userId, Users updateInfo);
        //D1
        //bool CreateUser(string username, string password);
        Users CreateUser(Users user);
        bool UpdateUserPassword(int id, string newPassword);
        Users GetUserByUsername(string username);

        /*-------------------------------------------------------------------------------
                                    ------Users------
        ---------------------------------------------------------------------------------*/
        (IList<BestMatchSearch>, int count) GetBestMatchSearch(string searchString, int page, int pageSize);


    }



}
