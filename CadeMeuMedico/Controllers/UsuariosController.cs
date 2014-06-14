using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class UsuariosController : BaseController
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();

        public ActionResult Index()
        {
            var usuarios = db.Usuarios.ToList();
            return View(usuarios);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        public ActionResult Editar(long id)
        {
            Usuarios usuario = db.Usuarios.Find(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Adicionar(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Usuarios usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch (Exception)
            {
                return Boolean.FalseString;
            }
        }

    }
}
