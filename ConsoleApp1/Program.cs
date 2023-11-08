using DataLayer;
using DataLayer.Models;

var ds = new DataService();

//Console.WriteLine(ds.GetWeightedAverage("nm3269402 ").ToString);

//var x = ds.GetCastRatingsMovieTitles("Pirates", 0, 10);
//foreach (var actor in x.Item1)
//{
//    Console.WriteLine(actor.TitleOfMovie);
//    Console.WriteLine(actor.NameId);
//    Console.WriteLine(actor.Name);
//    Console.WriteLine(actor.Rating);
//    Console.WriteLine("_________");
//}

var alias = new Aliases { TitleId = "tt10687202", Ordering=83, Title="updated"};

Console.WriteLine(ds.UpdateUserPassword(3, "newpassword"));