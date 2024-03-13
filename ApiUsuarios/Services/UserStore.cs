// Import the namespace containing the User model
using ApiUsuarios.Models;

// Namespace declaration for the UserStore service
namespace ApiUsuarios.Services
{
    // Class representing a user store
    public class UserStore
    {
        // Property to store the list of users
        public List<User> Users { get; set; }

        // Static property representing the current instance of UserStore
        public static UserStore Current { get; set; } = new UserStore();

        // Constructor for the UserStore class
        public UserStore()
        {
            // Initialize the list of users with some initial values
            Users = new List<User>() {
                // Adding users to the list
                new User() {
                    Id = 1,
                    Name = "Abel",
                    LastName = "Checa",
                    Location = "Valencia"
                },
                new User() {
                    Id = 2,
                    Name = "Valentin",
                    LastName = "Pavon",
                    Location = "Argentina"
                },
                new User() {
                    Id = 3,
                    Name = "Arnau",
                    LastName = "Jover",
                    Location = "Gandia"
                },
                new User() {
                    Id = 4,
                    Name = "Alfonso",
                    LastName = "Lorbes",
                    Location = "Barcelona"
                }
            };
        }
    }
}
