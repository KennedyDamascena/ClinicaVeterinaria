using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControlMenu menuPrincipal = new ControlMenu();//Declarando e instanciando uma variável
            menuPrincipal.ExecutarMenuPrincipal();
        }
    }
}
