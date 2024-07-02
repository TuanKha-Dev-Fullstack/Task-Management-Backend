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
    }
}
