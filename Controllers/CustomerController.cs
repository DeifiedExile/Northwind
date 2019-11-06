using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {

        private INorthwindRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        public CustomerController(INorthwindRepository repo, UserManager<AppUser> usrMgr)
        {
            _repository = repo;
            _userManager = usrMgr;

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CustomerWithPassword customerWithPassword)
        {
            if (ModelState.IsValid)
            {
                Customer customer = customerWithPassword.Customer;
                if (_repository.Customers.Any(c => c.CompanyName == customer.CompanyName))
                {
                    ModelState.AddModelError("", "Company Name must be unique");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        AppUser user = new AppUser
                        {
                            Email = customer.Email,
                            UserName = customer.Email
                        };
                        IdentityResult result = await _userManager.CreateAsync(user, customerWithPassword.Password);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                        else
                        {
                            result = await _userManager.AddToRoleAsync(user, "Customers");

                            if (!result.Succeeded)
                            {
                                await _userManager.DeleteAsync(user);
                                AddErrorsFromResult(result);
                            }
                            else
                            {
                                _repository.AddCustomer(customer);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
                
            }

            return View();
        }
        [Authorize(Roles = "Customers")]
        public IActionResult Account() => View(_repository.Customers.FirstOrDefault(c => c.Email == User.Identity.Name));

        [Authorize(Roles = "Customers"), HttpPost, ValidateAntiForgeryToken]
        public IActionResult Account(Customer customer)
        {
            // Edit customer info
            _repository.EditCustomer(customer);
            return RedirectToAction("Index", "Home");
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