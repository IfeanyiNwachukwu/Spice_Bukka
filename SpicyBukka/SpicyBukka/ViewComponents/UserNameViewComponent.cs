using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpicyBukka.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpicyBukka.ViewComponents
{
    [ViewComponent(Name = "UserName")]
    public class UserNameViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public UserNameViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var userFromDb = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == claims.Value);
       
            return View(userFromDb);
        }
    }
}
