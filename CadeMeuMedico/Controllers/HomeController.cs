using CadeMeuMedico.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AutenticacaoUsuario(string login, string senha)
        {
            if (RepositorioUsuarios.AutenticarUsuario(login, senha))
            {
                return Json(new
                {
                    OK = true,
                    Mensagem = "Usuário autenticado... Redirecionando..."
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    OK = false,
                    Mensagem = "Usuário não encontrado... Tente novamente ..."
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Seja bem vindo!";
            return View();
        }
    }
}
