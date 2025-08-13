using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLibrary.Entities.SubEntities
{
    public class Aluno : Usuario
    {
        public string Curso { get; set; }

        public override void ExibirDados()
        {
            base.ExibirDados();
            Console.WriteLine(Curso);
        }
    }
}
