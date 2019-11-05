using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private IUserValidator<AppUser> _userValidator;
        private IPasswordValidator<AppUser> _passwordValidator;
        private IPasswordHasher<AppUser> _passwordHasher;

        public AdminController(UserManager<AppUser> userManager,
            IUserValidator<AppUser> userValidator,
            IPasswordValidator<AppUser> passwordValidator,
            IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _userValidator = userValidator;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
        }
        //[Authorize(Roles = "Moderators")]
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }
        [Authorize(Roles = "Users")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Users")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            //verify model state
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        //add error to modelstate error list
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);
        }
        [Authorize(Roles = "Moderators")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            

            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }
                
            }

            return RedirectToAction("Index", _userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string password)
        {
            
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.Email = email;
                    IdentityResult validEmail = await _userValidator.ValidateAsync(_userManager, user);
                    if (!validEmail.Succeeded)
                    {
                        AddErrorsFromResult(validEmail);
                    }

                    IdentityResult validPass = null;
                    if (!string.IsNullOrEmpty(password))
                    {
                        validPass = await _passwordValidator.ValidateAsync(_userManager, user, password);
                        if (validPass.Succeeded)
                        {
                            user.PasswordHash = _passwordHasher.HashPassword(user, password);
                        }
                        else
                        {
                            AddErrorsFromResult(validPass);
                        }
                    }

                    if ((validEmail.Succeeded && validPass == null) ||
                        (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                    {
                        IdentityResult result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }

                return View(user);
            }

            return RedirectToAction("index");
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}