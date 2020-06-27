using System.Collections.Generic;

namespace ElrondConsoleLibrary.Model
{
    public class BlockModel
    {
        public Block Block { get; set; }
    }

    public class Block
    {
        public long Nonce { get; set; }
        public string Hash { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
