using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gandalf.Admin.Controllers
{
    public class ProductsService : Controller
    {
        // GET: ProductsService
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductsService/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsService/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsService/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsService/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsService/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsService/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsService/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
