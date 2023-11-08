using DataLayer;


var ds = new DataService();

var x = ds.GetCoActors("Johnny Depp", 0, 10);
foreach (var actor in x.Item1)
{

    Console.WriteLine(actor.NameId);
}