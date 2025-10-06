using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    internal class ControlMedicamento
    {
        private DAOMedicamento dao;

        public ControlMedicamento()
        {
            dao = new DAOMedicamento();
        }//fim do construtor
        public int[] codigo;
        public string[] descricao;
        public int[] dosagem;
        public string[] unidadeDeMedida;
        public string[] principioAtivo;
        public DateTime[] validade;

        public ControlMedicamento(string descricao, int dosagem, string unidadeDeMedida, string principioAtivo, DateTime validade)
        {
            this.dao = new DAOMedicamento();
            this.dao.Inserir( descricao,  dosagem,  unidadeDeMedida,  principioAtivo,  validade);
        }//fim do construtor

        //Metodo consultar tudo
        public void Imprimir()
        {
            this.dao = new DAOMedicamento();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir
        //Metodo para consultar codigo
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOMedicamento();
            //Pedindo para o usuario consultar
            Console.WriteLine("Informe o codigo que deseja buscar:");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o metodo consultar por codigo da DAO
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }

        public void Atualizar()
        {
            this.dao = new DAOMedicamento();
            Console.WriteLine("escolha o que deseja atualizar:" + "\n1. descricao \n2. dosagem \n3. unidadeDeMedida \n4. principioAtivo \n5. validade");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Atualizar Descricao");
                    Console.WriteLine("Informe o Descricao de onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o nova Descricao");
                    string descricao = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "descricao", descricao));
                    break;
                case 2:
                    Console.WriteLine("Atualizar Dosagem");
                    Console.WriteLine("Informe o Dosagem de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo Dosagem");
                    int dosagem = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "dosagem", dosagem));
                    break;
                case 3:
                    Console.WriteLine("Atualizar Unidade De Medida");
                    Console.WriteLine("Informe a Unidade De Medida de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe a nova Unidade De Medida");
                    string unidadeDeMedida = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "unidadeDeMedida", unidadeDeMedida));
                    break;
                case 4:
                    Console.WriteLine("Atualizar principio Ativo");
                    Console.WriteLine("Informe o principio Ativo de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o novo principio Ativo");
                    int principioAtivo = Convert.ToInt32(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "principioAtivo", principioAtivo));
                    break;
                case 5:
                    Console.WriteLine("Atualizar Validade");
                    Console.WriteLine("Informe o Validade de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o nova validade");
                    DateTime validade = Convert.ToDateTime(Console.ReadLine());
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "validade", validade));
                    break;
               

                default:
                    Console.WriteLine("Impossivel atualizar algo deu errado!");
                    break;
            }//fim do metodo
        }//fim do atualizar

        public void Excluir()
        {
            this.dao = new DAOMedicamento();

            Console.WriteLine("Informe o codigo que deseja excluir:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //chama o metodo excluir
            Console.WriteLine(this.dao.deletar(codigo));
        }
    }
}
