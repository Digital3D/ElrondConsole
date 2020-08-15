using System.Collections.Generic;

namespace ElrondConsoleLibrary.Model
{
    public class BlockModel
    {
        public BlockModelData Data { get; set; }
        public string Error { get; set; }
        public string Code { get; set; }
    }

    public class BlockModelData
    {
        public Block Block { get; set; }
    }

    public class Block
    {
        public long Nonce { get; set; }
        public string Hash { get; set; }
        public List<TransactionModel> Transactions { get; set; }
    }
}
