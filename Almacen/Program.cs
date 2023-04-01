using Almacen.DAO;
using Almacen.Models;
using System;
using System.Text.RegularExpressions;

#region
//var buscar = db.Productos.FirstOrDefault(x => x.Id == 1);
//Console.WriteLine(buscar);

//{
//    Producto producto = new Producto();
//    Console.WriteLine("Ingresar el nombre del producto ->");
//    producto.Nombre = Console.ReadLine();
//    Console.WriteLine("Ingresar la descripcion ->");
//    producto.Descripción = Console.ReadLine();
//    Console.WriteLine("Ingresar el precio del producto -> ");
//    producto.Precio = Convert.ToDecimal(Console.ReadLine());
//    Console.WriteLine("Ingresar el Stock del producto -> ");
//    producto.Stock = Convert.ToInt32(Console.ReadLine()); 

//    db.Productos.Add(producto);
//    db.SaveChanges();
//}

//var ListProductos = db.Productos.ToList();

//foreach (var pro in ListProductos)
//{
//    Console.WriteLine("=============================================");
//    Console.WriteLine($"Los produtos ingresados son:\n" +  
//        $"Nombre: {pro.Nombre}\n" +
//        $"Descripcion: {pro.Descripción}\n" +
//        $"Precio: {pro.Precio}\n" +
//        $"Stock: {pro.Stock}\n");
//    Console.WriteLine("=============================================");
//}
#endregion

#region Insertar/guardar
CrudProductos CrudProductos = new CrudProductos();
Producto producto = new Producto();

bool continuar = true;
while (continuar)
{
    Console.WriteLine("Menu");
    Console.WriteLine("Pulse 1 para realizar insertar productos");
    Console.WriteLine("Pulse 2 para realizar actualizar productos");
    Console.WriteLine("Pulse 3 para realizar eliminacion de productos");
    Console.WriteLine("Pulse 4 para realizar listado de los productos");

    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {
        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("Ingresa el nombre del producto");
                producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa la descripcion del producto");
                producto.Descripcion = Console.ReadLine();
                Console.WriteLine("Ingresa el precio del producto");
                producto.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Ingresa el Stock");
                producto.Stock = Convert.ToInt32(Console.ReadLine());
                CrudProductos.AgregarProducto(producto);
                Console.WriteLine("El producto se ingreso correctamente");
                Console.WriteLine("Pulsa 1 para continuar insertando productos");
                Console.WriteLine("Pulsa 0 para salir");
                bucle = Convert.ToInt32(Console.ReadLine());

            }
            break;
        case 2:

            Console.WriteLine("Actualizar datos");
            Console.WriteLine("Ingresa el id de producto a actualizar");
            producto.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresa el nuevo nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa la nueva descripcion del producto");
            producto.Descripcion = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo precio del producto");
            producto.Precio = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ingresa el nuevo STOCK del producto");
            producto.Stock = Convert.ToInt32(Console.ReadLine());
            CrudProductos.ActualizarProducto(producto);
            Console.WriteLine("El producto se actualizo correctamente");
            Console.WriteLine("Pulsa 1 para continuar actualizando productos");
            Console.WriteLine("Pulsa 0 para salir");
            bucle = Convert.ToInt32(Console.ReadLine());
            break;
        case 3:
            Console.WriteLine("Ingresa el ID del producto para eliminar");
            var ProductoIndividualD = CrudProductos.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (ProductoIndividualD == null)
            {

                Console.WriteLine("Este producto no exite");
            }
            else
            {
                Console.WriteLine("Eliminar producto");
                Console.WriteLine($"Nombre {ProductoIndividualD.Nombre}, Descripcion {ProductoIndividualD.Descripcion}, Precio {ProductoIndividualD.Precio}, Stock {ProductoIndividualD.Stock} ");
                Console.WriteLine("¿El producto encontrado es correcto?, Presiona 1 para eliminar, presiona 0 para iniciar nuevamente ");
                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(ProductoIndividualD.Id);
                    Console.WriteLine(CrudProductos.EliminarProducto(Id));
                }
                else
                {
                    Console.WriteLine("Inicia nuevamente");
                }
            }
            break;
        case 4:

            AlmacenContext db = new AlmacenContext();
            var ListProduc = db.Productos.ToList();

            foreach (var pro in ListProduc)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Los productos ingresados son\n" +
                                  $"Nombre: {pro.Nombre}\n" +
                                  $"Descripcion: {pro.Descripcion}\n" +
                                  $"Precio: {pro.Precio}\n" +
                                  $"Stock: {pro.Stock}\n");
                Console.WriteLine("===================================");
            }
            break;
    }

    Console.WriteLine("Desea continuar? Presione S para continuar y N para finalizar");
    var cont = Console.ReadLine();
    if (cont.Equals("N"))
    {
        continuar = false;
    }
}
#endregion