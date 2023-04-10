using Azure;
using Microsoft.AspNetCore.Mvc;
using System;

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
                        string_retorno += "?" + bandera + "?:{?lote?:?" + valor.Lote_Producto+"?,";
                        string_retorno += "?FechaF?:?" + valor.Fecha_Fabricacion+ "?,";
                        string_retorno += "?FechaC?:?" + valor.Fecha_Caducidad + "?,";
                        string_retorno += "?Nombre?:?" + valor.Nombre_Completo + "?,";
                        string_retorno += "?Informacion?:?" + valor.Informacion_Proveedor + "?,";
                        string_retorno += "?cantidad?:?" +valor.Cantidad_Unidades+ "?},";
                        bandera++;
                    }
                }
                string_retorno = string_retorno.TrimEnd(',');
                string_retorno = string_retorno.Replace('?', '"');
                string_retorno += "}";
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
