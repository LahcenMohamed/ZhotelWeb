using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;

namespace ZhotelWeb.Site.Controllers
{
    [Authorize("Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomHalper roomHalper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RoomController(IRoomHalper roomHalper,IWebHostEnvironment webHostEnvironment)
        {
            this.roomHalper = roomHalper;
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: RoomController
        public async Task<IActionResult> Index()
        {
            var lst = await roomHalper.GetAll();
            return View(lst);
        }

        // GET: RoomController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var lst = await roomHalper.GetById(id);
            return View(lst);
        }

        // GET: RoomController/Create
        public async Task<IActionResult> Add()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Room room)
        {
            if(ModelState.IsValid)
            {
                IFormFile? formFile = Request.Form.Files["Images"];
                if (formFile != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Img", "Room");
                    string file_name = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    string file_path = Path.Combine(uploadsFolder, file_name);
                    using (var stream = new FileStream(file_path, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                        stream.Close();
                    }
                    room.ImageUrl = file_name;
                    await roomHalper.Add(room);
                    return RedirectToAction(nameof(Index));
                }
            }       
            return View();
        }

        // GET: RoomController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var room = await roomHalper.GetById(id);
            return View(room);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Room room)
        {
            IFormFile? formFile = Request.Form.Files["Images"];
            if (ModelState.IsValid)
            {
                if (formFile != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Img", "Room");
                    string file_name = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    string file_path = Path.Combine(uploadsFolder, file_name);
                    using (var stream = new FileStream(file_path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        stream.Close();
                    }
                    room.ImageUrl = file_name;
                    
                }
                await roomHalper.Update(room);
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: RoomController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await roomHalper.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
