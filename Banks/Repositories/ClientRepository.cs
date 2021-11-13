using System;
using System.Collections.Generic;
using Banks.Exceptions;
using Banks.Models.Account.AccountFactory;
using Banks.Models.ClientClass;

namespace Banks.Repositories
{
    public class ClientRepository
    {
        public ClientRepository()
        {
            ClientList = new List<Client>();
        }

        public List<Client> ClientList { get; set; }
        public void AddClient(Client client)
            => ClientList.Add(client);

        public Client GetClientById(Guid id)
        {
            foreach (Client client in ClientList)
            {
                if (client.Id == id)
                {
                    return client;
                }
            }

            throw new BankException("ClientIsNotExistException");
        }

        public Guid GetClientIdByNameAndSurname(string name, string surname)
        {
            foreach (Client client in ClientList)
            {
                if (client.FirstName == name && client.Surname == surname)
                {
                    return client.Id;
                }
            }

            throw new BankException("ClientIsNotExistException");
        }

        public List<Phone> GetPhoneClientList(TypeAccount type)
        {
            var phoneList = new List<Phone>();
            foreach (Client client in ClientList)
            {
                if (client.TypeAccountClientHave.Contains(type))
                {
                    phoneList.Add(client.PhoneClient);
                }
            }

            Console.WriteLine(phoneList.Count);
            return phoneList;
        }

        public IEnumerable<Client> GetEnumerator()
            => ClientList;
    }
}
