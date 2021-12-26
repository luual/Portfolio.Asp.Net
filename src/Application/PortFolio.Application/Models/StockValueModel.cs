namespace PortFolio.Application.Models;

public class StockValueModel
{
    public StockValueModel(string currency, string stock, decimal valueInCurrency)
    {
        Currency = currency;
        Stock = stock;
        ValueInCurrency = valueInCurrency;
    }

    public string Currency { get; }
    public string Stock { get; }
    public decimal ValueInCurrency { get; }
}