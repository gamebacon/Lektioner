namespace Airport.staff
{
    public abstract class Staff : Human
    {
        private float salary;

        protected Staff(string name, int age) : base(name, age)
        {
            
        }

        public float GetSalary()
        {
            return salary;
        }

        public abstract void Work();


    }
}