using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    internal class ControlMenu
    {
        //Declarar a Variável que representará as classes control
        private ControlVeterinario controleVeterinario;
        private ControlEndereco controleEndereco;
        private int opcaoPrincipal;
        private int opcaoGeral;

        public ControlMenu()
        {
            controleVeterinario = new ControlVeterinario();
            //controleAutor = new ControlAutor();
            //controleCategoria = new ControlCategoria();
        }//fim do construtor

        //Métodos GETs e SETs
        public int ModificarOpcaoPrincipal
        {
            get { return opcaoPrincipal; }
            set { opcaoPrincipal = value; }
        }//fim do método

        public int ModificarOpcaoGeral
        {
            get { return opcaoGeral; }
            set { opcaoGeral = value; }
        }//fim do getSet
        //Mostrar Menu
        public void MostrarMenu()
        {
            Console.Clear();//Limpar o console
            Console.WriteLine("\n\n Menu Principal \n\n" +
                              "Escolha uma das opções abaixo: " +
                              "\n0. Sair" +
                              "\n1. Veterinario"+
                              "\n2. Endereço");
                              
            ModificarOpcaoPrincipal = Convert.ToInt32(Console.ReadLine());
        }//fim do método

        public void ExecutarMenuPrincipal()
        {
            //Mostrar Menu - Chamar o método do menu
            do
            {
                MostrarMenu();
                switch (ModificarOpcaoPrincipal)
                {
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;//fim de cada caso
                    case 1:
                        Console.WriteLine("Veterinario");
                        ExecutarVeterinario();
                        break;
                    case 2:
                        Console.WriteLine("Endereço");
                        ExecutarEndereco();
                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }//fim do escolha
            } while (ModificarOpcaoPrincipal != 0);//fim do while
        }//fim do executar

        public void MenuGeral()
        {
            Console.WriteLine("\n\nEscolha uma das ações do CRUD" +
                             "\n0. Voltar ao menu anterior" +
                             "\n1. Cadastrar" +
                             "\n2. Consultar" +
                             "\n3. Consultar por Codigo" +
                             "\n4. Atualizar" +
                             "\n5. Excluir");
            ModificarOpcaoGeral = Convert.ToInt32(Console.ReadLine());//Coleto a opção do usuário
        }//fim do método
        public void ExecutarVeterinario()
        {
            do
            {
                Console.WriteLine("\n\nMENU VETERINARIO\n\n");
                MenuGeral();//Escolher a opção correta
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar\n");
                        //Pegar os dados do Veterinario
                        Console.WriteLine("\nInforme o CRMV do Veterinario: ");
                        long crmv = Convert.ToInt64(Console.ReadLine());

                        Console.WriteLine("\nInforme a Especialidade do Veterinario: ");
                        string especialidade = Console.ReadLine();

                        Console.WriteLine("\nInforme o Turno do Veterinario: ");
                        string turno = Console.ReadLine();

                        Console.WriteLine("\nInforme o telefone do Veterinario: ");
                        string telefone = Console.ReadLine();

                        Console.WriteLine("\nInforme a Codigo de Endereço do Veterinario: ");

                        int codigoEndereco = Convert.ToInt32(Console.ReadLine());
                        //Chamar o livro
                        this.controleVeterinario = new ControlVeterinario(crmv, especialidade, turno, telefone, codigoEndereco);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados do Veterinario
                        this.controleVeterinario.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("Atualizar Veterinario");
                        //Executando o método
                        this.controleVeterinario.Atualizar();
                        break;
                    case 4:
                        Console.WriteLine("\nExcluir");
                        this.controleVeterinario = new ControlVeterinario();//Zerando todos os dados - Exclui
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarLivro

        public void ExecutarEndereco()
        {
            do
            {
                Console.WriteLine("\n\nMENU ENDEREÇO\n\n");
                MenuGeral();//Escolher a opção correta
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar\n");
                        //Pegar os dados do Endereco
                        Console.WriteLine("\nInforme o Logradoro: ");
                        string logradoro = Console.ReadLine();

                        Console.WriteLine("\nInforme o Número: ");
                        int numero = Convert.ToInt32( Console.ReadLine());

                        Console.WriteLine("\nInforme o Bairro: ");
                        string bairro = Console.ReadLine();

                        Console.WriteLine("\nInforme a cidade: ");
                        string cidade = Console.ReadLine();

                        Console.WriteLine("\nInforme a estado: ");
                        string estado = Console.ReadLine();

                        Console.WriteLine("\nInforme a pais: ");
                        string pais = Console.ReadLine();

                        Console.WriteLine("\nInforme a CEP: ");
                        string cep = Console.ReadLine();


                        //Chamar o livro
                        this.controleEndereco = new ControlEndereco( logradoro, numero, bairro, cidade,  estado,  pais, cep);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados do Endereco
                        this.controleEndereco.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("Atualizar Livro");
                        //Executando o método
                        this.controleEndereco.Atualizar();
                        break;
                    case 4:
                        Console.WriteLine("\nExcluir");
                        this.controleEndereco = new ControlEndereco();//Zerando todos os dados - Exclui
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarLivro

    }//Fim da Classe
}//Fim do Projeto 
