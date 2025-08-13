using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLibrary.Entities.SubEntities;

namespace SystemLibrary.Entities
{
    public class Biblioteca
    {
        public string Nome { get; private set; }
        public List<Livros> Catalogos { get; private set; } = new List<Livros>();

        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();

        public void ExibirCatalogos(List<Livros> livro)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("====== Livros Disponiveis =====");
            Console.WriteLine("===============================\n");

            foreach (Livros l in livro) 
            {
                Console.WriteLine("==================================================================");
                Console.WriteLine("Nome do Livro: "+l.Titulo);
                Console.WriteLine("==================================================================");
                Console.WriteLine("Nome do Autor: "+l.Autor);
                Console.WriteLine("==================================================================");
                Console.WriteLine("Ano: "+l.AnoDePublicacao);
                Console.WriteLine("==================================================================");
                Console.WriteLine("Disponibilidade: "+l.Disponibilidade);
                Console.WriteLine("==================================================================\n");
            }
        }

        public void AdicionarNome(string nome)
        {
            this.Nome = nome;
        }

        public string AdicionarLivros(Livros livros, Usuario usuario) 
        {
            var user = ValidationUserLogin(usuario);

            if (user != null )
            {
                this.Catalogos.Add(livros);
                return "Cadastro realizado com sucesso do usuario: " + livros;
            }
            return "Não foi possivel realizar o cadastro do livro: " + livros;
        }
        
        public string AdicionarUsuarios(Usuario usuario)
        {   
            var user = ValidationUser(usuario);
            if (user != null)
            {
                this.Usuarios.Add(user);
                return "Cadastro realizado com sucesso do usuario: " + usuario;
            }
            return "Não foi possivel realizar o cadastro do Usuaro: " + usuario;
        }

        public string Emprestimo(Usuario usuario, string nomeLivro) 
        {   
            var user = ValidationUserLogin(usuario);

            if (user != null)
            {
                foreach(var livroCatalogo in Catalogos)
                {
                    if (nomeLivro == livroCatalogo.Titulo)
                    {
                        if (livroCatalogo.Disponibilidade == true)
                        {
                            user.LivrosUsuario.Add(livroCatalogo);
                            Catalogos.Remove(livroCatalogo);
                            foreach (var livrosUser in user.LivrosUsuario)
                            {
                                if (livrosUser.Disponibilidade == false)
                                    livrosUser.AlterarDisponibilidade(true);
                                    return "Emprestimo realizado com sucesso do livro: " + nomeLivro;
                            }
                        }
                    }
                }
            }
            return "Não foi Possivel realizar a Emprestimo do Livro: " + nomeLivro;
        }

        public string Devolucoes(Usuario usuario, string nomeLivro)
        {
            var user = ValidationUser(usuario);

            if (user != null)
            {
                foreach (var livrosCatalogos in usuario.LivrosUsuario)
                {
                    if (nomeLivro == livrosCatalogos.Titulo)
                    {
                        usuario.LivrosUsuario.Remove(livrosCatalogos);
                        return "Devolução realizada com sucesso do livro: "+nomeLivro;
                    }
                }
            }
            return "Não foi Possivel realizar a Devolução do Livro: " + nomeLivro;
        }


        public Usuario ValidationUser(Usuario usuario)
        {
            foreach (var usuarioSet in Usuarios)
            {
                if (usuario == usuarioSet)
                {
                    return null;
                }
            }
            return usuario;
        }

        public Usuario ValidationUserLogin(Usuario usuario)
        {
            foreach (var usuarioSet in Usuarios)
            {
                if (usuario != usuarioSet)
                {
                    return null;
                }
            }
            return usuario;
        }
    }
}
