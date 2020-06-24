using System;

namespace AppAgricultura.API.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public Recurso Recurso { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public Usuario Usuario { get; set; }
    }
}