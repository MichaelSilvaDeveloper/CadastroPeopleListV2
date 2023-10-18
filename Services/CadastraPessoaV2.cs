using ConnectionDataBase;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Service
{
    public class CadastraPessoaV2 : ICadastraPessoa
    {
        private static readonly List<Person> peopleList = new List<Person>();
        private static readonly Connection connection = new Connection();
        private static readonly SqlCommand cmd = new SqlCommand();
        SqlDataReader dataReader;

        public void AddPerson()
        {
            Console.WriteLine(" - Adicionar Pessoa - ");
            Console.WriteLine("Informe o nome da pessoa: ");
            string namePerson = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Informe a idade da pessoa: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o telefone da pessoa: ");
            int telephonePerson = Convert.ToInt32(Console.ReadLine());
            peopleList.Add(new Person(namePerson, age, telephonePerson));
            

            try
            {
                string strSql = "select Id_Pessoa from Pessoa where Idade = " + age;
                cmd.Connection = connection.Conectar();
                cmd.CommandText = strSql;
                dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    Console.WriteLine("Idade já cadastrada!");
                }
                else
                {
                    if (!dataReader.IsClosed) { dataReader.Close();}
                    dataReader.Close();
                    strSql = String.Format("insert into Pessoa(Nome, Idade, Telefone) values ('{0}', '{1}', '{2}')",namePerson, age, telephonePerson);
                    cmd.Connection = connection.Conectar();
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Cadastrado com sucesso!!");
                }
                connection.Desconectar(); 
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
        }

        public void ShowPeople()
        {
            Console.WriteLine("- Pessoas Cadastradas - ");

            string strSql = "select * from Pessoa";
            try
            {
                cmd.Connection = connection.Conectar();
                cmd.CommandText = strSql;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {            
                    Console.WriteLine("Id: {0}, Nome: {1}, Idade: {2}, Telefone: {3}", dataReader["Id_Pessoa"], dataReader["Nome"], dataReader["Idade"], dataReader["Telefone"]);
                }
                connection.Desconectar();
            }
            catch(SqlException sqlException)
            {
                Console.WriteLine("Erro {0}", sqlException.Message);
            }      
        }

        public void SearchPersonById()
        {
            Console.WriteLine(" - Buscar Pessoa Por Id - ");
            Console.WriteLine("Informe o id: ");
            int searchPersonById = Convert.ToInt32(Console.ReadLine());
            try
            {
                cmd.Connection = connection.Conectar();
                string strSql = "select * from Pessoa where Id_Pessoa = " + searchPersonById;
                cmd.CommandText = strSql;
                dataReader = cmd.ExecuteReader();   
                if (!dataReader.HasRows)
                {
                    Console.WriteLine("Pessoa não encontrada");
                }
                else
                {
                    dataReader.Read();
                    Console.WriteLine("Id: {0}, Nome: {1}, Idade: {2}, Telefone: {3}", dataReader["Id_Pessoa"], dataReader["Nome"], dataReader["Idade"], dataReader["Telefone"]);
                }
                connection.Desconectar();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
        }

        public void EditPerson()
        {
            Console.WriteLine(" - Buscar Pessoa Por Id - ");
            Console.WriteLine("Informe o id: ");
            int searchPersonById = Convert.ToInt32(Console.ReadLine());

            try
            {
                cmd.Connection = connection.Conectar();
                string strSql = "select * from Pessoa where Id_Pessoa = " + searchPersonById;
                cmd.CommandText = strSql;
                dataReader = cmd.ExecuteReader();
                if (!dataReader.HasRows)
                {
                    Console.WriteLine("Pessoa não encontrada");
                }
                else
                {
                    if (!dataReader.IsClosed) { dataReader.Close(); }
                    dataReader.Close();
                    Console.WriteLine("Informe o novo nome da pessoa: ");
                    string newNamePerson = Convert.ToString(Console.ReadLine());
                    strSql = @"update Pessoa set Nome = @nome where Id_Pessoa = " + searchPersonById;
                    cmd.Parameters.AddWithValue("@Nome", newNamePerson);
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Pessoa editada com sucesso");
                }
                connection.Desconectar();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
        }

        public void DeletePerson()
        {
            Console.WriteLine("Informe o id da pessoa que deseja excluir: ");
            string removePersonById = Convert.ToString(Console.ReadLine());
            try
            {
                cmd.Connection = connection.Conectar();
                string strSql = "select * from Pessoa where Id_Pessoa = " + removePersonById;
                cmd.CommandText = strSql;
                dataReader = cmd.ExecuteReader();
                if (!dataReader.HasRows)
                {
                    Console.WriteLine("Pessoa não encontrada");
                }
                else
                {
                    if (!dataReader.IsClosed) { dataReader.Close(); }
                    dataReader.Close();
                    strSql = @"delete Pessoa where Id_Pessoa = " + removePersonById;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Pessoa exluída");
                }
                connection.Desconectar();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
        }
    }
}