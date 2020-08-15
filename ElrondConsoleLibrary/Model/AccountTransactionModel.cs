using System.Collections.Generic;

namespace ElrondConsoleLibrary.Model
{
    public class AccountTransactionModel
    {
        public TransactionData Data { get; set; }
        public string Error { get; set; }
        public string Code { get; set; }
    }

    public class TransactionData
    {
        public List<TransactionModel> Transactions { get; set; }
    }

    public class TransactionModel
    {
        public string Hash { get; set; }
        public string Fee { get; set; }
        public string MiniBlockHash { get; set; }
        public string Nonce { get; set; }
        public string Round { get; set; }
        public string Value { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string ReceiverShard { get; set; }
        public string SenderShard { get; set; }
        public long GasPrice { get; set; }
        public long GasLimit { get; set; }
        public long GasUsed { get; set; }
        public string Data { get; set; }
        public string Signature { get; set; }
        public long Timestamp { get; set; }
        public string Status { get; set; }
        public string ScResults { get; set; }
    }
}
