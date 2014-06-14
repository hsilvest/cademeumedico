using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(UsuarioMetadado))]
    public partial class Usuarios
    {

    }
    public class UsuarioMetadado
    {
        [Required(ErrorMessage="Obrigatório Informar o Nome")]
        [StringLength(30,ErrorMessage="O Nome deve ter no mínimo 30 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório Informar o Login")]
        [StringLength(30, ErrorMessage = "O Login deve ter no mínimo 30 caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Obrigatório Informar a Senha")]
        [StringLength(30, ErrorMessage = "A Senha deve ter no mínimo 30 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Obrigatório Informar o Email")]
        [StringLength(30, ErrorMessage = "O Email deve ter no mínimo 30 caracteres")]
        public string Email { get; set; }
    }
}