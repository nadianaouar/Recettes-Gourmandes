using RecettesGourmandes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RecettesGourmandes.Controllers
{
    public class RecettesController : Controller
    {
        RecettesGourmandesContext recettesContext = new RecettesGourmandesContext();
        // GET: Recettes
        public ActionResult ListeRecettes()
        {
            return View(recettesContext.Recettes.ToList());
        }
        public ActionResult AfficherRecette(int id)
        {
            Recette recette = new Recette();
            recette = recettesContext.Recettes.Find(id);
            if (recette != null)
            {
                return View(recette);
            }
            else return HttpNotFound();
        }

        public  ActionResult AjouterRecette()
        {
            Recette r =new Recette();
            return View("AjouterRecette", r);
        }
        [HttpPost]
        public ActionResult AjouterRecette(Recette recette)
        {
            if (ModelState.IsValid)
            {
                recettesContext.Recettes.Add(recette);
                recettesContext.SaveChanges();
                return RedirectToAction("ListeRecettes");
            }
            else
                return RedirectToAction("AjouterRecette");
        }

        public ActionResult ListeSuppression()
        {
            return View("ListeSuppression", recettesContext.Recettes.ToList());
        }

        
        public ActionResult Supprimer(int id)
        {
            Recette r =new Recette();
            r = recettesContext.Recettes.Find(id);
            if (r != null)
                return View("SupprimerRecette", r);
            else return HttpNotFound();
        }

        [HttpPost,ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult SupprimerR(int id)
        {
            Recette r = new Recette();
            r = recettesContext.Recettes.Find(id);
            if (r != null)
            {
                recettesContext.Recettes.Remove(r);
                recettesContext.SaveChanges();
                return RedirectToAction("ListeSuppression");
            }
            return HttpNotFound();
        }

        public ActionResult ListeModification()
        {
            return View("ListeModification", recettesContext.Recettes.ToList());
        }

        public ActionResult Modifier(int id)
        {
            Recette r = new Recette();
            r = recettesContext.Recettes.Find(id);
            if (r != null)
                return View("Modifier", r);
            else return HttpNotFound();
        }

        [HttpPost, ActionName("Modifier")]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(Recette r)
        {
            if (ModelState.IsValid)
            {
                recettesContext.Entry(r).State = EntityState.Modified;
                recettesContext.SaveChanges();
                return View("ListeRecettes", recettesContext.Recettes.ToList());
            }
            else return View("Modifier",r);
        }
        public FileContentResult GetImage(int id)
        {
            Recette r = new Recette();
            r = recettesContext.Recettes.Find(id);
            if (r != null)
                return File(r.RecetteImage, r.RecetteImageType);
            else
                return null;
        }
    }
}