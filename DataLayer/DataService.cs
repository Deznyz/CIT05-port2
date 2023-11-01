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
        var db = new PostgresDB();
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
        var deleteAlias = db.Aliases.Where(x => x.Ordering == alias.Ordering).FirstOrDefault(x => x.TitleId == alias.TitleId);
        if (alias != null)
        {
            db.Aliases.Remove(alias);
            return db.SaveChanges() > 0;
        }
        return false;
    }
}
