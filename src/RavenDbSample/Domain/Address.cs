namespace Unifeso.Db.RavenDbSample.Domain
{
    public class Address
    {
        public Address(string state, string city, string street, string number, string complement)
        {
            State = state;
            City = city;
            Street = street;
            Number = number;
            Complement = complement;
        }

        public string State { get; }
        public string City { get; }
        public string Street { get; }
        public string Number { get; }
        public string Complement { get; }

        public override string ToString()
        {
            return $"{Street}, {Number}, {City} - {State}, {Complement}\n";
        }
    }
}