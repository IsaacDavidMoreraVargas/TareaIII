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
        string operacion_correcta = "<div class=?ventana-alertas color_correcto?>";
        string operacion_incorrecta = "<div class=?ventana-alertas color_incorrecto ?>";
        string operacion_cierre = "</div>";
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
        public IActionResult Modificar(int id)
        {

            var resultados = context_producto.Registros_Producto.ToList();
            if (resultados != null)
            {
                ViewBag.ListaProductos = resultados;
            }

            if (id != 0)
            {
                var especifico = context_producto.Registros_Producto.Find(id);
                if (especifico != null)
                {
                    TempData["Id_Producto"] = especifico.Id_Producto;
                    TempData["Lote_Producto"] = especifico.Lote_Producto;
                    TempData["Fecha_Fabricacion"] = especifico.Fecha_Fabricacion;
                    TempData["Fecha_Caducidad"] = especifico.Fecha_Caducidad;
                    TempData["Nombre_Completo"] = especifico.Nombre_Completo;
                    TempData["Cantidad_Unidades"] = especifico.Cantidad_Unidades;
                    TempData["Informacion_Proveedor"] = especifico.Informacion_Proveedor;
                }
                
            }
            return View();
        }
        public IActionResult Registrar_Modificado()
        {
            try
            {
                var resultados = context_producto.Registros_Producto.Find(Registro_registro.Id_Producto);
                if (resultados != null)
                {
                    context_producto.Registros_Producto.Remove(resultados);
                    context_producto.SaveChanges();
                }

                context_producto.Registros_Producto.Add(Registro_registro);
                context_producto.SaveChanges();
                correcto_incorrecto(0);
            }
            catch (Exception e) { Console.WriteLine("Exception en paso 2: " + e); correcto_incorrecto(1); }

            return RedirectToAction("Modificar", "Producto");
        }
        public IActionResult Cero(string lote)
        {
            var resultados = context_producto.Registros_Producto.ToList();

            if (resultados != null)
            {
                ViewBag.ListaProductos = resultados;
            }
            return View();
        }
        public IActionResult Registrar()
        {
            try
            {
                var resultados = context_producto.Registros_Producto.ToList();
                Registro_registro.Id_Producto = resultados.Count + 1;
                context_producto.Registros_Producto.Add(Registro_registro);
                context_producto.SaveChanges();
                correcto_incorrecto(0);
            }
            catch (Exception e) { Console.WriteLine("Exception en paso 1: " + e); correcto_incorrecto(1); }

            return RedirectToAction("Nuevo", "Producto");
        }
        public void correcto_incorrecto(int numero)
        {
            string crear_alert = "";
            switch(numero)
            {
                case 0:
                    crear_alert = operacion_correcta + "Operacion Exitosa" + operacion_cierre;
                    break;
                case 1:
                    crear_alert = operacion_incorrecta + "Operacion No Exitosa" + operacion_cierre;
                    break;
            }
            crear_alert = crear_alert.Replace('?','"');
            TempData["Alert-Alert"] = crear_alert;
        }
    }
}
