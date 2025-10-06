using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    internal class ControlTutor
    {
        private DAOTutor dao;

        public ControlTutor()
        {
            dao = new DAOTutor();
        }//fim do construtor
        public string[] nome;
        public long[] cpf;
        public string[] telefone;
        public int[] codigoEndereco;
        
        public ControlTutor(string nome, long cpf, string telefone, int codigoEndereco)
        {
            this.dao = new DAOTutor();
            this.dao.Inserir(nome, cpf, telefone, codigoEndereco);
        }//fim do construtor

        //Metodo consultar tudo
        public void Imprimir()
        {
            this.dao = new DAOTutor();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir
        //Metodo para consultar codigo
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOTutor();
            //Pedindo para o usuario consultar
            Console.WriteLine("Informe o codigo que deseja buscar:");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o metodo consultar por codigo da DAO
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }

        public void Atualizar()
        {
            this.dao = new DAOTutor();
            Console.WriteLine("escolha o que deseja atualizar:" + "\n1. nome \n2. cpf \n3. telefone \n4. codigoEndereco ");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Atualizar Nome");
                    Console.WriteLine("Informe o codigo do Nome de onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Nome");
                    string nome = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "nome", nome));
                    break;
                case 2:
                    Console.WriteLine("Atualizar CPF");
                    Console.WriteLine("Informe o CPF de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo CPF");
                    long cpf = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "cpf", cpf));
                    break;
                case 3:
                    Console.WriteLine("Atualizar telefone");
                    Console.WriteLine("Informe o telefone de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo telefone");
                    string telefone = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "telefone", telefone));
                    break;
                case 4:
                    Console.WriteLine("Atualizar Código de Endereço");
                    Console.WriteLine("Informe o Código de Endereço de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Código de Raca");
                    int codigoEndereco = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "codigoEndereco", codigoEndereco));
                    break;


                default:
                    Console.WriteLine("Impossivel atualizar algo deu errado!");
                    break;
            }//fim do metodo
        }//fim do atualizar

        public void Excluir()
        {
            this.dao = new DAOTutor();

            Console.WriteLine("Informe o codigo que deseja excluir:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //chama o metodo excluir
            Console.WriteLine(this.dao.deletar(codigo));
        }
    }
}
