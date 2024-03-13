// Import the namespace containing the user model
using ApiUsuarios.Models;

// Import the namespace containing user-related services
using ApiUsuarios.Services;

// Import the ASP.NET Core namespace for handling HTTP requests
using Microsoft.AspNetCore.Http;

// Import the namespace for handling HTTP request results
using Microsoft.AspNetCore.Http.HttpResults;

// Import the namespace for defining MVC controllers and actions
using Microsoft.AspNetCore.Mvc;

// Namespace declaration for the UsersController
namespace ApiUsuarios.Controllers
{
    // Specifies the base route for requests to this controller
    [Route("api/[controller]")]

    // Indicates that this is an API controller
    [ApiController]
    public class UsersController : ControllerBase
    {
        // This method retrieves all users
        [HttpGet]
        public ActionResult<User> GetUsers()
        {
            return Ok(UserStore.Current.Users); // Returns a successful response along with the list of users
        }

        // This method retrieves a user by ID
        [HttpGet("{userId}")]
        public ActionResult<User> GetUser(int userId)
        {
            var UserFound = UserStore.Current.Users.FirstOrDefault(x => x.Id == userId); // Searches for a user by their ID
            if (UserFound == null)
            {
                return NotFound("The user you are looking for could not be found"); // Returns an error message if the user is not found
            }
            else
            {
                return Ok(UserFound); // Returns the found user
            }
        }

        // This method creates a new user
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            var new_user = new User() { Id = user.Id, Name = user.Name, LastName = user.LastName, Location = user.Location }; // Creates a new user with the provided information
            UserStore.Current.Users.Add(new_user); // Adds the new user to the list of users
            return Ok("The user has been successfully created"); // Returns a success message
        }

        // This method deletes a user by ID
        [HttpDelete("{userId}")]
        public ActionResult<User> DeleteUser(int userId)
        {
            var UserToDelete = UserStore.Current.Users.FirstOrDefault(user => user.Id == userId);
            if (UserToDelete == null)
            {
                return NotFound("The user could not be deleted"); // Returns a message if deletion fails
            }
            else
            {
                UserStore.Current.Users.Remove(UserToDelete); // Removes the user
                return Ok("Successfully deleted."); // Returns a success message
            }
        }

        // This method updates a user's information
        [HttpPut("{userId}")]
        public ActionResult<User> UpdateUser(int userId, User user)
        {
            if (userId != user.Id)
            {
                return NotFound("Mismatched fields"); // Returns an error message if the IDs don't match
            }
            else
            {
                foreach (var usuario in UserStore.Current.Users)
                {
                    if (usuario.Id == userId)
                    {
                        // Updates user information
                        usuario.Name = user.Name;
                        usuario.LastName = user.LastName;
                        usuario.Location = user.Location;
                        return Ok("User updated"); // Returns a success message
                    }
                }
                return Ok("User update failed"); // Returns a message if update fails
            }
        }
    }
}
