using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LocalLookupMVC.Models;
using LocalLookupMVC.ViewModels;

namespace LocalLookupMVC.Controllers
{

    public class AccountsController : Controller
    {

        private readonly LocalLookupMVCContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //Dependency Injections
        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, LocalLookupMVCContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        //index
        public ActionResult Index()
        {
            return View();
        }
        //Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return Redirect("Index");
        }
    }
}