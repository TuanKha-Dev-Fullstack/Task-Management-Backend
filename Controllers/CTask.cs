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
        /// <param name="categoryId"></param>
        /// <returns>
        /// Returns a message indicating that the task was added successfully
        /// or an error message in case of an exception
        /// </returns>
        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask([FromForm] string name, [FromForm] int? categoryId = null)
        {
            try
            {
                await taskService.AddTask(name, categoryId);
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
        /// <summary>Gets all finished tasks</summary>
        /// <returns>All finished tasks</returns>
        [HttpGet("FinishedTasks")]
        public async Task<IActionResult> FinishedTasks()
        {
            try
            {
                var finishedTasks = await taskService.FinishedTasks();
                return Ok(finishedTasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? "An error occurred in the database" 
                    : "The system is experiencing an error, please call the administrator");
            }
        }
        /// <summary>Mark a task as important or not</summary>
        /// <param name="id">The id of the task</param>
        /// <returns>
        /// Message indicating that the task was marked
        /// or an error message in case of an exception
        /// </returns>
        [HttpPatch("MarkImportant")]
        public async Task<IActionResult> MarkImportant([FromForm] int id)
        {
            try
            {
                var task = await taskService.MarkImportant(id);
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
        /// <summary>Get all important tasks</summary>
        /// <returns>
        /// Message indicating that the task was marked
        /// or an error message in case of an exception
        /// </returns>
        [HttpGet("ImportantTasks")]
        public async Task<IActionResult> ImportantTasks()
        {
            try
            {
                var importantTasks = await taskService.ImportantTasks();
                return Ok(importantTasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? "An error occurred in the database" 
                    : "The system is experiencing an error, please call the administrator");
            }
        }
        /// <summary>Updates a task</summary>
        /// <param name="id">The id of the task</param>
        /// <param name="name">New name of the task</param>
        /// <returns>
        /// Message indicating that the task was updated
        /// or an error message in case of an exception
        /// </returns>
        [HttpPatch("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromForm] int id, [FromForm] string name)
        {
            try
            {
                var task = await taskService.UpdateTask(id, name);
                if (task == null)
                    return NotFound("Task not found");
                return Ok("Updated task successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? "An error occurred in the database" 
                    : "The system is experiencing an error, please call the administrator");
            }
            
        }
        /// <summary>Deletes a task</summary>
        /// <param name="id">The id of the task</param>
        /// <returns>
        /// Message indicating that the task was deleted
        /// or an error message in case of an exception
        /// </returns>
        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask([FromForm] int id)
        {
            try
            {
                var task = await taskService.DeleteTask(id);
                if (task == null)
                    return NotFound("Task not found");
                return Ok("Deleted task successfully");
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
