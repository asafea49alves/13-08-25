using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLibrary.Entities.SubEntities
{
    public class Professor : Usuario
    {
        public string Departamento { get; private set; }

        public override void ExibirDados()
        {
            base.ExibirDados();
            Console.WriteLine("========================================================");
            Console.WriteLine($" ... DEPARTAMENTO: {Departamento} ... ");
            Console.WriteLine("==================================");

        }
        public void AdicionarDepartamento(string departamento)
        {
            this.Departamento = departamento;
        }
    }
}
