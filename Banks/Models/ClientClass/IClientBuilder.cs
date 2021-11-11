namespace Banks.Models.ClientClass
{
    public interface IClientBuilder
    {
        public ClientBuilder SetName(string name);
        public ClientBuilder SetSurname(string surname);
        public ClientBuilder SetAddress(string address);

        public ClientBuilder SetPassport(PassportData passport);

        public Client Build();
    }
}
