using System;
using Banks.ClientClass;
namespace Banks.Account
{
    public interface IAccount
    {
        public Client Owner { get; set; }
        public double Balance { get; set; }
        public Guid Id { get; set; }
        public int IdBank { get; set; }
        public bool IsTransactionAvailable(double sum);
    }
}
