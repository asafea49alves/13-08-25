using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLibrary.Entities;

namespace SystemLibrary.Entities
{
    public class Livros
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int AnoDePublicacao { get; private set; }
        public bool Disponibilidade { get; private set; }

        public void ExibirInformacoes()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"Livro: {this.Titulo}, Autor: {this.Autor}, Ano {AnoDePublicacao}");
            Console.WriteLine(Disponibilidade);
        }
        public Livros Emprestar(Livros livro, Usuario usuario)
        {
            // que altera o status de disponibilidade
            if (this.Disponibilidade != false)
            {
                Console.WriteLine("Disponivel");
                return livro;
            }
            Console.WriteLine("Não está disponivel");
            return null;

        }
        public Livros Devolver(Livros livro, Usuario usuario)
        {
            // que altera o status de volta para disponível

            if (this.Disponibilidade != false)
            {
                Console.WriteLine("Disponivel");
                return livro;
            }
            Console.WriteLine("Não está disponivel"); return null;
        }

        public void AdicionarPropiedadesLibrary(string titulo, string autor, int anoPublicacao, bool disponibiliadade)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.AnoDePublicacao = anoPublicacao;
            this.Disponibilidade = disponibiliadade;
        }

        public void AlterarDisponibilidade(bool disponibilidade)
        {
            this.Disponibilidade = disponibilidade;
        }

    }
}
