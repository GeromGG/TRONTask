using NBitcoin;

namespace TRONTask.Models
{
    public class WalletModel
    {
        public Mnemonic Mnemonic { get; set; }
        public List<Сouple> Сouples { get; set; }

        public WalletModel(Mnemonic mnemonic, List<Сouple> couples)
        {
            Mnemonic = mnemonic;
            Сouples = couples;
        }
    }
}
