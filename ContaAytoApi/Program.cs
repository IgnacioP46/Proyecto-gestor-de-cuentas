using ContaAytoApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. ZONA DE SERVICIOS (Configuración)
// ==========================================

// A) Configurar CORS para que Angular (puerto 4200) pueda entrar
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// B) Añadir controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==========================================
// 2. CONSTRUCCIÓN DE LA APP (¡Esta línea faltaba!)
// ==========================================
var app = builder.Build();

// ==========================================
// 3. ZONA DE MIDDLEWARE (Cómo funciona la app)
// ==========================================

// Mostrar Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Activar la política de CORS
app.UseCors("PermitirAngular");

app.UseAuthorization();

// Mapear las rutas de los controladores
app.MapControllers();

// Arrancar
app.Run();