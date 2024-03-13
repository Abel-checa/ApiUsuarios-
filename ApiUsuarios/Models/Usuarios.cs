namespace ApiUsuarios.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Propiedad para el nombre del usuario, inicializada como cadena vacía por defecto
        public string LastName { get; set; } = string.Empty; // Propiedad para el apellido del usuario, inicializada como cadena vacía por defecto
        public string Location { get; set; } = string.Empty; // Propiedad para la ubicación del usuario, inicializada como cadena vacía por defecto

    }
}