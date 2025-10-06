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
        private ControlRaca controleRaca;
        private ControlAnimal controleAnimal;
        private ControlTutor controleTutor;
        private ControlConsulta controleConsulta;
        private ControlMedicamento controleMedicamento;
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
                              "\n2. Endereço"+
                              "\n3. Raça"+
                              "\n4. Animal"+
                              "\n5. Tutor"+
                              "\n6. Consulta"+
                              "\n7. Medicamento");
                              
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
                    case 3:
                        Console.WriteLine("Raça");
                        ExecutarRaca();
                        break;
                     case 4:
                        Console.WriteLine("Animal");
                        ExecutarAnimal();
                        break;
                    case 5:
                        Console.WriteLine("Tutor");
                        ExecutarTutor();
                        break;
                    case 6:
                        Console.WriteLine("Consulta");
                        ExecutarConsulta();
                        break;
                    case 7:
                        Console.WriteLine("Medicamento");
                        ExecutarMedicamento();
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
                        this.controleVeterinario = new ControlVeterinario();
                        this.controleVeterinario.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Por Codigo");
                        this.controleVeterinario = new ControlVeterinario();
                        this.controleVeterinario.ConsultarPorCodigo();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar Veterinario");
                        //Executando o método
                        this.controleVeterinario = new ControlVeterinario();
                        this.controleVeterinario.Atualizar();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir");
                        this.controleVeterinario = new ControlVeterinario();//Zerando todos os dados - Exclui
                        this.controleVeterinario.Excluir();
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


                        //Chamar o Endereço
                        this.controleEndereco = new ControlEndereco( logradoro, numero, bairro, cidade,  estado,  pais, cep);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados do Endereco
                        this.controleEndereco = new ControlEndereco();
                        this.controleEndereco.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Por Codigo");
                        this.controleEndereco = new ControlEndereco();
                        this.controleEndereco.ConsultarPorCodigo();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar Endereço");
                        //Executando o método
                        this.controleEndereco = new ControlEndereco();
                        this.controleEndereco.Atualizar();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir");
                        this.controleEndereco = new ControlEndereco();//Zerando todos os dados - Exclui
                        this.controleEndereco.Excluir();
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarEndereco

        public void ExecutarRaca()
        {
            do
            {
                Console.WriteLine("\n\nMENU RAÇA\n\n");
                MenuGeral();//Escolher a opção correta
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar\n");
                        //Pegar os dados do Endereco
                        Console.WriteLine("\nInforme a Descrição: ");
                        string descricao = Console.ReadLine(); 

                        Console.WriteLine("\nInforme a Especie: ");
                        string especie = Console.ReadLine();                      


                        //Chamar o RAÇA
                        this.controleRaca = new ControlRaca(descricao, especie);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados de Raça
                        this.controleRaca = new ControlRaca();
                        this.controleRaca.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Por Codigo");
                        this.controleRaca = new ControlRaca();
                        this.controleRaca.ConsultarPorCodigo();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar Raça");
                        //Executando o método
                        this.controleRaca = new ControlRaca();
                        this.controleRaca.Atualizar();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir");
                        this.controleRaca = new ControlRaca();//Zerando todos os dados - Exclui
                        this.controleRaca.Excluir();
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarRaca

        public void ExecutarAnimal()
        {
            do
            {
                Console.WriteLine("\n\nMENU ANIMAL\n\n");
                MenuGeral();//Escolher a opção correta
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar\n");//string nome, DateTime dtNascimento, double peso, int codigoRaca, int codigoTutor
                        //Pegar os dados do Endereco
                        Console.WriteLine("\nInforme o Nome: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("\nInforme a Data de Nascimento: ");
                        DateTime dtNascimento = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("\nInforme o Peso: ");
                        double peso = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("\nInforme o Código de Raca: ");
                        int codigoRaca = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o Código de Tutor: ");
                        int codigoTutor = Convert.ToInt32(Console.ReadLine());
                        //Chamar o Animal
                        this.controleAnimal = new ControlAnimal(nome, dtNascimento, peso, codigoRaca, codigoTutor);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados de Animal
                        this.controleAnimal = new ControlAnimal();
                        this.controleAnimal.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Por Codigo");
                        this.controleAnimal = new ControlAnimal();
                        this.controleAnimal.ConsultarPorCodigo();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar Raça");
                        //Executando o método
                        this.controleAnimal = new ControlAnimal();
                        this.controleAnimal.Atualizar();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir");
                        this.controleAnimal = new ControlAnimal();//Zerando todos os dados - Excluir
                        this.controleAnimal.Excluir();
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarAnimal

        public void ExecutarTutor()
        {
            do
            {
                Console.WriteLine("\n\nMENU TUTOR\n\n");
                MenuGeral();//Escolher a opção correta
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar\n");
                        //Pegar os dados do Endereco
                        Console.WriteLine("\nInforme o Nome: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("\nInforme o CPF: ");
                        long cpf = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o Telefone: ");
                        string telefone = Console.ReadLine();

                        Console.WriteLine("\nInforme o Código de Endereço: ");
                        int codigoEndereco = Convert.ToInt32(Console.ReadLine());

                        //Chamar o Tutor
                        this.controleTutor = new ControlTutor(nome, cpf, telefone, codigoEndereco);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados de Tutor
                        this.controleTutor = new ControlTutor();
                        this.controleTutor.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Por Codigo");
                        this.controleTutor = new ControlTutor();
                        this.controleTutor.ConsultarPorCodigo();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar Raça");
                        //Executando o método
                        this.controleTutor = new ControlTutor();
                        this.controleTutor.Atualizar();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir");
                        this.controleTutor = new ControlTutor();//Zerando todos os dados - Exclui
                        this.controleTutor.Excluir();
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarTutor

        public void ExecutarConsulta()
        {
            do
            {
                Console.WriteLine("\n\nMENU CONSULTA\n\n");
                MenuGeral();//Escolher a opção correta
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar\n"); 
                        Console.WriteLine("\nInforme o Diagnostico: ");
                        string diagnostico = Console.ReadLine();

                        Console.WriteLine("\nInforme o Tratamento: ");
                        string tratamento = Console.ReadLine();

                        Console.WriteLine("\nInforme a Data de Registro: ");
                        DateTime dataRegistro = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("\nInforme o Código de Animal: ");
                        int codigoAnimal = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o Código de Raça: ");
                        int codigoRaca = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o Código de Veterinario: ");
                        int codigoVeterinario = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme o Código de Endereço: ");
                        int codigoEndereco = Convert.ToInt32(Console.ReadLine());

                        //Chamar o Tutor
                        this.controleConsulta = new ControlConsulta(diagnostico, tratamento, dataRegistro, codigoAnimal, codigoRaca, codigoVeterinario, codigoEndereco);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados de Tutor
                        this.controleConsulta = new ControlConsulta();
                        this.controleConsulta.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Por Codigo");
                        this.controleConsulta = new ControlConsulta();
                        this.controleConsulta.ConsultarPorCodigo();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar ");
                        //Executando o método
                        this.controleConsulta = new ControlConsulta();
                        this.controleConsulta.Atualizar();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir");
                        this.controleConsulta = new ControlConsulta();//Zerando todos os dados - Exclui
                        this.controleConsulta.Excluir();
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarConsulta

        public void ExecutarMedicamento()
        {
            do
            {
                Console.WriteLine("\n\nMENU MEDICAMENTO\n\n");
                MenuGeral();//Escolher a opção correta
                switch (ModificarOpcaoGeral)
                {
                    case 0:
                        Console.WriteLine("Voltar ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine("\nCadastrar\n");
                        Console.WriteLine("\nInforme o Descricao: ");
                        string descricao = Console.ReadLine();

                        Console.WriteLine("\nInforme o Dosagem: ");
                        int dosagem = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nInforme a unida de DeMedida: ");
                        string unidadeDeMedida = Console.ReadLine();

                        Console.WriteLine("\nInforme o principio Ativo: ");
                        string principioAtivo = Console.ReadLine();

                        Console.WriteLine("\nInforme o Código de validade: ");
                        DateTime validade = Convert.ToDateTime(Console.ReadLine());
                       

                        //Chamar o Tutor
                        this.controleMedicamento = new ControlMedicamento( descricao,  dosagem,  unidadeDeMedida,  principioAtivo,  validade);
                        break;
                    case 2:
                        Console.WriteLine("\nConsultar");
                        //Chamar os dados de Tutor
                        this.controleMedicamento = new ControlMedicamento();
                        this.controleMedicamento.Imprimir();
                        break;
                    case 3:
                        Console.WriteLine("\nConsultar Por Codigo");
                        this.controleMedicamento = new ControlMedicamento();
                        this.controleMedicamento.ConsultarPorCodigo();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar ");
                        //Executando o método
                        this.controleMedicamento = new ControlMedicamento();
                        this.controleMedicamento.Atualizar();
                        break;
                    case 5:
                        Console.WriteLine("\nExcluir");
                        this.controleMedicamento = new ControlMedicamento();//Zerando todos os dados - Exclui
                        this.controleMedicamento.Excluir();
                        Console.WriteLine("Dado Excluido com Sucesso!!!");
                        break;
                    default:
                        Console.WriteLine("Opção Escolhida não é válida! Tente Novamente!");
                        break;
                }//fim do switch
            } while (ModificarOpcaoGeral != 0);//Fim da repetição
        }//fim do método ExecutarConsulta


    }//Fim da Classe
}//Fim do Projeto 
