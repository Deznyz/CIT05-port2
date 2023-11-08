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

        /*-------------------------------------------------------------------------------
                                    ------Frontend------
        ---------------------------------------------------------------------------------*/
        (IList<Frontend>, int count) GetFrontends(int page, int pageSize);
        (IList<Frontend>, int count) GetFrontendsByTitleId(string titleId, int page, int pageSize);
        Frontend GetFrontend(string titleId, string poster);
        Frontend CreateFrontend(Frontend frontend);
        bool DeleteFrontend(Frontend frontend);


        /*-------------------------------------------------------------------------------
                                    ------GetCoActors------
        ---------------------------------------------------------------------------------*/
        (IList <CoActors>, int count) GetCoActors(string givenName, int page, int pageSize);
    }


}
