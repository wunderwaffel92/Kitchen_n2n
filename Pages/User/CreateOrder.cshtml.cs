using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateOrderModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public CreateOrderModel(
        ApplicationDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public Order Order { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        Order.Status = "NEW";

        _db.Orders.Add(Order);

        _db.SaveChanges();

        return RedirectToPage("/User/MyOrders");
    }
}