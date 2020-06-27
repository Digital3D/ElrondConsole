namespace ElrondConsoleLibrary.Model
{
    public class ShardStatusModel
    {
        public ShardStatus Message { get; set; }
    }

    public class ShardStatus
    {
        public ShardStatusResult Status { get; set; }
    }

    public class ShardStatusResult
    {
        public long erd_current_round { get; set; }
        public long erd_epoch_number { get; set; }
        public long erd_nonce { get; set; }
        public long erd_nonce_at_epoch_start { get; set; }
        public long erd_nonces_passed_in_current_epoch { get; set; }
        public long erd_round_at_epoch_start { get; set; }
        public long erd_rounds_passed_in_current_epoch { get; set; }
        public long erd_rounds_per_epoch { get; set; }
    }
}
