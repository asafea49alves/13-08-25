using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLibrary.Entities;
using SystemLibrary.Entities.SubEntities;
using SystemLibrary.ValidationOfUsers;

namespace SystemLibrary.Interface
{
    public class InterfaceSystem
    {

        public List<Biblioteca> ListaDeLibrary { get; private set; } = new List<Biblioteca>();
        public List<Usuario> usuarios { get; set; } = new List<Usuario>();
        public List<Livros> Livros { get; set; } = new List<Livros>();

        public void InicialInterface()
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("===================== LIBRARY SYSTEM =========================");
            Console.WriteLine("==============================================================\n");

            Console.Write("Digite [1] para cadastrar e [2] para fazer o login:> ");
            var input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                var usuario = CriarUsuario();

                foreach(var usuariobibliotecas in ListaDeLibrary)
                {
                    usuariobibliotecas.AdicionarUsuarios(usuario);
                }
                ProgramInicialInteface(usuario);
            }
            else if (input == 2) 
            {
                var usuario = FazerLogin();
                //ProgramInicialInteface(usuario);
            }
        }

        private Usuario FazerLogin()
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("===================== LIBRARY SYSTEM =========================");
            Console.WriteLine("==============================================================\n");

            Console.Write("Digite o nome do usuario:> ");
            var nomeLogin = Console.ReadLine().ToString();

            foreach(var usuariobiblioteca in ListaDeLibrary)
            {
                foreach(var usuarioUsuarios in usuariobiblioteca.Usuarios)
                {
                    if (nomeLogin == usuarioUsuarios.Nome)
                    {
                        return usuarioUsuarios;
                    }
                }
            }
            return null;

            //var validUser = Biblioteca.ValidationUserLogin();\
        }
        public Usuario CriarUsuario()
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("===================== LIBRARY SYSTEM =========================");
            Console.WriteLine("==============================================================\n");

            Console.WriteLine("===========================");
            Console.Write("Digite um nome:> ");
            var nomeUser = Console.ReadLine().ToString();
            Console.WriteLine("==============================");
            Console.Write("Aluno[1] e Professor[2]: ");
            var tipoUser = int.Parse(Console.ReadLine());

            if (tipoUser == ((int)EnumDepartamento.Aluno))
            {
                var aluno = new Aluno();
                int id = usuarios.Count + 1;
                aluno.AdicionarPropies(id, nomeUser);
                usuarios.Add(aluno);
                return aluno;
            }
            if (tipoUser.ToString() == EnumDepartamento.Professor.ToString())
            {
                var professor = new Professor();
                int id = usuarios.Count + 1 ;
                professor.AdicionarPropies(id, nomeUser);
                usuarios.Add(professor);
                return professor;
            }
            return null;
            
        }
        private void ProgramInicialInteface(Usuario usuario)
        {
            Console.Clear();
            Console.WriteLine("==============================================================");
            Console.WriteLine("===================== LIBRARY SYSTEM =========================");
            Console.WriteLine("==============================================================\n");

            Console.WriteLine("Para listar as bibliotecas Disponiveis digite [1]");
            Console.WriteLine("Para criar sua propria Biblioteca [2]");
            Console.Write("Parar criar novos Livors [3]:> ");
            try
            {
                var inputLibrary = int.Parse(Console.ReadLine());
                
                if (inputLibrary == 1)
                {
                    ListarBibliotecas(usuario);
                    ProgramInicialInteface(usuario);
                }
                else if (inputLibrary == 2)
                {
                    CriarNovaLibrary();
                    ProgramInicialInteface(usuario);
                }
                else if (inputLibrary == 3)
                {
                    CriarLivros(usuario);
                    //ProgramInicialInteface(usuario);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ProgramInicialInteface(usuario) ;
            }
        }

        private void CriarLivros(Usuario usuario)
        {
            if (usuario != null)
            {
                
                var livro = new Livros();
                Console.WriteLine("====================================================");
                Console.Write("Digite o Titulo do livro:> ");
                var titulo = Console.ReadLine().ToString();

                Console.WriteLine("======================================================");
                Console.Write("Digite o nome do Autor do Livro:> ");
                var autor = Console.ReadLine().ToString();
            
                Console.WriteLine("======================================================");
                Console.WriteLine("Digite o ano de lançamento:> ");
                var anoPublicação = int.Parse(Console.ReadLine());
            
                var disponibilidade = true;
                livro.AdicionarPropiedadesLibrary(titulo, autor, anoPublicação, disponibilidade);
                
                AdicionarLivrosLibrary(livro, usuario);
            }
        }
        private void AdicionarLivrosLibrary(Livros livro, Usuario usuario)
        {

            ListarBibliotecas(usuario);
            Console.WriteLine("===================================================");
            Console.WriteLine("Em qual lib você quer adicionar esse livro: ");
            var numeroLib = int.Parse(Console.ReadLine());

            ListaDeLibrary[numeroLib].AdicionarLivros(livro, usuario);
            ListarCatalogo(usuario);
        }
        public void ListarBibliotecas(Usuario usuario)
        {
            Console.Clear();

            for (int i = 0; i < this.ListaDeLibrary.Count; i++)
            {
                Console.WriteLine($"{i} {ListaDeLibrary[i].Nome.ToString()}");
            }
            Console.WriteLine("==========================================");
            Console.WriteLine("Deseja listar catalogo[y/n]");
            var input = Console.ReadLine().ToLower().ToString();
            if (input != "y")
            {
                return;
            }

        }

        public void ListarCatalogo(Usuario usuario)
        {

            //Console.WriteLine("==================================================");
            //Console.Write("Você Deseja Listar Catalogo[y/n]: ");
            //var validationCatalogo = Console.ReadLine().ToLower().ToString();

            //if (validationCatalogo != "y")
            //{
            //    Console.Clear();
            //    ProgramInicialInteface(usuario);
            //}
            
            Console.WriteLine("=============================================");
            Console.Write("Qual o numero da lib que você deseja: ");
            var inputBiblioteca = int.Parse(Console.ReadLine());


            if (inputBiblioteca > ListaDeLibrary.Count || inputBiblioteca < 0)
            {
                Console.WriteLine("Não temos esse numero no catalogo");
                ProgramInicialInteface(usuario);
            }
            else
            {
                ListaDeLibrary[inputBiblioteca].ExibirCatalogos(ListaDeLibrary[inputBiblioteca].Catalogos);
                Console.WriteLine(ListaDeLibrary[inputBiblioteca].Catalogos.Count);
                //ProgramInicialInteface(usuario);
            }

        }

        public void CriarNovaLibrary()
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.Write("Digite Um nome para sua nova biblioteca: ");
            var nomeLibrary = Console.ReadLine().ToString();
            var biblioteca = new Biblioteca();
            biblioteca.AdicionarNome(nomeLibrary);
            this.ListaDeLibrary.Add(biblioteca);

        }
    }
}
