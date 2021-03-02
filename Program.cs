using System;
using System.Collections.Generic;

namespace DIOSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Lista de series");
            var lista = repositorio.Lista();
            if(lista.Count==0)
            {
                Console.WriteLine("Nenhuma lista encontrada");
                return;
            }
            foreach(var serie in lista)
            {
                if(!serie.GetExcluido())
                {
                    Console.WriteLine("#ID {0}: {1}", serie.GetId(), serie.GetTitulo());
                }
                
            }
        }

        private static void VizualizarSerie()
        {
           Console.Write("Digite o id da serie");
           int indiceSerie = int.Parse(Console.ReadLine());
           Serie serie = repositorio.RetornaPorId(indiceSerie);
           if(serie.GetExcluido())
           {
               Console.WriteLine("Serie se encontra indisponível");
           }else
           {
               Console.WriteLine(serie); 
           }
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int id = int.Parse(Console.ReadLine());
            List<Serie> lista = repositorio.Lista();
            string serieAserExcluida = lista[id].GetTitulo();
            Console.WriteLine("Deseja mesmo excluir a serie {0}? (s/n)", serieAserExcluida);
            string exclui = Console.ReadLine();
            if(exclui.ToUpper() == "S")
            {
                repositorio.Exclui(id);
                Console.WriteLine("Serie excluida com sucesso.");
            }else
            {
                Console.WriteLine("Serie não excluida.");
            }
            
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int id = int.Parse(Console.ReadLine());
            Serie serieAtualizada = AdquirirSerie(id);
            repositorio.Atualiza(id, serieAtualizada);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");
            Serie novaSerie = AdquirirSerie(repositorio.ProximoId());
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor.");
            Console.WriteLine("Informe a Opcao desejada");

            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static Serie AdquirirSerie( int id)
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }   
            Console.Write("Digite o genero entre as opcoes acima: ");
            int inputGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o titulo da serie: ");
            string inputTitulo = Console.ReadLine();
            Console.Write("Digite o ano de lancamento");
            int inputAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descricao: ");
            string inputDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: id,
                                    genero: (Genero)inputGenero,
                                    titulo: inputTitulo,
                                    ano: inputAno,
                                    descricao: inputDescricao);
            return novaSerie;
        }
    }
}
