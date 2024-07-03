using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Task_Management_Backend.Repositories.Task.Interfaces;

namespace Task_Management_Backend.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class CTask(ITask taskService) : ControllerBase
    {
        /// <summary>
        /// Handles HTTP POST requests to add a new task
        /// </summary>
        /// <param name="name">The name of the new task to be added, provided in the request body</param>
        /// <returns>
        /// Returns a message indicating that the task was added successfully
        /// or an error message in case of an exception
        /// </returns>
        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask([FromForm] string name)
        {
            try
            {
                await taskService.AddTask(name);
                return Ok("Added new task Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? "An error occurred in the database" 
                    : "The system is experiencing an error, please call the administrator");
            }
        }
        /// <summary>Get all unfinished tasks</summary>
        /// <returns>List of all unfinished tasks</returns>
        [HttpGet("UnfinishedTasks")]
        public async Task<IActionResult> UnfinishedTasks()
        {
            try
            {
                var unfinishedTasks = await taskService.UnfinishedTasks();
                return Ok(unfinishedTasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? "An error occurred in the database" 
                    : "The system is experiencing an error, please call the administrator");
            }
        }
        /// <summary>Marks a task as finished</summary>
        /// <param name="id">The id of the task</param>
        /// <returns>
        /// Returns a message indicating that the task was marked as finished successfully
        /// or an error message in case of an exception
        /// </returns>
        [HttpPatch("MarkAsFinished")]
        public async Task<IActionResult> MarkAsFinished([FromForm] int id)
        {
            try
            {
                var task = await taskService.MarkAsFinished(id);
                if (task == null)
                    return NotFound("Task not found");
                return Ok("Marked task successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? "An error occurred in the database" 
                    : "The system is experiencing an error, please call the administrator");
            }
        }
    }
}
