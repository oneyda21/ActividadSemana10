using Almacen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.DAO
{
    public class CrudProductos
    {
        public void AgregarProducto(Producto ParametrosProducto)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                Producto producto = new Producto();
                producto.Nombre = ParametrosProducto.Nombre;
                producto.Descripcion = ParametrosProducto.Descripcion;
                producto.Precio = ParametrosProducto.Precio;
                producto.Stock = ParametrosProducto.Stock;
                db.Add(producto);
                db.SaveChanges();


            }


      
        }

        public Producto ProductoIndividual(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = db.Productos.FirstOrDefault(x => x.Id == id);
                return buscar;

            }
        }

        public void ActualizarProducto(Producto ParamentrosProducto)
        {
            using (AlmacenContext db =
                new AlmacenContext())
            {

                var buscar = ProductoIndividual(ParamentrosProducto.Id);
                {

                }
                if (buscar == null)
                {

                    Console.WriteLine("El id no existe");

                }
                else
                {

                    {
                        buscar.Nombre = ParamentrosProducto.Nombre;
                        buscar.Descripcion = ParamentrosProducto.Descripcion;
                        buscar.Precio = ParamentrosProducto.Precio;
                        buscar.Stock = ParamentrosProducto.Stock;

                        db.Update(buscar);
                        db.SaveChanges();
                    }


                }

            }
      
        }

        public string EliminarProducto(int id)
        {
            
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProductoIndividual(id);
                if (buscar == null)
                {
                    return "El producto no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El producto se elimino";



                }

            }

        }
        public List<Producto> ListarProductos()
        {
            using (AlmacenContext db =
                   new AlmacenContext())
            {
                return db.Productos.ToList();
            }

        }

    }

}   

