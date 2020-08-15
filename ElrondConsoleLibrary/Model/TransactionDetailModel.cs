namespace ElrondConsoleLibrary.Model
{
    public class TransactionDetailModel
    {
        public TransactionDetailData Data { get; set; }
        public string Error { get; set; }
        public string Code { get; set; }
    }

    public class TransactionDetailData
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
