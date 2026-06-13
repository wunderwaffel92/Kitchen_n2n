using Kitchen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class TestOrderModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public TestOrderModel(ApplicationDbContext db)
    {
        _db = db;
    }

    // ====== ÔÎĞÌÀ (ìèíèìàëüíàÿ çàÿâêà) ======

    [BindProperty]
    public string? ClientName { get; set; }

    [BindProperty]
    public decimal? KitchenWidth { get; set; }

    [BindProperty]
    public decimal? KitchenHeight { get; set; }

    [BindProperty]
    public decimal? KitchenDepth { get; set; }

    [BindProperty]
    public string? BodyMaterial { get; set; }

    [BindProperty]
    public string? FacadeMaterial { get; set; }

    [BindProperty]
    public string? Color { get; set; }

    [BindProperty]
    public string? Comment { get; set; }

    public string? Message { get; set; }

    // ====== ÑÏÈÑÎÊ ÇÀÊÀÇÎÂ ======

    public List<Order> Orders { get; set; } = new();

    // ====== ÇÀÃĞÓÇÊÀ ÑÒĞÀÍÈÖÛ ======

    public void OnGet()
    {
        Orders = _db.Orders
            .OrderByDescending(x => x.Id)
            .ToList();
    }

    // ====== ÑÎÇÄÀÍÈÅ ======

    public IActionResult OnPost()
    {
        var order = new Order
        {
            UserId = 1, // ïîêà çàãëóøêà (ïîòîì áóäåò ëîãèí)
            Status = "NEW",

            Comment = ClientName ?? Comment,

            KitchenWidth = (decimal)KitchenWidth,
            KitchenHeight = (decimal)KitchenHeight,
            KitchenDepth = (decimal)KitchenDepth,

            BodyMaterial = BodyMaterial,
            FacadeMaterial = FacadeMaterial,
            Color = Color
        };

        _db.Orders.Add(order);
        _db.SaveChanges();

        return RedirectToPage();
    }

    // ====== ÓÄÀËÅÍÈÅ ======

    public IActionResult OnPostDelete(long id)
    {
        var order = _db.Orders.FirstOrDefault(x => x.Id == id);

        if (order != null)
        {
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }

        return RedirectToPage();
    }
}