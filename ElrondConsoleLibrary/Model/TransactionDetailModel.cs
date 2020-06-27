namespace ElrondConsoleLibrary.Model
{
    public class TransactionDetailModel
    {
        public TransactionDetail Transaction { get; set; }
    }

    public class TransactionDetail
    {
        public string Type { get; set; }
        public long Round { get; set; }
        public long Epoch { get; set; }
        public string Value { get; set; }
        public string Receiver { get; set; }
    }
}
