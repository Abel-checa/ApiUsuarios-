using System;

var builder = WebApplication.CreateBuilder(args); // Crea un nuevo constructor de aplicaciones web utilizando los argumentos proporcionados

// Agrega servicios al contenedor
builder.Services.AddControllers(); // Agrega el servicio para controladores
builder.Services.AddEndpointsApiExplorer(); // Agrega el servicio para la API Explorer
builder.Services.AddSwaggerGen(); // Agrega el servicio para generar documentaci�n Swagger
builder.Services.AddControllers(); // Agrega de nuevo el servicio para controladores (puede ser un error duplicar esta l�nea)

var app = builder.Build(); // Construye la aplicaci�n web utilizando el constructor

// Configura el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment()) // Verifica si la aplicaci�n est� en entorno de desarrollo
{
    app.UseSwagger(); // Habilita el middleware Swagger para generar documentaci�n
    app.UseSwaggerUI(); // Habilita el middleware Swagger UI para visualizar la documentaci�n generada
}

app.UseHttpsRedirection(); // Habilita la redirecci�n HTTP a HTTPS

app.UseAuthorization(); // Habilita la autorizaci�n para las solicitudes

app.MapControllers(); // Mapea los controladores de la aplicaci�n

app.Run(); // Ejecuta la aplicaci�n
