using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class DataService
{
    public IList<Aliases> GetAliases()
    {
        var db = new PostgresDB();
        var result = db.Aliases.ToList();
        return result;
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
}
