using System;
using System.Collections.Generic;
using System.Linq;

namespace Banks.ClientClass
{
    public class ClientService
    {
        public ClientService()
        {
            ClientList = new List<Client>();
        }

        public List<Client> ClientList { get; set; }
        public void AddAccount(Client account)
            => ClientList.Add(account);

        public Client GetAccountById(Guid id)
            => ClientList.Single(x => x.Id == id);

        public IEnumerable<Client> GetEnumerator()
            => ClientList;

        public Guid GetId(Guid clientId, Guid bankId)
            => ClientList.Single(x =>
                x.Id == clientId && x.Id == bankId).Id;
    }
}
