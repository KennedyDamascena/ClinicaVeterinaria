using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    internal class ControlConsulta
    {
        private DAOConsulta dao;

        public ControlConsulta()
        {
            dao = new DAOConsulta();
        }//fim do construtor
        public string[] diagnostico;
        public string[] tratamento;
        public DateTime[] dataRegistro;
        public int[] codigoAnimal;
        public int[] codigoRaca;
        public int[] codigoVeterinario;
        public int[] codigoEndereco;

        public ControlConsulta(string diagnostico, string tratamento, DateTime dataRegistro, int codigoAnimal, int codigoRaca, int codigoVeterinario, int codigoEndereco)
        {
            this.dao = new DAOConsulta();
            this.dao.Inserir( diagnostico,  tratamento,  dataRegistro,  codigoAnimal,  codigoRaca,  codigoVeterinario,  codigoEndereco);
        }//fim do construtor

        //Metodo consultar tudo
        public void Imprimir()
        {
            this.dao = new DAOConsulta();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir
        //Metodo para consultar codigo
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOConsulta();
            //Pedindo para o usuario consultar
            Console.WriteLine("Informe o codigo que deseja buscar:");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o metodo consultar por codigo da DAO
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }

        public void Atualizar()
        {
            this.dao = new DAOConsulta();
            Console.WriteLine("escolha o que deseja atualizar:" + "\n1. diagnostico \n2. tratamento \n3. dataRegistro \n4. codigoAnimal \n5. codigoRaca  \n6. codigoVeterinario  \n7. codigoEndereco");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Atualizar Diagnostico");
                    Console.WriteLine("Informe o Diagnostico de onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Diagnostico");
                    string diagnostico = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "diagnostico", diagnostico));
                    break;
                case 2:
                    Console.WriteLine("Atualizar Tratamento");
                    Console.WriteLine("Informe o Tratamento de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo tratamento");
                    string tratamento = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "tratamento", tratamento));
                    break;
                case 3:
                    Console.WriteLine("Atualizar Data de Registro");
                    Console.WriteLine("Informe a Data de Registro de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe a nova Data de Registro");
                    DateTime dataRegistro = Convert.ToDateTime(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "dataRegistro", dataRegistro));
                    break;
                case 4:
                    Console.WriteLine("Atualizar Código de Animal");
                    Console.WriteLine("Informe o Codigo do Animal de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Codigo do Animal");
                    int codigoAnimal = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "codigoAnimal", codigoAnimal));
                    break;
                case 5:
                    Console.WriteLine("Atualizar Código de Raca");
                    Console.WriteLine("Informe o Código de Raca de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Código de Raca");
                    int codigoRaca = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "codigoRaca", codigoRaca));
                    break;
                case 6:
                    Console.WriteLine("Atualizar Código de Veterinario");
                    Console.WriteLine("Informe o Código de Veterinario de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Código de Veterinario");
                    int codigoVeterinario = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "codigoVeterinario", codigoVeterinario));
                    break;
                case 7:
                    Console.WriteLine("Atualizar Código de Endereço");
                    Console.WriteLine("Informe o Código de Endereço de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Código de Endereço");
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
            this.dao = new DAOConsulta();

            Console.WriteLine("Informe o codigo que deseja excluir:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //chama o metodo excluir
            Console.WriteLine(this.dao.deletar(codigo));
        }
    }
}
