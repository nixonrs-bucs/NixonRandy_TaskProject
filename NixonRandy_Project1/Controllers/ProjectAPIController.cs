using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NixonRandy_Project1.Models.Entities;
using NixonRandy_Project1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NixonRandy_Project1.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("/api/project")]
    public class ProjectAPIController : ControllerBase
    {
        private readonly IProjectRepo _projectRepo;
        public ProjectAPIController(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }
        // GET: api/<Project>/all
        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(_projectRepo.GetAll());
        }

        // GET api/<Project>/one/5
        [HttpGet("one/{id}")]
        public IActionResult Get(int id)
        {
            var project = _projectRepo.Details(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // POST api/<Project>/create
        [HttpPost("Create")]
        public IActionResult Post([FromForm] Project project)
        {
            _projectRepo.Create(project);
            return CreatedAtAction(nameof(Get), new { id = project.ProjectId }, project);
        }

        // PUT api/<Project>/update
        [HttpPut("update")]
        public IActionResult Put([FromForm] Project project)
        {
            _projectRepo.Edit(project.ProjectId, project);
            return NoContent(); // 204 as per HTTP specification
        }

        // DELETE api/<Project>/delete/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _projectRepo.Delete(id);
            return NoContent(); // 204 as per HTTP specification
        }
    }
}
