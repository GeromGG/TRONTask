namespace TRONTask.Models
{
    public class Сouple
    {
        public string? PrivateKey { get; private set; }
        public string? Address { get; private set; }

        public Сouple(string? address, string? privateKey)
        {
            Address = address;
            PrivateKey = privateKey;
        }

        public override string ToString()
        {
            return $"Address: \"{Address}\";\nPrivate Key: \"{PrivateKey}\";";
        }
    }
}
