using Microsoft.AspNetCore.Mvc;

namespace ContaAytoApi.Controllers
{
    // Esta clase representa la estructura de tus datos
    public class Apunte
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public decimal Importe { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        // 1. IMPORTANTE: Declaramos la lista AQUÍ (static) para que sea la memoria compartida
        private static List<Apunte> BaseDeDatos = new List<Apunte>
        {
            new Apunte {
                Id = 1,
                Fecha = DateTime.Now,
                Concepto = "Subvención Estado",
                Importe = 5000
            },
            new Apunte {
                Id = 2,
                Fecha = DateTime.Now,
                Concepto = "Gasto Papelería",
                Importe = -150
            }
        };

        // GET: api/Cuentas (Para leer)
        [HttpGet]
        public IEnumerable<Apunte> Get()
        {
            return BaseDeDatos;
        }

        // POST: api/Cuentas (Para escribir)
        [HttpPost]
        public IActionResult Post([FromBody] Apunte nuevoApunte)
        {
            // Asignamos ID nuevo
            // (Si la lista está vacía, el ID será 1, si no, el último + 1)
            int nuevoId = BaseDeDatos.Any() ? BaseDeDatos.Max(x => x.Id) + 1 : 1;
            nuevoApunte.Id = nuevoId;

            // Si no viene fecha, ponemos la actual
            if (nuevoApunte.Fecha == DateTime.MinValue)
            {
                nuevoApunte.Fecha = DateTime.Now;
            }

            // Guardamos en la lista compartida
            BaseDeDatos.Add(nuevoApunte);

            return Ok(nuevoApunte);
        }
    }
}