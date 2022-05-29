namespace Application.DTOs.CoinApi;

public class Exchange
{
    public string ExchangeId { get; set; }
    public string Website { get; set; }
    public string Name { get; set; }
    public string DataStart { get; set; }
    public string DataEnd { get; set; }
    public DateTime DataQuoteStart { get; set; }
    public DateTime DataQuoteEnd { get; set; }
    public int DataSymbolsCount { get; set; }
    public double Volume1hrsUsd { get; set; }
    public double Volume1dayUsd { get; set; }
    public double Volume1mthUsd { get; set; }
    public DateTime? DataOrderBookStart { get; set; }
    public DateTime? DataOrderBookEnd { get; set; }
    public DateTime? DataTradeStart { get; set; }
    public DateTime? DataTradeEnd { get; set; }
}