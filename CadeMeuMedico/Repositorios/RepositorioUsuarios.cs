using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Repositorios
{
    public class RepositorioUsuarios
    {
        public static bool AutenticarUsuario(string login, string senha)
        {
            var senhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "sha1");

            try
            {
                using (CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities())
                {
                    var queryAutenticaUsuarios = db.Usuarios.Where(x => x.Login == login && x.Senha == senha).SingleOrDefault();

                    if (queryAutenticaUsuarios == null)
                    {
                        return false;
                    }
                    else
                    {
                        RepositorioCookies.RegistraCookieAutenticacao(queryAutenticaUsuarios.IDUsuario);
                        return true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Usuarios RecuperaUsuarioPorID(long IDUsuario)
        {
            try
            {
                using (CadeMeuMedicoBDEntities db =
                new CadeMeuMedicoBDEntities())
                {
                    var Usuario = db.Usuarios.Where(u => u.IDUsuario == IDUsuario).SingleOrDefault();
                    return Usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Usuarios VerificaSeOUsuarioEstaLogado()
        {
            var Usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            if (Usuario == null)
            {
                return null;
            }
            else
            {
                long IDUsuario = Convert.ToInt64(RepositorioCriptografia.Descriptografar(Usuario.Values["IDUsuario"]));
                var UsuarioRetornado = RecuperaUsuarioPorID(IDUsuario);
                return UsuarioRetornado;
            }
        }
    }
}