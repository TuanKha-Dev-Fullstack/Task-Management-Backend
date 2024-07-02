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
                if (e.GetType() == typeof(DbException))
                    return BadRequest("An error occurred in the database");
                return BadRequest("The system is experiencing an error, please call the administrator");
            }
        }
    }
}
