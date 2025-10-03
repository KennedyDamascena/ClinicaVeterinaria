using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    internal class ControlAnimal
    {
        private DAOAnimal dao;

        public ControlAnimal()
        {
            dao = new DAOAnimal();
        }//fim do construtor
        public string[] nome;
        public DateTime[] dtNascimento;
        public double[] peso;
        public int[] codigoRaca;
        public int[] codigoTutor;
        public ControlAnimal(string nome, DateTime dtNascimento, double peso, int codigoRaca, int codigoTutor)
        {
            this.dao = new DAOAnimal();
            this.dao.Inserir( nome, dtNascimento, peso, codigoRaca, codigoTutor);
        }//fim do construtor

        //Metodo consultar tudo
        public void Imprimir()
        {
            this.dao = new DAOAnimal();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir
        //Metodo para consultar codigo
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOAnimal();
            //Pedindo para o usuario consultar
            Console.WriteLine("Informe o codigo que deseja buscar:");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o metodo consultar por codigo da DAO
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }

        public void Atualizar()
        {
            this.dao = new DAOAnimal();
            Console.WriteLine("escolha o que deseja atualizar:" + "\n1. nome \n2. dtNascimento \n3. peso \n4. codigoRaca \n5. codigoTutor ");
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
                    Console.WriteLine("Atualizar Data de Nascimento");
                    Console.WriteLine("Informe o codigo da Data de Nascimento de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe a nova Data de Nascimento");
                    DateTime dtNascimento = Convert.ToDateTime(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "dtNascimento", dtNascimento));
                    break;
                case 3:
                    Console.WriteLine("Atualizar Peso");
                    Console.WriteLine("Informe o codigo do peso de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Peso");
                    double peso = Convert.ToDouble(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "peso", peso));
                    break;
                case 4:
                    Console.WriteLine("Atualizar Código de Raca");
                    Console.WriteLine("Informe o Código de Raca de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Código de Raca");
                    int codigoRaca = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "codigoRaca", codigoRaca));
                    break;
                case 5:
                    Console.WriteLine("Atualizar Código de Tutor");
                    Console.WriteLine("Informe o Código de Tutor de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Código de Tutor");
                    int codigoTutor = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "codigoTutor", codigoTutor));
                    break;


                default:
                    Console.WriteLine("Impossivel atualizar algo deu errado!");
                    break;
            }//fim do metodo
        }//fim do atualizar

        public void Excluir()
        {
            this.dao = new DAOAnimal();

            Console.WriteLine("Informe o codigo que deseja excluir:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //chama o metodo excluir
            Console.WriteLine(this.dao.deletar(codigo));
        }

    }
}
