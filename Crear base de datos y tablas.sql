Create Database TareaIII
GO
USE TareaIII
Create table datosProducto(
		Id_Producto int NOT NULL ,
        Lote_Producto varchar(300) NOT NULL,
		Fecha_Fabricacion varchar(300) NOT NULL,
		Fecha_Caducidad varchar(300) NOT NULL,
        Nombre_Completo varchar(300) NOT NULL,
        Informacion_Proveedor varchar(300) NOT NULL,
        Cantidad_Unidades int NOT NULL,
		PRIMARY KEY (Id_Producto)
)
