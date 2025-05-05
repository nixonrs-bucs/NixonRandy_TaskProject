using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NixonRandy_Project1.Services;

namespace NixonRandy_Project1.Controllers
{
    [Authorize]
    public class ProjectTaskController : Controller
    {
        private readonly ITasksRepo _taskRepo;
        public ProjectTaskController(ITasksRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }
        // GET: ProjectTaskController
        public async Task<ActionResult> Index()
        {
            var projects = await _taskRepo.GetAllAsyncs();
            return View(projects);
        }

        // GET: ProjectTaskController/Details/5
        [HttpGet, ActionName(nameof(Details))]
        public async Task<IActionResult> Details(int id)
        {
            var project = await _taskRepo.DetailsAsync(id);
            if (project == null)
            {
                var statusCode = NotFound().StatusCode;
                ViewData["StatusCode"] = statusCode;
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View(project);
            }
        }

        // GET: ProjectTaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NixonRandy_Project1.Models.Entities.ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                await _taskRepo.CreateAsync(projectTask);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(projectTask);
            }
        }

        // GET: ProjectTaskController/Edit/5
        [HttpGet, ActionName(nameof(Edit))]
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _taskRepo.DetailsAsync(id);
            if (project == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // POST: ProjectTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NixonRandy_Project1.Models.Entities.ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                await _taskRepo.EditAsync(id, projectTask);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(projectTask);
            }
        }
        // GET: Dashboard/Delete/5
        [HttpGet, ActionName(nameof(Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            var projectToDelete = await _taskRepo.DetailsAsync(id);
            if (projectToDelete == null)
            {
                return RedirectToAction(nameof(Index));
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
            await _taskRepo.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
