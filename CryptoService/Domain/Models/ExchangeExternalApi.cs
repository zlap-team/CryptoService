using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Domain.Models;

public class ExchangeExternalApi
{
    [JsonPropertyName("exchange_id")] 
    public string ExchangeId { get; set; }

    [JsonPropertyName("website")] 
    public string Website { get; set; }

    [JsonPropertyName("name")] 
    public string Name { get; set; }

    [JsonPropertyName("data_start")] 
    public string DataStart { get; set; }

    [JsonPropertyName("data_end")] 
    public string DataEnd { get; set; }

    [JsonPropertyName("data_quote_start")] 
    public DateTime DataQuoteStart { get; set; }

    [JsonPropertyName("data_quote_end")] 
    public DateTime DataQuoteEnd { get; set; }

    [JsonPropertyName("data_symbols_count")]
    public int DataSymbolsCount { get; set; }

    [JsonPropertyName("volume_1hrs_usd")] 
    public double Volume1hrsUsd { get; set; }

    [JsonPropertyName("volume_1day_usd")] 
    public double Volume1dayUsd { get; set; }

    [JsonPropertyName("volume_1mth_usd")] 
    public double Volume1mthUsd { get; set; }

    [JsonPropertyName("data_orderbook_start")]
    public DateTime? DataOrderBookStart { get; set; }

    [JsonPropertyName("data_orderbook_end")]
    public DateTime? DataOrderBookEnd { get; set; }

    [JsonPropertyName("data_trade_start")] 
    public DateTime? DataTradeStart { get; set; }

    [JsonPropertyName("data_trade_end")] 
    public DateTime? DataTradeEnd { get; set; }
}