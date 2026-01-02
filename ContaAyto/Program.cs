using ContaAyto; // Importamos nuestro modelo

// --- ESTADO DE LA APLICACIÓN ---
// En Java: ArrayList<Apunte> lista = new ArrayList<>();
List<Apunte> libroDiario = new List<Apunte>();
int contadorId = 1;
bool ejecutando = true;

Console.WriteLine("=== SISTEMA GESTIÓN CONTABLE AYUNTAMIENTO ===");

// --- BUCLE PRINCIPAL ---
while (ejecutando)
{
    Console.WriteLine("\nSelecciona una opción:");
    Console.WriteLine("1. Registrar Ingreso");
    Console.WriteLine("2. Registrar Gasto");
    Console.WriteLine("3. Ver Balance y Movimientos");
    Console.WriteLine("4. Salir");
    Console.Write("> ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            AgregarMovimiento("INGRESO");
            break;
        case "2":
            AgregarMovimiento("GASTO");
            break;
        case "3":
            MostrarBalance();
            break;
        case "4":
            ejecutando = false;
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

// --- FUNCIONES AUXILIARES ---

void AgregarMovimiento(string tipo)
{
    Console.Write($"Introduce concepto del {tipo}: ");
    string concepto = Console.ReadLine();

    Console.Write("Introduce cantidad (ej: 50,50): ");
    // TryParse es vital en C# para evitar que el programa explote si escriben letras
    if (decimal.TryParse(Console.ReadLine(), out decimal cantidad))
    {
        if (tipo == "GASTO") cantidad = cantidad * -1; // Lo convertimos a negativo

        // Creamos el objeto y lo añadimos a la lista
        var nuevoApunte = new Apunte(contadorId, concepto, cantidad);
        libroDiario.Add(nuevoApunte);

        contadorId++; // Incrementamos el ID para el siguiente
        Console.WriteLine("✅ Movimiento registrado correctamente.");
    }
    else
    {
        Console.WriteLine("❌ Error: La cantidad no es un número válido.");
    }
}

void MostrarBalance()
{
    Console.WriteLine("\n--- LIBRO DIARIO ---");

    decimal total = 0;

    // El foreach es idéntico a Java
    foreach (var apunte in libroDiario)
    {
        // Formato de moneda: {0:C} pone automáticamente el símbolo € y dos decimales
        string tipo = apunte.Importe >= 0 ? "INC" : "EXP"; // Operador ternario
        Console.WriteLine($"{apunte.Id} | {apunte.Fecha.ToShortDateString()} | {tipo} | {apunte.Concepto} | {apunte.Importe:C}");

        total += apunte.Importe;
    }

    Console.WriteLine("--------------------");

    // Cambiamos color de consola según si estamos en números rojos o negros
    if (total >= 0) Console.ForegroundColor = ConsoleColor.Green;
    else Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine($"BALANCE TOTAL: {total:C}");
    Console.ResetColor(); // Volver al color normal
}