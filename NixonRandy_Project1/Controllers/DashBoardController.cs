using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NixonRandy_Project1.Services;

namespace NixonRandy_Project1.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IProjectRepo _projectRepo;
        public DashBoardController(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
            
        }
        // GET:
        [HttpGet, ActionName(nameof(DashboardIndex))]
        public async Task<ActionResult> DashboardIndex()
        {
            var projects = await _projectRepo.GetAllAsyncs();
            return View();
        }

        // GET: Dashboard/Details/5
        [HttpGet, ActionName(nameof(Details))]
        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectRepo.DetailsAsync(id);
            if (project == null)
            {
                var statusCode = NotFound().StatusCode;
                ViewData["StatusCode"] = statusCode;
                return RedirectToAction(nameof(DashboardIndex));

            }
            else
            {
                return View(project);
            }
        }

        // GET: Dashboard/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //I had to clarify the namespace because project is in fact a keyword in C#
        public async Task<IActionResult> Create(NixonRandy_Project1.Models.Entities.Project project)
        {
            if(ModelState.IsValid)
            {
                await _projectRepo.CreateAsync(project);
                return RedirectToAction(nameof(DashboardIndex));
            }
            else
            {
                return View(project);
            }
        }

        // GET: Dashboard/Edit/5
        [HttpGet, ActionName(nameof(Edit))]
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectRepo.DetailsAsync(id);
            if (project == null)
            {
                return RedirectToAction(nameof(DashboardIndex));
            }
            return View(project);
        }

        // POST: Dashboard/Edit/5
        [HttpPost, ActionName(nameof(Edit))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NixonRandy_Project1.Models.Entities.Project EditedProject)
        {
            if (ModelState.IsValid)
            {
                await _projectRepo.EditAsync(id, EditedProject);
                return RedirectToAction(nameof(DashboardIndex));
            }
            else
            {
                return View(EditedProject);
            }
        }

        // GET: Dashboard/Delete/5
        [HttpGet, ActionName(nameof(Delete))]
        public async Task<ActionResult> Delete(int id)
        {
            var projectToDelete = await _projectRepo.DetailsAsync(id);
            if (projectToDelete == null) 
            {
                return RedirectToAction(nameof(DashboardIndex));
            }
            else
            {
                return View(projectToDelete);
            }
        }

        // POST: Dashboard/Delete/5
        [HttpPost, ActionName(nameof(DeleteConfirmed))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _projectRepo.DeleteAsync(Id);
            return RedirectToAction(nameof(DashboardIndex));
        }
    }
}
