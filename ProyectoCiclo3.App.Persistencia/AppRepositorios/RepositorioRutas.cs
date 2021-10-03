using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioRutas
    {
        List<Rutas> rutas;
 
    public RepositorioRutas()
        {
            rutas = new List<Rutas>()
            {
                new Rutas{id=1,origen=1,destino=2,tiempo_estimado = 35},
                new Rutas{id=2,origen=1,destino=3,tiempo_estimado = 45},
                new Rutas{id=3,origen=2,destino=3,tiempo_estimado = 25},
                new Rutas{id=4,origen=3,destino=5,tiempo_estimado = 27},
                new Rutas{id=5,origen=2,destino=4,tiempo_estimado = 12},
                new Rutas{id=6,origen=2,destino=7,tiempo_estimado = 49},
                new Rutas{id=7,origen=1,destino=6,tiempo_estimado = 54},
                new Rutas{id=8,origen=7, destino=3,tiempo_estimado = 42},
                
            };
        }
 
        public IEnumerable<Rutas> GetAll()
        {
            return rutas;
        }
 
        public Rutas GetRutaWithId(int id){
            return rutas.SingleOrDefault(b => b.id == id);
        }
        public Rutas Create(Rutas newRuta)
        {
           if(rutas.Count > 0){
           newRuta.id=rutas.Max(r => r.id) +1; 
            }else{
               newRuta.id = 1; 
            }
           rutas.Add(newRuta);
           return newRuta;   
        }
        public Rutas Delete(int id)
        {
        var ruta= rutas.SingleOrDefault(b => b.id == id);
        rutas.Remove(ruta);
        return ruta;
        }


        public Rutas Update(Rutas newRuta){
            var ruta= rutas.SingleOrDefault(b => b.id == newRuta.id);
            if(ruta != null){
                ruta.origen = newRuta.origen;
                ruta.destino = newRuta.destino;
                ruta.tiempo_estimado = newRuta.tiempo_estimado;
            }
        
        return ruta;
        }

    }
}
