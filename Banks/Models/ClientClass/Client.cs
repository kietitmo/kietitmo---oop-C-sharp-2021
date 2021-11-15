using System;
using System.Collections.Generic;
using Banks.Exceptions;
using Banks.Models.Account.AccountFactory;

namespace Banks.Models.ClientClass
{
    public class Client
    {
        public Client(string name, string surname, Phone phone, PassportData passportData, string adrdress)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                throw new BankException("InvalidNameOrSurnameException");

            FirstName = name;
            Surname = surname;
            PassportData = passportData;
            Address = adrdress;
            Id = Guid.NewGuid();
            TypeAccountClientHave = new List<TypeAccount>();
            PhoneClient = phone;
        }

        public List<TypeAccount> TypeAccountClientHave { get; set; }

        public string FirstName { get; }
        public string Surname { get; }
        public PassportData PassportData { get; set; }
        public string Address { get; set; }
        public Guid Id { get; }
        public Phone PhoneClient { get; set; }
        public bool IsDoubtful()
            => PassportData == null || Address == null;
    }
}
