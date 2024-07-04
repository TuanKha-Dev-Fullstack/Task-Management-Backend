using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Task_Management_Backend.Extends.Messages;
using Task_Management_Backend.Repositories.Category.Interfaces;

namespace Task_Management_Backend.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class Category(ICategory categoryService) : ControllerBase
    {
        private readonly MessageProvider _message = new MessageProvider();
        /// <summary>Handle HTTP POST requests to add a new category</summary>
        /// <param name="name">the name of the new category</param>
        /// <returns>
        /// a message indicating that the category was added successfully
        /// or an error message in case of an exception
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] string name)
        {
            try
            {
                await categoryService.AddCategory(name);
                return Ok(string.Format(_message.GetMessage("Created"), "category"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handle HTTP GET requests to list all categories</summary>
        /// <returns>
        /// List of categories
        /// or an error message in case of an exception
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> ListCategory()
        {
            try
            {
                var categories = await categoryService.ListCategory();
                return Ok(categories);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handle HTTP PATCH requests to update a category</summary>
        /// <param name="id">The id of the category</param>
        /// <param name="name">The new name of the category</param>
        /// <returns>
        /// The updated category
        /// or an error message in case of an exception
        /// or a message indicating that the category was not found
        /// </returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromForm] string name)
        {
            try
            {
                var category = await categoryService.UpdateCategory(id, name);
                if (category == null) return NotFound(string.Format(_message.GetMessage("NotFoundField"), "Category"));
                return Ok(string.Format(_message.GetMessage("Updated"), "category"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? _message.GetMessage("DatabaseError")
                    : _message.GetMessage("SystemError"));
            }
        }
        /// <summary>Handle HTTP DELETE requests to delete a category</summary>
        /// <param name="id">The id of the category</param>
        /// <returns>
        /// The deleted category
        /// or an error message in case of an exception
        /// or a message indicating that the category was not found
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await categoryService.DeleteCategory(id);
                if (category == null) return NotFound(string.Format(_message.GetMessage("NotFoundField"), "Category"));
                return Ok(string.Format(_message.GetMessage("Deleted"), "category"));
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
