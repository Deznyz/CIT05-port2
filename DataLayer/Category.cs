namespace DataLayer;
public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public ICollection<Product> Product {  get; set; }

    public override string ToString()
    {
        return $"{Id}, {CategoryName}, {Description}";
    }
}

