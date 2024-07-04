using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Task_Management_Backend.Repositories.Category.Interfaces;

namespace Task_Management_Backend.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class Category(ICategory categoryService) : ControllerBase
    {
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
                return Ok("Added new category successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.GetType() == typeof(DbException) 
                    ? "An error occurred in the database" 
                    : "The system is experiencing an error, please call the administrator");
            }
        }
        /// <summary>Get all categories</summary>
        /// <returns>List of categories</returns>
        [HttpGet("ListCategory")]
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
                    ? "An error occurred in the database" 
                    : "The system is experiencing an error, please call the administrator");
            }
        }
        /// <summary>Handle HTTP PUT requests to update a category</summary>
        /// <param name="id">The id of the category</param>
        /// <param name="name">The new name of the category</param>
        /// <returns>
        /// The updated category
        /// or an error message in case of an exception
        /// or a message indicating that the category was not found
        /// </returns>
        [HttpPatch("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromForm] int id, [FromForm] string name)
        {
            try
            {
                var category = await categoryService.UpdateCategory(id, name);
                if (category == null) return NotFound("Category not found");
                return Ok("Updated category successfully");
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
