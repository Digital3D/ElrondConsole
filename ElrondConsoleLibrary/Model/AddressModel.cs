namespace ElrondConsoleLibrary.Model
{
    public class AddressModel
    {
        public AddressData Data { get; set; }
        public string Error { get; set; }
        public string Code { get; set; }

    }

    public class AddressData
    {
        public AddressAccountData Account { get; set; }
    }

    public class AddressAccountData
    {
        public string Address { get; set; }
        public long Nonce { get; set; }
        public string Balance { get; set; }
        public string Code { get; set; }
        public string CodeHash { get; set; }
        public string RootHash { get; set; }
    }

}
