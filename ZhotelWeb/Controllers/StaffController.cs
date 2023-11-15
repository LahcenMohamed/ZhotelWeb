using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;

namespace ZhotelWeb.Site.Controllers
{
    [Authorize("Admin")]
    public class StaffController : Controller
    {
        private readonly IStaffHalper staffHalper;
        private IWebHostEnvironment webHostEnvironment;

        public StaffController(IStaffHalper staffHalper, IWebHostEnvironment _webHostEnvironment)
        {
            this.staffHalper = staffHalper;
            webHostEnvironment = _webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var lst = await staffHalper.GetAll();
            return View(lst);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Staff staff)
        {
            IFormFile? formFile = Request.Form.Files["Image"];
            if(formFile != null) 
            {
                if (ModelState.IsValid)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Img", "Staff");
                    string file_name = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    string file_path = Path.Combine(uploadsFolder, file_name);
                    using (var stream = new FileStream(file_path, FileMode.Create)) {
                        formFile.CopyTo(stream);
                        stream.Close();
                    }
                    staff.ImageUrl = file_name;
                    await staffHalper.Add(staff);
                    return RedirectToAction("Index");
                }
            }
            return View(staff);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Staff staff = await staffHalper.GetById(id);
            return View(staff);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Staff staff)
        {
            IFormFile? formFile = Request.Form.Files["Image"];
            if (ModelState.IsValid)
            {
                if (formFile != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Img", "Staff");
                    string file_name = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    string file_path = Path.Combine(uploadsFolder, file_name);
                    using (var stream = new FileStream(file_path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        stream.Close();
                    }
                    staff.ImageUrl = file_name;
                    
                }
                await staffHalper.Update(staff);
                return RedirectToAction("Index");
            }
            return View(staff);
        }


        public async Task<IActionResult> Details(int id)
        {
            var st = await staffHalper.GetById(id);
            return View(st);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await staffHalper.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
