using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    class ControlRaca
    {
        private DAORaca dao;

        public ControlRaca()
        {
            dao = new DAORaca();
        }//fim do construtor
        public string[] descricao;
        public string[] especie;
        public ControlRaca(string descricao, string especie)
        {
            this.dao = new DAORaca();
            this.dao.Inserir(descricao, especie);
        }//fim do construtor

        //Metodo consultar tudo
        public void Imprimir()
        {
            this.dao = new DAORaca();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir
        //Metodo para consultar codigo
        public void ConsultarPorCodigo()
        {
            this.dao = new DAORaca();
            //Pedindo para o usuario consultar
            Console.WriteLine("Informe o codigo que deseja buscar:");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o metodo consultar por codigo da DAO
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }

        public void Atualizar()
        {
            this.dao = new DAORaca();
            Console.WriteLine("escolha o que deseja atualizar:" + "\n1. descricao \n2. especie ");
            int escolha = Convert.ToInt32(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Atualizar Descrição");
                    Console.WriteLine("Informe o codigo da Descrição de onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o nova Descrição");
                    string descricao = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "descricao", descricao));
                    break;
                case 2:
                    Console.WriteLine("Atualizar Especie");
                    Console.WriteLine("Informe o codigo da Especie de onde vai atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    //nova descrição
                    Console.WriteLine("Informe o nova especie");
                    string especie = Console.ReadLine();
                    //atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "especie", especie));
                    break;               

                default:
                    Console.WriteLine("Impossivel atualizar algo deu errado!");
                    break;
            }//fim do metodo
        }//fim do atualizar

        public void Excluir()
        {
            this.dao = new DAORaca();

            Console.WriteLine("Informe o codigo que deseja excluir:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //chama o metodo excluir
            Console.WriteLine(this.dao.deletar(codigo));
        }

    }//Fim da classe
}//Fim do Projeto
