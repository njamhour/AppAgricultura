using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgricultura.API.Models
{
    [Table("Recursos")]
    public class Recurso
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataInserido { get; set; }
        public Usuario Usuario { get; set; }
        public RecursoCategoria RecursoCategoria { get; set;}
    }
}