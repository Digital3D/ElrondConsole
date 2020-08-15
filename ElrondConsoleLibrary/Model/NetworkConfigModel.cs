namespace ElrondConsoleLibrary.Model
{
    public class NetworkConfigModel
    {
        public ConfigModelData Data { get; set; }
        public string Error { get; set; }
        public string Code { get; set; }
    }

    public class ConfigModelData
    {
        public NetworkConfig Config { get; set; }
    }

    public class NetworkConfig
    {
        public string erd_chain_id { get; set; }
        public long erd_gas_per_data_byte { get; set; }
        public string erd_latest_tag_software_version { get; set; }
        public long erd_meta_consensus_group_size { get; set; }
        public long erd_min_gas_limit { get; set; }
        public long erd_min_gas_price { get; set; }
        public long erd_num_metachain_nodes { get; set; }
        public long erd_num_nodes_in_shard { get; set; }
        public long erd_num_shards_without_meta { get; set; }
        public long erd_round_duration { get; set; }
        public long erd_shard_consensus_group_size { get; set; }
        public long erd_start_time { get; set; }
    }
}
