using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhotelWeb.Repositories.DataHalper;

namespace ZhotelWeb.Site.Controllers
{
    [Authorize("Admin")]
    public class ReviewController : Controller
    {
        private readonly IReviewHalper reviewHalper;

        public ReviewController(IReviewHalper reviewHalper)
        {
            this.reviewHalper = reviewHalper;
        }
        // GET: ReviewController
        public async Task<IActionResult> Index()
        {
            var lst = await reviewHalper.GetAll();
            return View(lst);
        }

        // GET: ReviewController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }


        // GET: ReviewController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await reviewHalper.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
