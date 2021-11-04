namespace Airport.staff
{
    public class Pilot : Staff
    {
        public Pilot(string name, int age) : base(name, age)
        {
        }

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}