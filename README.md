# TRONTask
Задание:
    1. Создание адреса
    Вход: ничего
    Выход:
     - адрес (вида TQ5ZaSCRsNfkcud696fndBJCDE44V1zz2P)
     - приватный ключ к нему (вида b1ba1db51c6e88123d0a0a1def9a97437617677a36421924a87026cda2752385) или seed-фразу (вида tornado clump wide canal orbit stumble tornado clump wide canal orbit)
    Примечание: В целях безопасности адрес и ключ создаются локально (не через API к удаленному серверу). Начать копать можно отсюда https://developers.tron.network/docs/account, но готового решения тут нет, тем более для c#. 

    2. Получение баланса монеты TRC-20 (а конкретно USDT)
    Вход: 
     - адрес
    Выход:
     - остаток USDT на адресе
    Пример:
    На вот этом вот адресе https://nile.tronscan.org/#/address/TNPns1Wa3NZYozYKTJvsEshk6FS4opWgnf лежит 5000 USDT.

    Тестовые монеты можно запросить через дискорд https://discordapp.com/invite/hqKvyAM
    В канале faucet https://discord.com/channels/491685925227724801/999575963920781382 нужно отправить сообщение вида 
    !nile_usdt TNPns1Wa3NZYozYKTJvsEshk6FS4opWgnf
    Также всякие faucet есть на просторах интернета, даже приведены в доке, но не всегда работают.
    Можно начать копать отсюда: https://developers.tron.network/reference/triggersmartcontract

    3. Отправка монет
    Т.е. нужно создавать, подписывать и отправлять транзакцию в сеть.
    Вход:
     - адрес отправки
     - ключ или сид-фраза к адресу отправки
     - адрес получения
     - количество монет
    Выход:
     - хэш транзакции
    Пример:
    Вот хэш: 624e598b08e6dc2a9973ac3317aa194d2f65e23af288fc6b2c1b446a2ce7b8f7, саму транзакцию видно в обозревателе тут: https://nile.tronscan.org/#/transaction/624e598b08e6dc2a9973ac3317aa194d2f65e23af288fc6b2c1b446a2ce7b8f7

    4. Получение истории операций
    Вход: 
     - адрес, по которому нужна история
     - период дат (в качестве альтернативы можно получать диапазон блоков, внутри которых транзакции), необяз.
    Выход:
     - JSON или массив со списком операций
    Пример:
    Вот тут внизу видна одна транзакция: https://nile.tronscan.org/#/address/TNPns1Wa3NZYozYKTJvsEshk6FS4opWgnf/transfers
    
Решение:
    1) метод GetСouple()
    2) метод GetUsdtBalanceAsync(адрес)
    3) в разработке
    4) метод GetTransactionHistoryAsync(адрес)
