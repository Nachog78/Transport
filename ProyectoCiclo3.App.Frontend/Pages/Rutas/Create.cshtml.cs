using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;
using Microsoft.AspNetCore.Authorization;

 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    [Authorize]

    public class FormRutaModel : PageModel
    {
 
        private readonly RepositorioRutas repositorioRutas;
        private readonly RepositorioEstaciones repositorioEstaciones;
        [BindProperty]
        public Rutas Ruta {get;set;}
        public IEnumerable<Rutas> Rutas {get;set;}
        public IEnumerable<Estaciones> Estaciones {get;set;}
 
        public FormRutaModel(RepositorioRutas repositorioRutas, RepositorioEstaciones repositorioEstaciones)
       {
            this.repositorioRutas=repositorioRutas;
            this.repositorioEstaciones=repositorioEstaciones;
       }
 
        public void OnGet()
        {
            Rutas=repositorioRutas.GetAll();
            Estaciones=repositorioEstaciones.GetAll();
        }
 
        public IActionResult OnPost(int origen, int destino, int tiempo_estimado)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }            
            Ruta = repositorioRutas.Create(origen, destino, tiempo_estimado);            
            return RedirectToPage("./List");
        }
    }
}