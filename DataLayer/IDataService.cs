using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    /*-------------------------------------------------------------------------------
                                         ------Aliases------
    ---------------------------------------------------------------------------------*/
    public interface IDataService
    {
        (IList<Aliases>, int count) GetAliases(int page, int pageSize);
        (IList<Aliases>, int count) GetAliases(string titleId, int page, int pageSize);
        Aliases GetAlias(string titleId, int? ordering);
        Aliases CreateAliases(Aliases alias);
        bool DeleteAliases(Aliases alias);


        /*-------------------------------------------------------------------------------
                                    ------BookmarksName------
        ---------------------------------------------------------------------------------*/
        (IList<BookmarksName>, int count) GetBookmarksName(int page, int pageSize);
        (IList<BookmarksName>, int count) GetBookmarksName(int userId, int page, int pageSize);
        BookmarksName GetSpecificBookmarksName(int userId, string nameId);
        BookmarksName CreateBookmarksName(BookmarksName bookmarksName);
        bool DeleteBookmarksName(BookmarksName bookmarksName);


        /*-------------------------------------------------------------------------------
                                    ------BookmarksName------
        ---------------------------------------------------------------------------------*/
        (IList<BookmarksTitle>, int count) GetBookmarksTitles(int page, int pageSize);
        (IList<BookmarksTitle>, int count) GetBookmarksTitles(int userId, int page, int pageSize);
        BookmarksTitle GetSpecificBookmarksTitle(int userId, string titleId);
        BookmarksTitle CreateBookmarksTitle(BookmarksTitle bookmarksTitle);
        bool DeleteBookmarksTitle(BookmarksTitle bookmarksTitle);


        /*-------------------------------------------------------------------------------
                                    ------BookmarksName------
        ---------------------------------------------------------------------------------*/
        (IList<EpisodeBelongsTo>, int count) GetEpisodeBelongsTos(int page, int pageSize);
        (IList<EpisodeBelongsTo>, int count) GetEpisodeBelongsTosByParentTvShowTitleId(string parentTvShowTitleId, int page, int pageSize);
        EpisodeBelongsTo GetEpisodeBelongsToParentTvShowId(string episodeTitleId);
        EpisodeBelongsTo GetEpisodeBelongsTo(string episodeTitleId, string parentTvShowTitleId);
        EpisodeBelongsTo CreateEpisodeBelongsTo(EpisodeBelongsTo episodeBelongsTo);
        bool DeleteEpisodeBelongsTo(EpisodeBelongsTo episodeBelongsTo);
    }
}
