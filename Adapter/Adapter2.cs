using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Adapter;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.Json;
using ExternalServices;
using System.Text.Json.Nodes;

namespace Adapter
{
    public class VCBAdapter : IExchangeRateService
    {
        private readonly VCBService _vcbService = new VCBService();

        public async Task<List<ExchangeRate>> GetList()
        {
            var rates = new List<ExchangeRate>();
            var xmlDoc = await _vcbService.FetchExchangeRates();
            foreach (var item in xmlDoc.Descendants("Exrate"))
            {
                var currencyCode = item.Attribute("CurrencyCode").Value;
                if (double.TryParse(item.Attribute("Buy").Value, out double buy) &&
                    double.TryParse(item.Attribute("Sell").Value, out double sell))
                {
                    rates.Add(new ExchangeRate { CurrencyCode = currencyCode, Buy = buy, Sell = sell });
                }
                else
                {
                    // Xử lý trường hợp giá trị không phải là số hợp lệ
                    // Có thể ghi log, bỏ qua mục nhập này, hoặc xử lý khác
                }
            }
            return rates;
        }
    }


    public class DABAdapter : IExchangeRateService
    {
        private readonly DABService _dabService = new DABService();

        public async Task<List<ExchangeRate>> GetList()
        {
            var rates = new List<ExchangeRate>();
            var data = await _dabService.GetExchangeRates();
            // Removing unnecessary characters to parse JSON
            var cleanData = Regex.Replace(data, @"\(.*\)", string.Empty);
            var jsonArray = JsonNode.Parse(cleanData)["items"].AsArray();

            foreach (var item in jsonArray)
            {
                var currencyCode = item["type"].ToString();
                var buy = double.Parse(item["muatienmat"].ToString());
                var sell = double.Parse(item["bantienmat"].ToString());

                rates.Add(new ExchangeRate { CurrencyCode = currencyCode, Buy = buy, Sell = sell });
            }
            return rates;
        }
    }
    public interface IExchangeRateService
    {
        Task<List<ExchangeRate>> GetList();
    }
    public class ExchangeRate
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public double? Buy { get; set; }
        public double Transfer { get; set; }
        public double Sell { get; set; }
    }

}
