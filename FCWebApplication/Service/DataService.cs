using FCWebApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace FCWebApplication
{
    public class DataService
    {
        System.Data.SqlClient.SqlConnection con;
        private SqlConnection DbConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            return con;
        }

        public List<Jogador> SelectPlayers(string order, string numero = null, string apelido = null)
        {
            SqlConnection con = DbConnection();
            con.Open();
            Console.WriteLine("Connection opened");
            string filtro = MakeFilter(numero, apelido);
            SqlCommand command = new SqlCommand("Select " +
                "id, " +
                "nome, " +
                "apelido, " +
                "nascimento, " +
                "altura, " +
                "peso, " +
                "posicao, " +
                "DATEDIFF(year, nascimento, getdate())as idade, " +
                "numero, " +
                "IMC, " +
                "IMC_Status, " +
                "criado_em, " +
                "atualizado_em " +
                "from Jogadores " +
                 filtro  +
                "order by IMC " + order, con);
            if (numero != "" && numero != null) { 
                command.Parameters.AddWithValue("@numero", numero); 
            }
            if (apelido != "" && apelido != null)
            {
                command.Parameters.AddWithValue("@apelido", apelido);
            }
            List<Jogador> jogadores = new List<Jogador>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Jogador jogador = new Jogador
                    {
                        id = (int)reader["id"],
                        nome = (string)reader["nome"],
                        apelido = (string)reader["apelido"],
                        nascimento = (DateTime)reader["nascimento"],
                        altura = (decimal)reader["altura"],
                        peso = (decimal)reader["peso"],
                        posicao = (string)reader["posicao"],
                        idade = (int)reader["idade"],
                        numero = (int)reader["numero"],
                        imc = (decimal)reader["IMC"],
                        imc_status = (string)reader["IMC_Status"],
                        criado_em = (DateTime)reader["criado_em"],
                        atualizado_em = (DateTime)reader["atualizado_em"]
                    };
                    jogadores.Add(jogador);
                }

            }
            con.Close();
            Console.WriteLine("Connection closed");
            return jogadores;
        }

        public Jogador SelectPlayer(int id)
        {
            SqlConnection con = DbConnection();
            con.Open();
            Console.WriteLine("Connection opened");
            SqlCommand command = new SqlCommand("Select " +
                "id, " +
                "nome, " +
                "apelido, " +
                "nascimento, " +
                "altura, " +
                "peso, " +
                "posicao, " +
                "DATEDIFF(year, nascimento, getdate())as idade, " +
                "numero, " +
                "IMC, " +
                "IMC_Status, " +
                "criado_em, " +
                "atualizado_em " +
                "from Jogadores " +
                "where id = @id", con);
            command.Parameters.AddWithValue("@id", id);

            Jogador jogador = new Jogador();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    jogador.id = (int)reader["id"];
                    jogador.nome = (string)reader["nome"];
                    jogador.apelido = (string)reader["apelido"];
                    jogador.nascimento = (DateTime)reader["nascimento"];
                    jogador.altura = (decimal)reader["altura"];
                    jogador.peso = (decimal)reader["peso"];
                    jogador.posicao = (string)reader["posicao"];
                    jogador.idade = (int)reader["idade"];
                    jogador.numero = (int)reader["numero"];
                    jogador.imc = (decimal)reader["IMC"];
                    jogador.imc_status = (string)reader["IMC_Status"];
                    jogador.criado_em = (DateTime)reader["criado_em"];
                    jogador.atualizado_em = (DateTime)reader["atualizado_em"];
                }

            }
            con.Close();
            Console.WriteLine("Connection closed");
            return jogador;
        }

        public void UpdatePlayer(Jogador jogador)
        {
            SqlConnection con = DbConnection();
            con.Open();
            Console.WriteLine("Connection opened");
            SqlCommand command = new SqlCommand("update Jogadores set " +
                "nome = @nome, " +
                "apelido = @apelido, " +
                "nascimento = @nascimento, " +
                "altura = @altura, " +
                "peso = @peso, " +
                "posicao = @posicao, " +
                "numero = @numero, " +
                "IMC = @imc, " +
                "IMC_Status = @imc_status, " +
                "atualizado_em = getdate() " +
                "where id = @id", con);
            command.Parameters.AddWithValue("@id", jogador.id);
            command.Parameters.AddWithValue("@nome", jogador.nome);
            command.Parameters.AddWithValue("@apelido", jogador.apelido);
            command.Parameters.AddWithValue("@nascimento", jogador.nascimento);
            command.Parameters.AddWithValue("@altura", jogador.altura);
            command.Parameters.AddWithValue("@peso", jogador.peso);
            command.Parameters.AddWithValue("@posicao", jogador.posicao);
            command.Parameters.AddWithValue("@numero", jogador.numero);
            command.Parameters.AddWithValue("@imc", jogador.imc);
            command.Parameters.AddWithValue("@imc_status", jogador.imc_status);

            command.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Connection closed");
        }
        public void CreatePlayer(Jogador jogador)
        {
            SqlConnection con = DbConnection();
            con.Open();
            Console.WriteLine("Connection opened");
            SqlCommand command = new SqlCommand("insert into Jogadores (" +
                "nome, " +
                "apelido, " +
                "nascimento, " +
                "altura, " +
                "peso, " +
                "posicao, " +
                "numero, " +
                "IMC, " +
                "IMC_Status, " +
                "criado_em, " +
                "atualizado_em" +
                ") values (" +
                "@nome, " +
                "@apelido, " +
                "@nascimento, " +
                "@altura, " +
                "@peso, " +
                "@posicao, " +
                "@numero, " +
                "@imc, " +
                "@imc_status, " +
                "getdate(), " +
                "getdate())", con);
            command.Parameters.AddWithValue("@nome", jogador.nome);
            command.Parameters.AddWithValue("@apelido", jogador.apelido);
            command.Parameters.AddWithValue("@nascimento", jogador.nascimento);
            command.Parameters.AddWithValue("@altura", jogador.altura);
            command.Parameters.AddWithValue("@peso", jogador.peso);
            command.Parameters.AddWithValue("@posicao", jogador.posicao);
            command.Parameters.AddWithValue("@numero", jogador.numero);
            command.Parameters.AddWithValue("@imc", jogador.imc);
            command.Parameters.AddWithValue("@imc_status", jogador.imc_status);

            command.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Connection closed");
        }

        public void DeletePlayer(int id)
        {
            SqlConnection con = DbConnection();
            con.Open();
            Console.WriteLine("Connection opened");
            SqlCommand command = new SqlCommand("delete from Jogadores where id = @id", con);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Connection closed");
        }

        private string MakeFilter(string numero, string apelido)
        {
            string strFilter = " where ";
            if (numero != "" && numero != null) {
                strFilter += " numero = @numero ";
                if (apelido != "" && apelido != null)
                {
                    strFilter += " and apelido = @apelido ";
                }
                
            }
            else if (apelido != "" && apelido != null) { strFilter += "apelido = @apelido "; }
            else { return ""; }
            return strFilter;
        }
    }
}