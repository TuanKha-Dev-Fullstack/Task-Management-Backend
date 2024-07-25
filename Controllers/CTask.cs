using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Task_Management_Backend.Extends.Messages;
using Task_Management_Backend.Repositories.Task.Interfaces;

namespace Task_Management_Backend.Controllers
{
    [Route("api/v1/tasks")]
    [ApiController]
    public class Task(ITask taskService) : ControllerBase
    {
        private readonly MessageProvider _message = new MessageProvider();

        /// <summary>Handles HTTP POST requests to add a new task</summary>
        /// <param name="name">The name of the new task to be added, provided in the request body</param>
        /// <param name="categoryId">The id of the category of the new task</param>
        /// <param name="isImportant"></param>
        /// <returns>
        /// Returns a message indicating that the task was added successfully
        /// or an error message in case of an exception
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> AddTask([FromForm] string name, [FromForm] int? categoryId = null, [FromForm] bool isImportant = false)
        {
            try
            {
                await taskService.AddTask(name, categoryId, isImportant);
                return Ok(string.Format(_message.GetMessage("Created"), "task"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handles HTTP GET requests to get all tasks</summary>
        /// <returns>
        /// List of all tasks
        /// or an error message in case of an exception
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Tasks()
        {
            try
            {
                var unfinishedTasks = await taskService.GetTasks();
                return Ok(unfinishedTasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handles HTTP PATCH requests to mark a task as finished</summary>
        /// <param name="id">The id of the task</param>
        /// <returns>
        /// Returns a message indicating that the task was marked as finished successfully
        /// or an error message in case of an exception
        /// or an not found message in case the task is not found
        /// </returns>
        [HttpPatch("{id}/finished")]
        public async Task<IActionResult> MarkAsFinished(int id)
        {
            try
            {
                var task = await taskService.MarkAsFinished(id);
                if (task == null) 
                    return NotFound(string.Format(_message.GetMessage("NotFoundField"), "Task"));
                return Ok(string.Format(_message.GetMessage("Marked"), "task"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handles HTTP PATCH requests to mark a task as important</summary>
        /// <param name="id">The id of the task</param>
        /// <returns>
        /// Message indicating that the task was marked
        /// or an error message in case of an exception
        /// or an not found message in case the task is not found
        /// </returns>
        [HttpPatch("{id}/important")]
        public async Task<IActionResult> MarkImportant(int id)
        {
            try
            {
                var task = await taskService.MarkImportant(id);
                if (task == null)
                    return NotFound(string.Format(_message.GetMessage("NotFoundField"), "Task"));
                return Ok(string.Format(_message.GetMessage("Marked"), "task"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handles HTTP GET requests to get all important tasks</summary>
        /// <returns>
        /// Message indicating that the task was marked
        /// or an error message in case of an exception
        /// </returns>
        [HttpGet("important")]
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
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handles HTTP PATCH requests to update a task</summary>
        /// <param name="id">The id of the task</param>
        /// <param name="name">New name of the task</param>
        /// <returns>
        /// Message indicating that the task was updated
        /// or an error message in case of an exception
        /// or an not found message in case the task is not found
        /// </returns>
        [HttpPatch("{id}/update")]
        public async Task<IActionResult> UpdateTask(int id, [FromForm] string name)
        {
            try
            {
                var task = await taskService.UpdateTask(id, name);
                if (task == null)
                    return NotFound(string.Format(_message.GetMessage("NotFoundField"), "Task"));
                return Ok(string.Format(_message.GetMessage("Updated"), "task"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handles HTTP DELETE requests to delete a task</summary>
        /// <param name="id">The id of the task</param>
        /// <returns>
        /// Message indicating that the task was deleted
        /// or an error message in case of an exception
        /// or an not found message in case the task is not found
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await taskService.DeleteTask(id);
                if (task == null)
                    return NotFound(string.Format(_message.GetMessage("NotFoundField"), "Task"));
                return Ok(string.Format(_message.GetMessage("Deleted"), "task"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handles HTTP GET requests to get all tasks by category</summary>
        /// <param name="categoryId">The id of the category</param>
        /// <returns>
        /// All tasks by category
        /// or an error message in case of an exception
        /// or an not found message in case the category is not found
        /// </returns>
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> TasksByCategory(int categoryId)
        {
            try
            {
                var tasks = await taskService.TasksByCategory(categoryId);
                if (tasks == null)
                    return NotFound(string.Format(_message.GetMessage("NotFoundField"), "Task"));
                return Ok(tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
    }
}
