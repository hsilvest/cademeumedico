using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(CidadeMetadado))]
    public partial class Cidades
    { 
    
    }
    public class CidadeMetadado
    {
        [Required(ErrorMessage="Nome da Cidade é obrigatório")]
        public string Nome { get; set; }
    }
}