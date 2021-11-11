using System;

namespace Banks.Models.ClientClass
{
    public class ClientBuilder : IClientBuilder
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public PassportData PassportData { get; set; }
        public string Address { get; set; }
        public Guid Id { get; }

        public ClientBuilder SetAddress(string address)
        {
            Address = address;
            return this;
        }

        public ClientBuilder SetName(string name)
        {
            FirstName = name;
            return this;
        }

        public ClientBuilder SetPassport(PassportData passport)
        {
            PassportData = passport;
            return this;
        }

        public ClientBuilder SetSurname(string surname)
        {
            Surname = surname;
            return this;
        }

        public Client Build()
        {
            return new Client(FirstName, Surname, PassportData, Address);
        }
    }
}
