namespace FoodShortage
{
    public class Citizen : IIdentifiable, IBuyer
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

        public int Food { get; set; }

        public int BuyFood()
        {
            Food += 10;
            return Food;
        }
    }
}
