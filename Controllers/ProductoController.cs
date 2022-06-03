using API_REST.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        Producto[] productos = new Producto[3]//Creamos un array de la clase Producto llamado productos, que contendra 3 "productos"
        {
             new Producto() { ProductoId = 1, Nombre = "Producto1", Descripcion = "Texto1" },  //cargamos el array los datos pertinentes
             new Producto() { ProductoId = 2, Nombre = "Producto2", Descripcion = "Texto2" }, //cargamos el array los datos pertinentes
             new Producto() { ProductoId = 3, Nombre = "Producto3", Descripcion = "Texto3" } //cargamos el array los datos pertinentes
        };

        // GET: api/<ProductoController>
        [HttpGet]

        public IEnumerable<Producto> Get() //Se define entre <> el tipo de Enumerable, para este caso debe ser del tipo "Produncto" porque ese es el tipo del array
        {
            // new Producto() { ProductoId = 1, Nombre = "Producto1", Descripcion = "Texto1" } creamos el producto y cargamos los datos pertinentes      
            return productos; //Aca retornamos el IEnumerable con las datos del array
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            /*
             * Esta secion la usaria sino tuviera las lineas 12-17
            var query = from elemento in productos
                           where elemento.ProductoId == id
                           select elemento;
            */

            //Nota: si no existe el producto solicitado devuelve vacio.
            Producto? producto = new Producto();

            try
            {
                //if(id >= 0 && id < productos.Length) --> prefiero esta opcion
                if (Enumerable.Range(0, productos.Length - 1).Contains(id))
                {
                    producto = productos.FirstOrDefault(x => x.ProductoId == id);

                }
            }
            catch (Exception ex)
            {
                if (!Enumerable.Range(0, productos.Length - 1).Contains(id))
                {
                    producto = new Producto() { Descripcion = "No existe el producto" }; //HACER UN TEST CON Y SIN ESTA LINEA Y SIN EL NULLABLE DE PRODUCTO!!!!!!!
                    throw new Exception($"El objeto no existe {ex.Message}");
                }
            }
            return producto;
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
