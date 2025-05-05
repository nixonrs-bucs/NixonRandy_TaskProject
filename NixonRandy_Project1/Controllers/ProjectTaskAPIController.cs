using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NixonRandy_Project1.Models.Entities;
using NixonRandy_Project1.Services;

namespace NixonRandy_Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize, EnableCors]
    public class ProjectTaskAPIController : ControllerBase
    {
        private readonly ITasksRepo _tasksRepo;
        public ProjectTaskAPIController(ITasksRepo tasksRepo)
        {
            _tasksRepo = tasksRepo;
        }
        // GET: api/<ProjectTaskAPIController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(_tasksRepo.GetAll());
        }

        // GET api/<ProjectTaskAPIController>/one/5
        [HttpGet("one/{id}")]
        public IActionResult Get(int id)
        {
            var project = _tasksRepo.Details(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // POST api/<ProjectTaskAPIController>/create
        [HttpPost("Create")]
        public IActionResult Post([FromForm] ProjectTask projectTask)
        {
            _tasksRepo.Create(projectTask);
            return CreatedAtAction(nameof(Get), new { id = projectTask.TaskId }, projectTask);
        }

        // PUT api/<ProjectTaskAPIController>/update
        [HttpPut("update")]
        public IActionResult Put([FromForm] ProjectTask projectTask)
        {
            _tasksRepo.Edit(projectTask.TaskId, projectTask);
            return NoContent(); // 204 as per HTTP specification
        }

        // DELETE api/<ProjectTaskAPIController>/delete/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _tasksRepo.Delete(id);
            return NoContent(); // 204 as per HTTP specification
        }
    }
}

