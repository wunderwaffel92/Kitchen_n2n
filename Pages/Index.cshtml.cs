using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kitchen.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public int UsersCount { get; set; }
        public int OrdersCount { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            UsersCount = _db.Users.Count();
            OrdersCount = _db.Orders.Count();
        }
    }
}
