using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class DataService
{
    private readonly Order entity;

    //1
    public Order? GetOrder(int Id)
    {
        var db = new NorthwindContex();

        foreach (var entity in db.Orders
                .Include(y => y.OrderDetails)
                .ThenInclude(z => z.Product)
                .ThenInclude(x => x.Category)
                .Where(a => a.Id == Id))
        {
            return entity;
        }
        return null;
    }

    //2
    public IList<Order>? GetOrdersByShippingName(string givenshipname)
    {
        var db = new NorthwindContex();

        return db.Orders.Where(x => x.ShipName == givenshipname).Where(x => x.Shipped != null).ToList();
    }

    //3
    public IList<Order>? GetOrders()
    {
        var db = new NorthwindContex();
        return db.Orders.ToList();
    }

    //4
    public List<OrderDetails> GetOrderDetailsByOrderId(int Id)
    {
        var db = new NorthwindContex();

        var orderDetails = db.OrderDetails
            .Include(p => p.Product)
            .Where(go => go.OrderId == Id)
            .ToList();

        return orderDetails;
    }


    //alternativ til 4
    //public OrderDetails GetOrderDetailsByOrderId(int Id)
    //{
    //    try
    //    {
    //        using (var db = new NorthwindContex())
    //        {
    //            var orderDetail = db.OrderDetails
    //                .Include(p => p.Product)
    //                .FirstOrDefault(go => go.OrderId == Id);

    //            if (orderDetail != null)
    //            {
    //                return orderDetail;
    //            }
    //            else
    //            {
    //                return null;
    //            }
    //        }
    //    }
    //}


    //5
    public List<OrderDetails> GetOrderDetailsByProductId(int productId)
    {
        var db = new NorthwindContex();

        var orderDetails = db.OrderDetails
            .Include(od => od.Order)
            .Include(od => od.Product)
            .Where(od => od.Product.Id == productId)
            .OrderBy(order => order.OrderId)
            .ToList();
        return orderDetails;
    }


    //6
    public ProductWithCategoryName? GetProduct(int Id)
    {
        var db = new NorthwindContex();

        var product = db.Products
                .Include(x => x.Category)
                .FirstOrDefault(a => a.Id == Id);
        if (product != null)
        {
            var productWithCategoryName = new ProductWithCategoryName
            {
                Product = product,
                Name = product.Name,
                CategoryName = product.Category.CategoryName
            };
            return productWithCategoryName;
        }

        return null;
    }

    //7
    public IList<ProductWithCategoryName>? GetProductByName(string substring)
    {
        var db = new NorthwindContex();
        
        var query = from product in db.Products
                    where product.Name.Contains(substring)
                    select new ProductWithCategoryName
                    {
                        Product = product,
                        ProductName = product.Name,
                        CategoryName = product.Category.CategoryName
                    };

        return query.ToList();
        
    }

    //8
    public IList<ProductWithCategoryName> GetProductByCategory(int categoryId)
    {
        var db = new NorthwindContex();
        
        var query = from product in db.Products
                    where product.CategoryId == categoryId
                    select new ProductWithCategoryName
                    {
                        Product = product,
                        Name= product.Name,
                        CategoryName = product.Category.CategoryName
                    };

        var products = query.ToList();

        return products;
        
    }


    //9
    public Category? GetCategory(int categoryId)
        {
        var db = new NorthwindContex();
        var result = db.Categories.FirstOrDefault(x => x.Id == categoryId);
        if (result != null)
        {
            return result;
        }
        else
        {
            return null;
        }
              
        }

    //10
    public IList<Category> GetCategories()
        {
        var db = new NorthwindContex();
        var result = db.Categories.ToList();
        return result; 
        }

    //11
    public Category CreateCategory(string name, string description)
        {
        var db = new NorthwindContex();
        var id = db.Categories.Max(x => x.Id) + 1;
        var newCategory = new Category
        {
            Id = id,
            CategoryName = name,
            Description = description
        };
        db.Add(newCategory);
        db.SaveChanges();
        return newCategory;
        }

    //overload af 11
    public Category CreateCategory(Category givenCategory)
    {
        var db = new NorthwindContex();
        var id = db.Categories.Max(x => x.Id) + 1;
        var newCategory = new Category
        {
            Id = id,
            CategoryName = givenCategory.CategoryName,
            Description = givenCategory.Description
        };
        db.Add(newCategory);
        db.SaveChanges();
        return newCategory;
    }

    //12
    public bool UpdateCategory(int id, string newName, string newDescription)
    {
        var db = new NorthwindContex();
        var category = db.Categories.FirstOrDefault(x => x.Id == id);
        if (category != null)
        {
            category.CategoryName = newName;
            category.Description = newDescription;
            db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
        
    }

    //13
    public bool DeleteCategory(int categoryId)
    {
        var db = new NorthwindContex();
        var category = db.Categories.FirstOrDefault(x => x.Id == categoryId);
        if (category != null)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<Category> GetCategoriesByName(string name)
    {
        throw new NotImplementedException();
    }
}
