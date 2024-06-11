using System;

namespace FCWebApplication.Dtos
{
    public class JogadorDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string apelido { get; set; }
        public DateTime nascimento { get; set; }
        public decimal altura { get; set; }
        public decimal peso { get; set; }
        public string posicao { get; set; }
        public int numero { get; set; }
        public decimal IMC { get; set; }
        public string IMC_Status { get; set; }
        public DateTime criado_em { get; set; }
        public DateTime atualizado_em { get; set; }
    }
}