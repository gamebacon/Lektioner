namespace Airport.staff
{
    public class Security : Staff
    {
        public Security(string name, int age) : base(name, age)
        {
        }

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}