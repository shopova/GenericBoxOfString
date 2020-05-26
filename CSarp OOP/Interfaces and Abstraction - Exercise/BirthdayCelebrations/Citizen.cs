namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; private set; }
        public string BirthDate { get; private set; }
    }
}
