using Service;
using System;

namespace CadastroPeopleListV2
{
    internal class Program
    {
        private static ICadastraPessoa iCadastraPessoa;

        private static void AddPerson() => iCadastraPessoa.AddPerson();

        private static void ShowPeople() => iCadastraPessoa.ShowPeople();

        private static void SearchPersonById() => iCadastraPessoa.SearchPersonById();

        private static void EditPerson() => iCadastraPessoa.EditPerson();

        private static void RemovePerson() => iCadastraPessoa.DeletePerson();

        private static void InvalidOption() => Console.WriteLine("Opção inválida");

        private static ICadastraPessoa getInstancePessoa()
        {
            return new CadastraPessoaV2();
        }

        static void Main(string[] args)
        {
            iCadastraPessoa = getInstancePessoa();
            string option = "";

            while(option != "0")
            {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("[ 1 ] - Adicionar Pessoa");
                Console.WriteLine("[ 2 ] - Exibir Pessoas");
                Console.WriteLine("[ 3 ] - Buscar Pessoa Por ID");
                Console.WriteLine("[ 4 ] - Editar Pessoa");
                Console.WriteLine("[ 5 ] - Deletar Pessoa");
                Console.WriteLine("[ 0 ] - Sair");
                option = Convert.ToString(Console.ReadLine());

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        AddPerson();
                        break;
                    case "2":
                        Console.Clear();
                        ShowPeople();
                        break;
                    case "3":
                        SearchPersonById();
                        break;
                    case "4":
                        EditPerson();
                        break;
                    case "5":
                        RemovePerson();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        InvalidOption();
                        break;
                }
            }
        }
    }
}