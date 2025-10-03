using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    internal class DAOAnimal
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTION
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public DateTime[] dtNascimento;
        public double[] peso;    
        public int[] codigoRaca;
        public int[] codigoTutor;
        public int i;
        public int contador;
        public string msq;//variavel acumuladora unir os dados da consulta

        public DAOAnimal()
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
        public void Inserir(string nome, DateTime dtNascimento, double peso, int codigoRaca, int codigoTutor)
        {
            try
            {
                dados = $"('','{nome}','{dtNascimento}','{peso}','{codigoRaca}','{codigoTutor}')";
                comando = $"Insert into animal (codigo, nome, dtNascimento, peso, codigoRaca, codigoTutor) values{dados}";
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
            string query = "select * from animal";//comando para acessar o dado
            //instanciar os vetores
            codigo = new int[100];
            nome = new string[100];
            dtNascimento = new DateTime[100];
            peso = new double[100];
            codigoRaca = new int[100];
            codigoTutor = new int[100];

            //reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                dtNascimento[i] = new DateTime();
                peso[i] = 0;
                codigoRaca[i] = 0;
                codigoTutor[i] = 0;

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
                nome[i] = leitura["nome"] + "";
                dtNascimento[i] = Convert.ToDateTime(leitura["dtNascimento"]);
                peso[i] = Convert.ToDouble(leitura["peso"]);
                codigoRaca[i]= Convert.ToInt32(leitura["codigo"]); ;
                codigoTutor[i]= Convert.ToInt32(leitura["codigo"]); ;
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
                msq += $"\nCódigo:{codigo[i]} \nnome: {nome[i]} \nDtNascimento: {dtNascimento[i]} \nPeso: {peso[i]} \nCodigoRaca: {codigoRaca[i]} \ncodigoTutor: {codigoTutor[i]}\n";
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
                    msq = $"\nCódigo:{this.codigo[i]} \nNome: {nome[i]} \nDtNascimento: {dtNascimento[i]} \nPeso: {peso[i]} \nCodigoRaca: {codigoRaca[i]} \ncodigoTutor: {codigoTutor[i]}\n";
                    return msq;
                }//fim do if
            }//fim do for
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do metodo

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update animal set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"update animal set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"update animal set {campo} = '{novoDado}' where codigo = '{codigo}'";
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

        public string Atualizar(int codigo, string campo, double novoDado)
        {
            try
            {
                string query = $"update animal set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"delete from animal where codigo = '{codigo}' ";
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
