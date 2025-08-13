using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLibrary.Entities;
using SystemLibrary.Entities.SubEntities;
using SystemLibrary.Interface;

namespace SystemLibrary
{
    public class Program
    {
        public static void Main()
        {
            var Irtfc = new InterfaceSystem();
            Irtfc.InicialInterface();
            //var jonyUser = new Professor();//jonyUser.AdicionarPropies(1, "Joninnn");//jonyUser.AdicionarDepartamento("Dev");//var ededLibrary = new Biblioteca();//ededLibrary.AdicionarUsuarios(jonyUser);//Livros livro1 = new Livros();//try//{//    livro1.AdicionarPropiedadesLibrary("Tatá Pede Socorro !", "Ricardo Leite", 1991, true);//}//catch//{//    Console.WriteLine("não foi possivel adicionar livro!");//}//ededLibrary.AdicionarLivros(livro1, jonyUser);//ededLibrary.ExibirCatalogos(ededLibrary.Catalogos);//ededLibrary.Emprestimo(jonyUser, "Tatá Pede Socorro !");//ededLibrary.ExibirCatalogos(ededLibrary.Catalogos);//jonyUser.ExibirDados();//jonyUser.RetornarLivrosUser(jonyUser.LivrosUsuario);//ededLibrary.ExibirCatalogos(ededLibrary.Catalogos);
        }
    }
}
