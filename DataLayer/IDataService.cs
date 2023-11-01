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
     
    }
}
