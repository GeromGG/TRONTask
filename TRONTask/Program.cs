using NBitcoin;
using Newtonsoft.Json;
using TRONTask.Models;

namespace TRONTask
{
    class Program
    {
        const int KeyPairsCount = 3;
        private const WordCount _wordCount = WordCount.Twelve;
        private const string _balanceUrl = "https://nileapi.tronscan.org/api/account/tokens?address=";

        static void Main(string[] args)
        {
            var addres = "TNPns1Wa3NZYozYKTJvsEshk6FS4opWgnf";

            // Вызов метода GetUsdtBalanceAsync для получения баланса USDT на адресе
            var balance = GetUsdtBalanceAsync(addres).Result;

            // Вызов метода GetTransactionHistoryAsync для получения списка транзакций
            var transactions = GetTransactionHistoryAsync(addres).Result;

            // Вывод на консоль баланса USDT на адресе
            Console.WriteLine($"USDT balance: \"{balance}\" on address: \"{addres}\"");
            Console.WriteLine("____________________________________________________________________________________");

            do
            {
                var couples = new List<Сouple>();
                var mnemonic = new Mnemonic(Wordlist.English, _wordCount);
                Console.WriteLine($"Seed phrase: {mnemonic.ToString()}");

                for (int i = 0; i < 5; i++)
                {
                    var couple = GetСouple(mnemonic, i);
                    couples.Add(couple);
                    Console.WriteLine(couple.ToString());
                }

                var wallet = new WalletModel(mnemonic, couples);
                Console.WriteLine("____________________________________________________________________________________");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            
            Console.WriteLine("=========================================================================================");
            Console.WriteLine(GetСouple().ToString());
        }

        /// <summary>
        /// Получение пары адрес-приватный ключ по сид фразе
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <param name="iterator"></param>
        /// <returns></returns>
        public static Сouple GetСouple(Mnemonic mnemonic, int iterator = 0)
        {
            var seed = mnemonic.DeriveSeed();
            var hdRoot = ExtKey.CreateFromSeed(seed);
            var hdPath = $"m/44'/0'/{iterator}'";
            var key = hdRoot.Derive(new KeyPath(hdPath)).PrivateKey;
            var address = key.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main).ToString();
            var privateKey = key.GetBitcoinSecret(Network.Main).ToWif();

            return new Сouple(address, privateKey);
        }

        /// <summary>
        /// Получение случайной пары адрес-приватный ключ 
        /// </summary>
        /// <returns></returns>
        public static Сouple GetСouple()
        {
            using (var key = new Key())
            {
                var privateKey = key.GetBitcoinSecret(Network.Main).ToWif();
                //var publicKey = key.PubKey.ToHex();
                var address = key.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main).ToString();
                return new Сouple(address, privateKey);
            }
        }

        /// <summary>
        /// Получение баланса USDT
        /// </summary>
        /// <param name="addres"></param>
        /// <returns></returns>
        public static async Task<decimal?> GetUsdtBalanceAsync(string addres)
        {
            // Создание HttpClient-экземпляра и сборки URL-адреса запроса
            var client = new HttpClient();
            var url = $"{_balanceUrl}{addres}";

            // Запрос баланса монеты TRC-20 с использованием HttpClient
            using (var response = await client.GetAsync(url))
            {
                // статус-кода ответа (например, 200 - OK), можно добавить проверку
                response.EnsureSuccessStatusCode();

                // Получение в виде строки ответа из API-запроса
                string responseBody = await response.Content.ReadAsStringAsync();

                decimal? balance;
                try
                {
                    // Десериализация JSON-ответа для получения баланса USDT
                    dynamic data = JsonConvert.DeserializeObject(responseBody);
                    balance = data?.data[1].quantity;

                    if (balance is null)
                    {
                        balance = -1;//не обязательно можно возращать и null
                    }
                }
                catch (Exception)
                {
                    balance = -1;
                    throw;
                }
                // Возврат USDT баланса адреса
                return balance;
            }
        }

        /// <summary>
        /// Получение модели со списком транзакций по адресу
        /// </summary>
        /// <param name="addres"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static async Task<Root> GetTransactionHistoryAsync(string addres, int limit = 20)
        {
            var client = new HttpClient();
            Root myDeserializedClass;
            var url = $"https://nileapi.tronscan.org/api/new/token_trc20/transfers?limit={limit}" +
                $"&start=0&sort=-timestamp&count=true&filterTokenValue=0&relatedAddress={addres}";

            using (var response = await client.GetAsync(url))
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseBody);
            }


            return myDeserializedClass;
        }
    }
}