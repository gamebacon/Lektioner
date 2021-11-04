namespace Airport
{
    public abstract class Human
    {
        private string name;
        private int age;
        
        protected Human(string name, int age)
        {
            this.name = name;
            this.age = age;
        }


        public string GetName()
        {
            return name;
        }

        public int GetAge()
        {
            return age;
        }
    }
}