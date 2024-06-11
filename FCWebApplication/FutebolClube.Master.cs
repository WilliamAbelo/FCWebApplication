using FCWebApplication.Model;
using FCWebApplication.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace FCWebApplication
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        private readonly JogadorService jogadorService = new JogadorService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AtualizarTabela();
            }
        }
        private void FeedTable(List<Jogador> jogadores, DataTable dataTable)
        {

            for (int i = 0; i < jogadores.Count; i++)
            {
                Jogador jogador = jogadores[i];
                dataTable.Rows.Add(
                   jogador.id.ToString(),
                   jogador.numero.ToString(),
                   jogador.apelido.ToString(),
                   jogador.posicao.ToString(),
                   jogador.idade.ToString(),
                   jogador.altura.ToString(),
                   jogador.peso.ToString(),
                   jogador.imc.ToString(),
                   jogador.imc_status.ToString()
               ); ; ;
                GridView1.DataSource = dataTable;
            }

            GridView1.DataBind();
        }



        private DataTable CreateTable()
        {
            DataTable dataTable = new DataTable("tbJogadores");

            dataTable.Columns.Add("Id", typeof(String));
            dataTable.Columns.Add("Numero da Camisa", typeof(String));
            dataTable.Columns.Add("Apelido", typeof(string));
            dataTable.Columns.Add("Posicao", typeof(string));
            dataTable.Columns.Add("Idade", typeof(string));
            dataTable.Columns.Add("Altura", typeof(string));
            dataTable.Columns.Add("Peso", typeof(string));
            dataTable.Columns.Add("IMC", typeof(string));
            dataTable.Columns.Add("Classificação do IMC", typeof(string));

            return dataTable;
        }
        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            var id = int.Parse(row.Cells[1].Text);

            btnEnviar.Text = "Editar";
            lblId.InnerText = "Edição";
            txbId.Value = id.ToString();
            FeedTextBox(id);
        }

        protected void Grid2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        private void FeedTextBox(int id)
        {
            Jogador jogador = new Jogador();
            jogador = jogadorService.BuscaJogador(id);

            txbNome.Value = jogador.nome;
            txbApelido.Value = jogador.apelido;
            txbDtNascimento.Value = jogador.nascimento.ToString("yyyy-MM-dd");
            txbAltura.Value = jogador.altura.ToString();
            txbPeso.Value = jogador.peso.ToString();
            txbPosicao.Value = jogador.posicao;
            txbNumero.Value = jogador.numero.ToString();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Jogador jogador = new Jogador
            {
                id = int.Parse(txbId.Value == "" ? "0" : txbId.Value),
                nome = txbNome.Value,
                apelido = txbApelido.Value,
                nascimento = DateTime.Parse(txbDtNascimento.Value),
                altura = decimal.Parse(txbAltura.Value),
                peso = decimal.Parse(txbPeso.Value),
                posicao = txbPosicao.Value,
                numero = int.Parse(txbNumero.Value)
            };

            jogadorService.CriarJogador(jogador);
            AtualizarTabela();
            LimparCampos();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            btnEnviar.Text = "Cadastrar";
            lblId.InnerText = "Cadastro";
            txbId.Value = string.Empty;
            txbNome.Value = string.Empty;
            txbApelido.Value = string.Empty;
            txbDtNascimento.Value = string.Empty;
            txbAltura.Value = string.Empty;
            txbPeso.Value = string.Empty;
            txbPosicao.Value = string.Empty;
            txbNumero.Value = string.Empty;
        }

        private void AtualizarTabela()
        {
            DataTable dataTable = CreateTable();
            List<Jogador> jogadores = jogadorService.ListarJogadores();
            FeedTable(jogadores, dataTable);
        }
    }
}