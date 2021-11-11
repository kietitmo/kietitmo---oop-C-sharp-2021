using System;
using System.Collections.Generic;
using Banks.Models.ClientClass;
using Banks.Repositories;

namespace Banks.Services
{
    public class ClientServices
    {
        private readonly ClientRepository _clientRepository;
        public ClientServices(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void AddClient(Client client)
            => _clientRepository.AddClient(client);

        public Client GetClientById(Guid id)
            => _clientRepository.GetClientById(id);
        public Guid GetClientIdByNameAndSurname(string name, string surname)
           => _clientRepository.GetClientIdByNameAndSurname(name, surname);

        public IEnumerable<Client> GetEnumerator()
            => _clientRepository.GetEnumerator();
    }
}
