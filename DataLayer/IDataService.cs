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


    }
}
