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
        (IList<BookmarksTitle>, int count) GetAllTitleBookmarksForUser(int userId, int page, int pageSize);



        /*-------------------------------------------------------------------------------
                                    ------GetEpisodeBelongsTo------
        ---------------------------------------------------------------------------------*/
        (IList<EpisodeBelongsTo>, int count) GetEpisodeBelongsTos(int page, int pageSize);
        (IList<EpisodeBelongsTo>, int count) GetEpisodeBelongsTosByParentTvShowTitleId(string parentTvShowTitleId, int page, int pageSize);
        EpisodeBelongsTo GetEpisodeBelongsToParentTvShowId(string episodeTitleId);
        EpisodeBelongsTo GetEpisodeBelongsTo(string episodeTitleId, string parentTvShowTitleId);
        EpisodeBelongsTo CreateEpisodeBelongsTo(EpisodeBelongsTo episodeBelongsTo);
        bool DeleteEpisodeBelongsTo(EpisodeBelongsTo episodeBelongsTo);
        (IList<BookmarksTitle>, int count) GetAllNameBookmarksForUser(int userId, int page, int pageSize);


        /*-------------------------------------------------------------------------------
                                    ------Frontend------
        ---------------------------------------------------------------------------------*/
        (IList<Frontend>, int count) GetFrontends(int page, int pageSize);
        (IList<Frontend>, int count) GetFrontendsByTitleId(string titleId, int page, int pageSize);
        Frontend GetFrontend(string titleId, string poster);
        Frontend CreateFrontend(Frontend frontend);
        bool DeleteFrontend(Frontend frontend);

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
        (IList<KnownFor>, int count) GetKnownFors(string titleId, int page, int pageSize);
        KnownFor GetKnownFor(string titleId, string nameId);
        KnownFor CreateKnownFor(KnownFor knownfor);
        bool DeleteKnownFor(KnownFor knownfor);

        /*-------------------------------------------------------------------------------
                                   ------MovieRating------
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
                                    ------GetCoActors------
        ---------------------------------------------------------------------------------*/
        (IList <CoActors>, int count) GetCoActors(string givenName, int page, int pageSize);
    }


}
