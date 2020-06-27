namespace ElrondConsoleLibrary.Model
{
    public class AccountModel
    {
        public AccountAddressModel Account { get; set; }
    }

    public class AccountAddressModel
    {
        public string Address { get; set; }
        public int Nonce { get; set; }
        public string Balance { get; set; }
        public string Code { get; set; }
        public string CodeHash { get; set; }
        public string RootHash { get; set; }
    }
}
