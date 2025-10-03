using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    class ControlEndereco
    {
        private DAOEndereco dao;

        public ControlEndereco()
        {
            dao = new DAOEndereco();
        }//fim do construtor

        public ControlEndereco(string logradoro, int numero, string bairro, string cidade, string estado, string pais, string cep)
        {
            this.dao = new DAOEndereco();
            this.dao.Inserir(logradoro, numero, bairro, cidade, estado, pais, cep);
        }//fim do construtor

        //Metodo consultar tudo
        public void Imprimir()
        {
            this.dao = new DAOEndereco();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir
        //Metodo para consultar codigo
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOEndereco();
            //Pedindo para o usuario consultar
            Console.WriteLine("Informe o codigo que deseja buscar:");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o metodo consultar por codigo da DAO
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }

        public void Atualizar()
        {
            this.dao = new DAOEndereco();
            Console.WriteLine("escolha o que deseja atualizar:" + "\n1. logradoro \n2. numero \n3. bairro \n4. cidade \n5. estado \n6.pais \n7. cep ");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha) 
            {
                case 1:
                    Console.WriteLine("Atualizar logradoro");
                    Console.WriteLine("Informe o codigo do logradoro de onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo logradoro");
                    string logradoro = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "logradoro", logradoro));
                    break;
                case 2:
                    Console.WriteLine("Atualizar numero");
                    Console.WriteLine("Informe o codigo do numero de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo numero");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "numero", numero));
                    break;
                case 3:
                    Console.WriteLine("Atualizar bairro");
                    Console.WriteLine("Informe o codigo bairro de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo bairro");
                    string bairro = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "bairro", bairro));
                    break;
                case 4:
                    Console.WriteLine("Atualizar cidade");
                    Console.WriteLine("Informe o codigo da cidade de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo cidade");
                    string cidade = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "cidade", cidade));
                    break;
                case 5:
                    Console.WriteLine("Atualizar estado");
                    Console.WriteLine("Informe o o codigo do estado de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo estado");
                    string estado = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "estado", estado));
                    break;
                case 6:
                    Console.WriteLine("Atualizar pais");
                    Console.WriteLine("Informe o codigo do pais de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo pais");
                    string pais = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "pais", pais));
                    break;
                case 7:
                    Console.WriteLine("Atualizar cep");
                    Console.WriteLine("Informe o codigo do cep de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo cep");
                    string cep = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "cep", cep));
                    break;


                default:
                    Console.WriteLine("Impossivel atualizar algo deu errado!");
                    break;
            }//fim do metodo
        }//fim do atualizar

        public void Excluir()
        {
            this.dao = new DAOEndereco();

            Console.WriteLine("Informe o codigo que deseja excluir:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //chama o metodo excluir
            Console.WriteLine(this.dao.deletar(codigo));
        }

    }//fim da Classe
}//fim do Projeto
