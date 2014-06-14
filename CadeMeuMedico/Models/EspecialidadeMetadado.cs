using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(EspecialidadeMetadado))]
    public partial class Especialidades
    { 
    
    }
    public class EspecialidadeMetadado
    {
        [Required(ErrorMessage="Nome da Especialidade é obrigatório")]
        public string Nome { get; set; }
    }
}