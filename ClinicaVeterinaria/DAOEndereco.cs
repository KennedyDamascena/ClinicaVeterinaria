using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    class DAOEndereco
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTION
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] logradoro;
        public int[] numero;
        public string[] bairro;
        public string[] cidade;
        public string[] estado;
        public string[] pais;
        public string[] cep;
        public int i;
        public int contador;
        public string msq;//variavel acumuladora unir os dados da consulta
        
        public DAOEndereco()
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
        public void Inserir(string logradoro, int numero, string bairro, string cidade, string estado, string pais, string cep)
        {
            try
            {
                dados = $"('','{logradoro}', '{numero}','{bairro}','{cidade}','{estado}','{pais}','{cep}')";
                comando = $"Insert into endereco(codigo,logradoro,numero,bairro,cidade,estado,pais,cep) values{dados}";
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
            string query = "select * from endereco";//comando para acessar o dado
            //instanciar os vetores
            codigo = new int[100];
            logradoro = new string[100];
            numero = new int[100];
            bairro = new string[100];
            cidade = new string[100];
            estado = new string[100];
            pais = new string[100];
            cep = new string[100];

            //reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                logradoro[i] = "";
                numero[i] = 0;
                bairro[i] = "";
                cidade[i] = "";
                estado[i] = "";
                pais[i] = "";
                cep[i] = "";
               
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
                logradoro[i] = leitura["logradoro"] + "";
                numero[i] = Convert.ToInt32(leitura["numero"]);
                bairro[i] = leitura[" bairro"] + "";
                cidade[i] = leitura["cidade"] + "";
                estado[i] = leitura["estado"] + "";
                pais[i]= leitura["pais"] + "";
                cep[i]= leitura["cep"] + "";

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
                msq += $"\nCódigo:{codigo[i]} \nLogradoro: {logradoro[i]}\nNumero: {numero[i]} \nBairro: {bairro[i]}\nCidade: {cidade[i]}\nEstado: {estado[i]}\nPais: {pais[i]} \nCEP {cep[i]}";
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
                    msq = $"\nCódigo:{this.codigo[i]} \nLogradoro: {logradoro[i]}\nNumero: {numero[i]} \nBairro: {bairro[i]}\nCidade: {cidade[i]}\nEstado: {estado[i]}\nPais: {pais[i]} \nCEP {cep[i]}";
                    return msq;
                }//fim do if
            }//fim do for
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do metodo

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update Veterinario set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"update endereco set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"delete from endereco where codigo = '{codigo}' ";
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
