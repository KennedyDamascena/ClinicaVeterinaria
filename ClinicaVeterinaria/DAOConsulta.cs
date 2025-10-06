using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    class DAOConsulta
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTION
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] diagnostico;
        public string[] tratamento;
        public DateTime[] dataRegistro;
        public int[] codigoAnimal;
        public int[] codigoRaca;
        public int[] codigoVeterinario;
        public int[] codigoEndereco;
        public int i;
        public int contador;
        public string msq;//variavel acumuladora unir os dados da consulta

        public DAOConsulta()
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
        public void Inserir(string diagnostico, string tratamento,DateTime dataRegistro, int codigoAnimal,int codigoRaca,int codigoVeterinario,int codigoEndereco)
        {
            try
            {
                dados = $"('','{diagnostico}','{tratamento}','{dataRegistro}','{codigoAnimal}','{codigoRaca}','{codigoVeterinario}','{codigoEndereco}')";
                comando = $"Insert into consulta (codigo, diagnostico, tratamento, dataRegistro, codigoAnimal, codigoRaca,codigoVeterinario,codigoEndereco) values{dados}";
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
            string query = "select * from consulta";//comando para acessar o dado
            //instanciar os vetores
            codigo = new int[100];
            diagnostico= new string[100];
            tratamento = new string[100];
            dataRegistro = new DateTime[100];
            codigoAnimal = new int[100];
            codigoRaca = new int[100];
            codigoVeterinario = new int[100];
            codigoEndereco = new int[100];

            //reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                diagnostico[i] = "";
                tratamento[i] = "";
                dataRegistro[i] = new DateTime(); 
                codigoAnimal[i] = 0;
                codigoRaca[i] = 0;
                codigoVeterinario[i] = 0;
                codigoEndereco[i] = 0;

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
                diagnostico[i] = leitura["diagnostico"] + "";
                tratamento[i] = leitura["tratamento"] + "";
                dataRegistro[i] = Convert.ToDateTime(leitura["dataRegistro"]);                
                codigoAnimal[i] = Convert.ToInt32(leitura["codigoAnimal"]);
                codigoRaca[i] = Convert.ToInt32(leitura["codigoRaca"]);
                codigoVeterinario[i] = Convert.ToInt32(leitura["codigoVeterinario"]);
                codigoEndereco[i] = Convert.ToInt32(leitura["codigoEndereco"]);
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
                msq += $"\nCódigo:{codigo[i]} \nDiagnostico: {diagnostico[i]} \nTratamento: {tratamento[i]} \nDataRegistro: {dataRegistro[i]} \nCodigoAnimal: {codigoAnimal[i]} \nCodigoRaca: {codigoRaca[i]} \nCodigoVeterinario: {codigoVeterinario[i]} \nCodigoEndereco: {codigoEndereco[i]}\n";
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
                    msq = $"\nCódigo:{this.codigo[i]} \nDiagnostico{diagnostico} \nTratamento: {tratamento[i]} \nDataRegistro: {dataRegistro[i]} \nCodigoAnimal: {codigoAnimal[i]} \nCodigoRaca: {codigoRaca[i]} \nCodigoVeterinario: {codigoVeterinario[i]}  \nCodigoEndereco: {codigoEndereco[i]}\n ";
                    return msq;
                }//fim do if
            }//fim do for
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do metodo

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update consulta set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"update consulta set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"update consulta set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"delete from consulta where codigo = '{codigo}' ";
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
