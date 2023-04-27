namespace TRONTask.Models
{
    public class Root
    {
        public int total { get; set; }
        public int rangeTotal { get; set; }
        public object contractInfo { get; set; }
        public List<TokenTransfer> token_transfers { get; set; }
    }

    public class TokenInfo
    {
        public string tokenId { get; set; }
        public string tokenAbbr { get; set; }
        public string tokenName { get; set; }
        public int tokenDecimal { get; set; }
        public int tokenCanShow { get; set; }
        public string tokenType { get; set; }
        public string tokenLogo { get; set; }
        public string tokenLevel { get; set; }
        public string issuerAddr { get; set; }
        public bool vip { get; set; }
    }

    public class TokenTransfer
    {
        public string transaction_id { get; set; }
        public int status { get; set; }
        public object block_ts { get; set; }
        public string from_address { get; set; }
        public object from_address_tag { get; set; }
        public string to_address { get; set; }
        public object to_address_tag { get; set; }
        public int block { get; set; }
        public string contract_address { get; set; }
        public string quant { get; set; }
        public bool confirmed { get; set; }
        public string contractRet { get; set; }
        public string finalResult { get; set; }
        public bool revert { get; set; }
        public TokenInfo tokenInfo { get; set; }
        public string contract_type { get; set; }
        public bool fromAddressIsContract { get; set; }
        public bool toAddressIsContract { get; set; }
    }
}
