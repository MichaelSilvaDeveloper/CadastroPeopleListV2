namespace Model
{
    public class Person
    {
        public Person(string name, int age, int telephone)
        {
            Name = name;
            Age = age;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return "Pessoa: " + "\n" + "Id: " + Id + "\n" + "Nome: " + Name + "\n" + "Idade: " + Age + "\n" + "Telefone: " + Telephone + "\n";
        }

        public void EditName(string name) => Name = name;

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Telephone { get; set; }
    }
}