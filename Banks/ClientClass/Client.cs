using System;
using Banks.Exceptions;

namespace Banks.ClientClass
{
    public class Client
    {
        public Client(string name, string surname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                throw new BankException("InvalidNameOrSurnameException");

            FirstName = name;
            Surname = surname;
            Id = Guid.NewGuid();
        }

        public string FirstName { get; }
        public string Surname { get; }
        public PassportData PassportData { get; set; }
        public string Address { get; set; }
        public Guid Id { get; }

        public bool IsDoubtful()
            => PassportData == null || Address == null;
    }
}
