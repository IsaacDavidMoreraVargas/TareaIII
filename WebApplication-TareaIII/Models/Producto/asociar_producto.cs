using System.ComponentModel.DataAnnotations;

namespace WebApplication_TareaIII.Models.Producto
{
    public partial class asociar_producto
    {
        [Key]
        public int? Id_Producto { get; set; }
        public string Lote_Producto { get; set; }

        public string Fecha_Fabricacion { get; set; }

        public string Fecha_Caducidad { get; set; }

        public string Nombre_Completo { get; set; }

        public string Informacion_Proveedor { get; set; }

        public int Cantidad_Unidades { get; set; }
    }
}
