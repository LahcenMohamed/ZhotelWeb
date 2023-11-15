using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhotelWeb.Repositories;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;

namespace ZhotelWeb.Site.Controllers
{
    [Authorize("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerHalper customerRepo;

        public CustomerController(ICustomerHalper customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public async Task<IActionResult> Index()
        {
            var lst = await customerRepo.GetAll();
            return View(lst);
        }
        public async Task<IActionResult> Details(int id)
        {
            var cust = await customerRepo.GetById(id);
            return View(cust);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await customerRepo.Add(customer);
                return RedirectToAction(nameof(Index));

            }
            return View(customer);
        }
        public async Task<IActionResult> Edit (int id)
        {
            var cust = await customerRepo.GetById(id);
            return View(cust);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await customerRepo.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await customerRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
