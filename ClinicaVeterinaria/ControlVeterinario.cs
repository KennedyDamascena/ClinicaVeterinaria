using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    class ControlVeterinario
    {
        private DAOVeterinario dao;

        public ControlVeterinario()
        {
           dao = new DAOVeterinario();
        }//fim do construtor

        public ControlVeterinario(long crmv, string especialidade, string turno, string telefone, int codigoEndereco)
        {
            this.dao = new DAOVeterinario();
            this.dao.Inserir(crmv, especialidade, turno, telefone, codigoEndereco);
        }//fim do construtor

        //Metodo consultar tudo
        public void Imprimir()
        {
            this.dao = new DAOVeterinario();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir
        //Metodo para consultar codigo
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOVeterinario();
            //Pedindo para o usuario consultar
            Console.WriteLine("Informe o codigo que deseja buscar:");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o metodo consultar por codigo da DAO
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }

        public void Atualizar()
        {
            this.dao = new DAOVeterinario();
            Console.WriteLine("escolha o que deseja atualizar:" + "\n1. crmv \n2. especialidade \n3. turno \n4. telefone \n5. codigoEndereco");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Atualizar CRMV");
                    Console.WriteLine("Informe o CRMV de onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o CRMV");
                    long crmv = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "CRMV", crmv));
                    break;
                case 2:
                    Console.WriteLine("Atualizar Especialidade");
                    Console.WriteLine("Informe a Especialidade de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o especialidade");
                    string especialidade = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "especialidade", especialidade));
                    break;
                case 3:
                    Console.WriteLine("Atualizar Turno");
                    Console.WriteLine("Informe o Turno de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o Turno");
                    string turno = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "Turno", turno));
                    break;
                case 4:
                    Console.WriteLine("Atualizar Telefone");
                    Console.WriteLine("Informe o Telefone de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o Telefone");
                    string telefone = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "Telefone", telefone));
                    break;
                case 5:
                    Console.WriteLine("Atualizar Codigo de Endereço");
                    Console.WriteLine("Informe o Codigo de Endereço de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o Codigo de Endereço");
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
            this.dao = new DAOVeterinario();

            Console.WriteLine("Informe o codigo que deseja excluir:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //chama o metodo excluir
            Console.WriteLine(this.dao.deletar(codigo));
        }
    }//fim da classe
}//fim do projeto
