using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEstaciones
    {
        List<Estaciones> estaciones;
 
    public RepositorioEstaciones()
        {
            estaciones= new List<Estaciones>()
            {
                new Estaciones{id=1,nombre="Norte",direccion= "Portal del Norte",coord_x= 1,coord_y= 2,tipo= "A"},
                new Estaciones{id=2,nombre="Caracas",direccion= "Avenida Caracas calle 40 sur",coord_x= 1,coord_y= 2,tipo= "A"},
                new Estaciones{id=3,nombre="NQS",direccion= "Avenida NQS Calle 75",coord_x= 1,coord_y= 2,tipo= "A"}
            };
        }
 
        public IEnumerable<Estaciones> GetAll()
        {
            return estaciones;
        }
 
        public Estaciones GetEstacionWithId(int id){
            return estaciones.SingleOrDefault(b => b.id == id);
        }

        public Estaciones Create(Estaciones newEstacion)
        {
           if(estaciones.Count > 0){
           newEstacion.id=estaciones.Max(r => r.id) +1; 
            }else{
               newEstacion.id = 1; 
            } 
           estaciones.Add(newEstacion);
           return newEstacion;
        }

        public Estaciones Update(Estaciones newEstacion){
            var estacion= estaciones.SingleOrDefault(b => b.id == newEstacion.id);
            if(estacion != null){
                estacion.nombre = newEstacion.nombre;
                estacion.direccion = newEstacion.direccion;
                estacion.coord_x = newEstacion.coord_x;
                estacion.coord_y = newEstacion.coord_y;
                estacion.tipo = newEstacion.tipo;
            }
        return estacion;
        }  

        public Estaciones Delete(int id)
        {
        var estacion= estaciones.SingleOrDefault(b => b.id == id);
        estaciones.Remove(estacion);
        return estacion;
        }  
    }
}