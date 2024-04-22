using Adapter;

public class Program
{
    private static async Task Main()
    {
        // Example of using the VCB adapter
        var vcbService = new VCBAdapter();
        await Client(vcbService);

        // Example of using the DAB adapter
        var dabService = new DABAdapter();
        await Client(dabService);
    }

    private static async Task Client(IExchangeRateService exchangeRateService)
    {
        var list = await exchangeRateService.GetList();
        Console.WriteLine("Exchange rates");
        Console.WriteLine("Code\tBuy\tSell");
        Console.WriteLine("---------------------");
        foreach (var item in list)
        {
            Console.WriteLine($"{item.CurrencyCode}\t{item.Buy:N0}\t{item.Sell:N0}");
        }
    }
}

