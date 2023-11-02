﻿using System.ComponentModel;
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

    public Genres? GetGenres(string titleId, string genre)
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
}
