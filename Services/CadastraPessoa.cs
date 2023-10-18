using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class CadastraPessoa : ICadastraPessoa
    {
        private static List<Person> peopleList = new List<Person>();

        public void AddPerson()
        {
            Console.WriteLine(" - Adicionar Pessoa - ");
            //Console.WriteLine("Informe o id da pessoa: ");
            //int idPerson = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o nome da pessoa: ");
            string namePerson = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Informe a idade da pessoa: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o telefone da pessoa: ");
            int telephonePerson = Convert.ToInt32(Console.ReadLine());

            peopleList.Add(new Person(namePerson, age, telephonePerson));
        }

        public void ShowPeople()
        {
            if(peopleList.Count == 0)
            {
                Console.WriteLine("Não há pessoas adicionadas");
            }
            else
            {
                Console.WriteLine(" - Pessoas - ");
                foreach (Person person in peopleList)
                {
                    Console.WriteLine(person);
                }
            }
        }

        public void SearchPersonById()
        {
            if (peopleList.Count == 0)
            {
                Console.WriteLine("Não há pessoas adicionadas");
            }
            else
            {
                bool founded = false;
                Console.WriteLine(" - Buscar Pessoa Por ID - ");
                Console.WriteLine("Informe o ID da pessoa: ");
                int searchPersonById = Convert.ToInt32(Console.ReadLine());
                foreach (Person person in peopleList.ToList())
                {
                    if (searchPersonById.Equals(person.Id))
                    {
                        Console.WriteLine("Pessoa encontrada");
                        Console.WriteLine(person);
                        founded = true;
                    }
                }
                if (!founded)
                {
                    Console.WriteLine("Pessoa não encontrada");
                }
            }        
        }

        public void EditPerson()
        {
            if (peopleList.Count == 0)
            {
                Console.WriteLine("Não há pessoas adicionadas");
            }
            else
            {
                bool founded = false;
                Console.WriteLine(" - Editar Pessoa Por ID - ");
                Console.WriteLine("Informe o ID da pessoa da qual deseja editar: ");
                int searchPersonById = Convert.ToInt32(Console.ReadLine());
                foreach (Person person in peopleList.ToList())
                {
                    if (searchPersonById.Equals(person.Id))
                    {
                        Console.WriteLine("Pessoa encontrada");
                        Console.WriteLine(person);
                        founded = true;
                        Console.WriteLine("Informe o novo nome para da pessoa: ");
                        string newNamePerson = Convert.ToString(Console.ReadLine());
                        person.EditName(newNamePerson);
                    }
                }
                if (!founded)
                {
                    Console.WriteLine("Pessoa não encontrada");
                }
            }
        }

        public void DeletePerson()
        {
            if (peopleList.Count == 0)
            {
                Console.WriteLine("Não há pessoas adicionadas");
            }
            else
            {
                bool founded = false;
                Console.WriteLine(" - Deletar Pessoa - ");
                Console.WriteLine("Informe o ID da pessoa: ");
                int searchPersonById = Convert.ToInt32(Console.ReadLine());
                foreach (Person person in peopleList.ToList())
                {
                    if (searchPersonById.Equals(person.Id))
                    {
                        Console.WriteLine("Pessoa encontrada");
                        Console.WriteLine(person);
                        founded = true;
                        peopleList.Remove(person);
                        Console.WriteLine("Pessoa removida");
                    }
                }
                if (!founded)
                {
                    Console.WriteLine("Pessoa não encontrada");
                }
            }
        }
    }
}