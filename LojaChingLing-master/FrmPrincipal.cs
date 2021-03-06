﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LojaCL
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public void CarregadgvPripedi()
        {
            SqlConnection con = clConexao.obterConexao();
            String query = "select * from cartaovenda";
            SqlCommand cmd = new SqlCommand(query, con);
            clConexao.obterConexao();
            cmd.CommandType = CommandType.Text;
            //SqlDataAdapter, preencher datatable
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable cartao = new DataTable();
            da.Fill(cartao);
            dgvPripedi.DataSource = cartao;
            DataGridViewButtonColumn fechar = new DataGridViewButtonColumn();
            fechar.Name = "FecharConta";
            fechar.HeaderText = "Fechar Conta";
            fechar.Text = "Fechar Conta";
            fechar.UseColumnTextForButtonValue = true;
            int columIndex = 4;
            dgvPripedi.Columns.Insert(columIndex, fechar);
            clConexao.fecharConexao();
            dgvPripedi.CellClick += dgvPripedi_CellClick;
            int colunas = dgvPripedi.Columns.Count;
            if(colunas > 5)
            {
                dgvPripedi.Columns.Remove("FecharConta");
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrudCliente cli = new FrmCrudCliente();
            cli.Show();
        }

        private void testarBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = clConexao.obterConexao();
                String query = "select * from cliente";
                SqlCommand cmd = new SqlCommand(query, con);
                clConexao.obterConexao();
                DataSet ds = new DataSet();
                MessageBox.Show("Conectado ao Banco de Dados com Sucesso!", "Teste de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clConexao.fecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrudProduto pro = new FrmCrudProduto();
            pro.Show();
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVenda ven = new FrmVenda();
            ven.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrudUsuario usu = new FrmCrudUsuario();
            usu.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CarregadgvPripedi();
        }

        private void ferramentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvPripedi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == dgvPripedi.Columns["FecharConta"].Index)
                {
                    if(Application.OpenForms["FrmVenda"]== null)
                    {
                        FrmVenda ven = new FrmVenda();
                        ven.Show();
                    }
                }
            }
            catch
            {

            }
        }

        private void cartãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCartao car = new FrmCartao();
            car.Show();
        }

        private void dgvPripedi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
