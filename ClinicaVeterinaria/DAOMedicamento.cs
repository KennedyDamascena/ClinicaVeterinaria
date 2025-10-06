using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    internal class DAOMedicamento
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTION
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] descricao;
        public int[] dosagem;
        public string[] unidadeDeMedida;
        public string[] principioAtivo;
        public DateTime[] validade;        
        public int i;
        public int contador;
        public string msq;//variavel acumuladora unir os dados da consulta

        public DAOMedicamento()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=veterinaria;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();//Tenta abrir a conexao com o Banco de Dados
                Console.WriteLine("Conectado Sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu errado!\n\n {erro}");
                conexao.Close();//Fechar a conexao
            }//fim do try_catch
        }//fim do construtor
        public void Inserir(string descricao, int dosagem, string unidadeDeMedida, string principioAtivo, DateTime validade)
        {
            try
            {
                dados = $"('','{descricao}','{dosagem}','{unidadeDeMedida}','{principioAtivo}','{validade}')";
                comando = $"Insert into consulta (codigo, descricao, dosagem, unidadeDeMedida, principioAtivo, validade) values{dados}";
                //Lançar os dados no banco
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();// Comando de inserção/Ações
                Console.WriteLine($"Inserido com sucesso! {resultado}");//Visualização do resultado
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu Errado!\n\n {erro}");
            }//fim do catch
        }//fim do inserir
        //Metodo  para preeecher
        public void preencherVetor()
        {
            string query = "select * from medicamento";//comando para acessar o dado
            //instanciar os vetores
            codigo = new int[100];
            descricao = new string[100];
            dosagem = new int[100];
            unidadeDeMedida = new string[100];
            principioAtivo = new string[100];
            validade = new DateTime[100];            

            //reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                descricao[i] = "";
                dosagem[i] = 0;
                unidadeDeMedida[i] = "";
                principioAtivo[i] = "";
                validade[i] = new DateTime();
                

            }//fim for

            //executar o comando no Banco de Dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura dos Dados do banco por linha
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;
            //Buscar os Dados 
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                descricao[i] = leitura["descricao"] + "";
                dosagem[i] = Convert.ToInt32(leitura["dosagem"]);
                unidadeDeMedida[i] = leitura["unidadeDeMedida"] + "";
                principioAtivo[i] = leitura["principioAtivo"]+ "";
                validade[i] = Convert.ToDateTime(leitura["validade"]);                
                i++;//ande o vetor
                contador++;//Contar exatamente quantos dados foram inseridos
            }//fim do while
             //Fechar a leitura dos dados com banco de dados
            leitura.Close();
        }//preencher

        public string ConsultarTudo()
        {
            //Preecher Vetor
            preencherVetor();
            msq = "";//Instanciar Variavel
            for (i = 0; i < contador; i++)
            {
                msq += $"\nCódigo:{codigo[i]} \nDescricao: {descricao[i]} \nDosagem: {dosagem[i]} \nUnidadeDeMedida: {unidadeDeMedida[i]} \nPrincipioAtivo: {principioAtivo[i]} \nValidade: {validade[i]} \n";
            }//Fim do for 
            return msq;
            //Mostrar bd
        }//Fim
        public string ConsultarPorCodigo(int codigo)
        {
            preencherVetor();
            msq = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msq = $"\nCódigo:{this.codigo[i]} \nDescricao: {descricao[i]} \nDosagem: {dosagem[i]} \nUnidadeDeMedida: {unidadeDeMedida[i]} \nPrincipioAtivo: {principioAtivo[i]} \nValidade: {validade[i]} \n";
                    return msq;
                }//fim do if
            }//fim do for
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do metodo

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update medicamento set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "dado altualizado com sucesso!";

            }
            catch (Exception erro)
            {
                return $"\nAlgo Deu errado!\n\n{erro}";
            }
        }//Fim do Metodo

        public string Atualizar(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update medicamento set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "dado altualizado com sucesso!";

            }
            catch (Exception erro)
            {
                return $"\nAlgo Deu errado!\n\n{erro}";
            }
        }//Fim do Metodo

        public string Atualizar(int codigo, string campo, DateTime novoDado)
        {
            try
            {
                string query = $"update medicamento set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "dado altualizado com sucesso!";

            }
            catch (Exception erro)
            {
                return $"\nAlgo Deu errado!\n\n{erro}";
            }
        }//Fim do Metodo



        public string deletar(int codigo)
        {
            try
            {
                string query = $"delete from medicamento where codigo = '{codigo}' ";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado excluido";
            }
            catch (Exception erro)
            {
                return $"algo deu errado\n\n {erro}";
            }
        }
    }
}
