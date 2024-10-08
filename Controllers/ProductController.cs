using Blogs.Models;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
public class ProductController : Controller
{
    private readonly DataContext _context;

    public ProductController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Category()
    {
        var categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View(categories);
    }

    public IActionResult Index(int id)
    {
        var products = _context.Products
            .Where(p => p.CategoryId == id && !p.Discontinued)
            .OrderBy(p => p.ProductName)
            .Select(p => new ProductViewModel
            {
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock
            })
            .ToList();
        return View(products);
    }
}
