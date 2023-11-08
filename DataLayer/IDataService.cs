using DataLayer.Models;
using DataLayer.PostgresModels;
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
        BookmarksName GetSpecificBookmarksName(int userId, string nameId);
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
                                    ------Actors------
        ---------------------------------------------------------------------------------*/
        //D1
        bool CreateUser(string username, string password);
        bool UpdateUserPassword(int id, string newPassword);
        //D2
        (IList<SearchTitleResult>, int count) SearchTitle(int userId, string queryString, int page, int pageSize);
        //D5
        (IList<NameSearchResult>, int count) NameSearch(string name, int page, int pageSize);
        //D6
        (IList <CoActors>, int count) GetCoActors(string givenName, int page, int pageSize);
        //D7
        WeightedAverage GetWeightedAverage(string nameId);
        //D8.1
        (IList<CastRatingsMovieId>, int count) GetCastRatingsMovieId(string movieId, int page, int pageSize);
        //D8.2
        (IList<CastRatingsMovieTitles>, int count) GetCastRatingsMovieTitles(string movieTitle, int page, int pageSize);


    }


}
