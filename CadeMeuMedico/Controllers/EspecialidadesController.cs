﻿using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadesController : BaseController
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();

        public ActionResult Index()
        {
            var especialidades = db.Especialidades.ToList();
            return View(especialidades);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        public ActionResult Editar(long id)
        {
            var especialidade = db.Especialidades.Find(id);
            return View(especialidade);
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidades especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(especialidade);
        }

        [HttpPost]
        public ActionResult Editar(Especialidades especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Especialidades especialiadade = db.Especialidades.Find(id);
                db.Especialidades.Remove(especialiadade);
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
