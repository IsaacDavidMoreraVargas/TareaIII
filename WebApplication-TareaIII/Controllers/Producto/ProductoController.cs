using Azure;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_TareaIII.Controllers.Producto
{
    public class ProductoController : Controller
    {
        [BindProperty]
        public WebApplication_TareaIII.Models.Producto.asociar_producto Registro_registro { get; set; }
        Producto_Context context_producto = new Producto_Context();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nuevo(int id)
        {
            switch (id)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
            return View();
        }
        public string ConsultaInmediata(string id)
        {
            //Console.WriteLine("->"+id);
            var string_retorno = "null";
            //Models.Producto.asociar_producto esqueleto = new Models.Producto.asociar_producto();
            var resultados = context_producto.Registros_Producto.ToList();

            if (resultados != null)
            {
                int bandera = 0;
                string_retorno = "{";
                foreach (Models.Producto.asociar_producto valor in resultados)
                {
                    if (valor.Lote_Producto == id)
                    {
                        string_retorno += "?"+bandera + "?:{?lote?:?"+valor.Lote_Producto+ "?,?cantidad?:?"+valor.Cantidad_Unidades+ "?},";
                        bandera++;
                    }
                }
                string_retorno = string_retorno.TrimEnd(',');
                string_retorno = string_retorno.Replace('?', '"');
                string_retorno += "}";
                //Console.WriteLine(string_retorno);
                /*
                if (encontrado == true)
                {
                    //Console.WriteLine("1->:" + encontrado + " " + esqueleto.Identificacion_Profesional + "-" + esqueleto.Nombre_Completo_Profesional);
                    
                    
                        "'Identificacion_Profesional':'" + esqueleto.Identificacion_Profesional + "'," +
                        "'Codigo_Profesional':'" + esqueleto.Codigo_Profesional + "'," +
                        "'Nombre_Completo_Profesional':'" + esqueleto.Nombre_Completo_Profesional + "'," +
                        "'Correo_Electronico_Profesional':'" + esqueleto.Correo_Electronico_Profesional + "'," +
                        "'Pais_Residencia_Profesional':'" + esqueleto.Pais_Residencia_Profesional + "'," +
                        "'Estado_Provincia_Residencia_Profesional':'" + esqueleto.Estado_Provincia_Residencia_Profesional + "'," +
                        "'Numero_Registro_Unico':'" + esqueleto.Numero_Registro_Unico + "'" +
                        "}";
                    string_retorno = string_retorno.Replace("'", "?");
                    string_retorno = string_retorno.Replace('?', '"');
                    
                    //TempData["Codigo_Unico"] = esqueleto.Numero_Registro_Unico;
                }
                */
            }
            return (string_retorno);
        }
        public IActionResult Ver(string lote)
        {
            return View();
        }

        public IActionResult Registrar()
        {
            try
            {
                if (Registro_registro.Id_Producto != null)
                {
                    var resultados = context_producto.Registros_Producto.Find(Registro_registro.Id_Producto);
                    if (resultados != null)
                    {
                        context_producto.Registros_Producto.Remove(resultados);
                        context_producto.SaveChanges();
                    }
                }
                context_producto.Registros_Producto.Add(Registro_registro);
                context_producto.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine("Exception en paso 1: " + e); }

            return RedirectToAction("Nuevo", "Producto");
        }
    }
}
