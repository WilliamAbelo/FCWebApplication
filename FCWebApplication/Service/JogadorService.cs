using FCWebApplication.Model;
using System.Collections.Generic;

namespace FCWebApplication.Service
{
    public class JogadorService
    {
        private readonly DataService _dataService = new DataService();
        public void CriarJogador(Jogador jogador)
        {
            jogador.imc = CalculoIMC(jogador.peso, jogador.altura);
            jogador.imc_status = ClassificarIMC(jogador.imc);

            if (jogador.id > 0)
            {
                _dataService.UpdatePlayer(jogador);
            }
            else
            {
                _dataService.CreatePlayer(jogador);
            }
        }

        public decimal CalculoIMC(decimal peso, decimal altura)
        {
            return peso / (altura * altura);
        }
        public string ClassificarIMC(decimal imc)
        {
            if (imc < 18.5m) return "Abaixo do peso normal";
            else if (imc >= 18.5m && imc < 24.9m) return "Peso normal";
            else if (imc >= 24.9m && imc < 29.9m) return "Excesso de peso";
            else if (imc >= 29.9m && imc < 34.9m) return "Obesidade classe I";
            else if (imc >= 34.9m && imc < 39.9m) return "Obesidade classe II";
            else return "Obesidade classe III";

        }

        public Jogador BuscaJogador(int id)
        {
            Jogador jogador = new Jogador();
            jogador = _dataService.SelectPlayer(id);

            return jogador;
        }

        public List<Jogador> ListarJogadores(string numero = null, string apelido = null, string order = "asc")
        {
            List<Jogador> jogadores = new List<Jogador>();
            jogadores = _dataService.SelectPlayers(order, numero, apelido);

            return jogadores;
        }

        public void DeletaJogador(int id)
        {
            _dataService.DeletePlayer(id);
        }
    }
}
