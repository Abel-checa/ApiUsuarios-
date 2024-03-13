using System;

var builder = WebApplication.CreateBuilder(args); // Crea un nuevo constructor de aplicaciones web utilizando los argumentos proporcionados

// Agrega servicios al contenedor
builder.Services.AddControllers(); // Agrega el servicio para controladores
builder.Services.AddEndpointsApiExplorer(); // Agrega el servicio para la API Explorer
builder.Services.AddSwaggerGen(); // Agrega el servicio para generar documentación Swagger
builder.Services.AddControllers(); // Agrega de nuevo el servicio para controladores (puede ser un error duplicar esta línea)

var app = builder.Build(); // Construye la aplicación web utilizando el constructor

// Configura el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment()) // Verifica si la aplicación está en entorno de desarrollo
{
    app.UseSwagger(); // Habilita el middleware Swagger para generar documentación
    app.UseSwaggerUI(); // Habilita el middleware Swagger UI para visualizar la documentación generada
}

app.UseHttpsRedirection(); // Habilita la redirección HTTP a HTTPS

app.UseAuthorization(); // Habilita la autorización para las solicitudes

app.MapControllers(); // Mapea los controladores de la aplicación

app.Run(); // Ejecuta la aplicación
