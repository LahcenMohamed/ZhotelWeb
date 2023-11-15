using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;

namespace ZhotelWeb.Site.Controllers
{
    [Authorize("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceHalper serviceHalper;

        public ServiceController(IServiceHalper serviceHalper)
        {
            this.serviceHalper = serviceHalper;
        }
        // GET: ServiceController
        public async Task<IActionResult> Index()
        {
            var lst = await serviceHalper.GetAll();
            return View(lst);
        }

        // GET: ServiceController/Create
        public async Task<IActionResult> Add()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Service service)
        {
            if (ModelState.IsValid)
            {
                await serviceHalper.Add(service);
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: ServiceController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ser = await serviceHalper.GetById(id);
            return View(ser);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                await serviceHalper.Update(service);
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: ServiceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await serviceHalper.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
