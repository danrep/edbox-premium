namespace EdBoxPremium.Data.InterchangeModels
{
    public class UpdateSpec
    {
        public bool DatabaseFiles { get; set; }
        public bool DatabaseSchema { get; set; }
        public string RemoteUrl { get; set; }
    }
}
