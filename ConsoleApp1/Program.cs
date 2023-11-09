using DataLayer;
var ds = new DataService();

var x = ds.GetCoActors("Johnny Depp", 0, 10);
foreach (var actor in x.Item1)
{

    Console.WriteLine(actor.NameId);
}





//D4
var structuredStringSearch = ds.GetStructuredStringSearch("jack", 0, 10);
foreach (var StructuredStringSearch in structuredStringSearch.Item1)
{
    Console.WriteLine(StructuredStringSearch.tconst);
}




//D10
var associatedwords = ds.GetAssociatedWords("jack", 0, 10);
foreach (var AssociatedWords in associatedwords.Item1)
{
    Console.WriteLine(AssociatedWords.titleId);
}



//D11

var exactSearch = ds.GetExactSearch("tt9844448 ", 0, 10);
foreach (var ExactSearch in exactSearch.Item1)
{
    Console.WriteLine(ExactSearch.titleId);
}



//D12
var associatedtitle = ds.GetAssociatedTitle("A Perfect Fit", 0, 10);
foreach (var AssociatedTitle in associatedtitle.Item1)
{

    Console.WriteLine(AssociatedTitle.titleId);
}