using System;

namespace AppAgricultura.API.Models
{
    public class Usuario 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //public DateTime DataNascimento { get; set; }
        public string Login { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        //public Cliente Cliente { get; set; }
    }
}