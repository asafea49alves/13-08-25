using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLibrary.Entities
{
    public abstract class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public List<Livros> LivrosUsuario { get; set; } = new List<Livros>();

        public virtual void ExibirDados()
        {
            // Metodos para exibir dados.
            Console.WriteLine("==================================================================");
            Console.WriteLine("USUARIO");
            Console.WriteLine("==================================================================");
            Console.WriteLine(" ... Id: " + Id);
            Console.WriteLine("==================================================================");
            Console.WriteLine(" ... Nome do usuario: " + Nome);
            if (LivrosUsuario != null)
            {
                Console.WriteLine("==================================================================");
                Console.WriteLine($" ... Possui {LivrosUsuario.Count} Livros");
            }
        }

        public virtual void AdicionarPropies(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public void RetornarLivrosUser(List<Livros> livros)
        {
            foreach(var livro in livros)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("Titulo: "+livro.Titulo);
                Console.WriteLine("Autor: "+livro.Autor);
                Console.WriteLine("Ano De Publicação:"+livro.AnoDePublicacao);
                Console.WriteLine("Disponibilidade: " + livro.Disponibilidade);
            }
        }
    }
}
