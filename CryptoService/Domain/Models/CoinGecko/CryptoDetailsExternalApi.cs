using System.Text.Json.Serialization;

namespace Domain.Models.CoinGecko
{
    public class CurrentPrice
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class Description
    {
        [JsonPropertyName("en")] public string En { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("thumb")] public string Thumb { get; set; }
        [JsonPropertyName("small")] public string Small { get; set; }
        [JsonPropertyName("large")] public string Large { get; set; }
    }

    public class Low24h
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class High24h
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class MarketData
    {
        [JsonPropertyName("current_price")] public CurrentPrice CurrentPrice { get; set; }

        [JsonPropertyName("low_24h")] public Low24h Low24h { get; set; }

        [JsonPropertyName("high_24h")] public High24h High24h { get; set; }

        [JsonPropertyName("price_change_24h")] public double PriceChange24h { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public double PriceChangePercentage24h { get; set; }

        [JsonPropertyName("price_change_percentage_7d")]
        public double PriceChangePercentage7d { get; set; }

        [JsonPropertyName("price_change_percentage_14d")]
        public double PriceChangePercentage14d { get; set; }

        [JsonPropertyName("price_change_percentage_30d")]
        public double PriceChangePercentage30d { get; set; }

        [JsonPropertyName("price_change_percentage_60d")]
        public double PriceChangePercentage60d { get; set; }

        [JsonPropertyName("price_change_percentage_200d")]
        public double PriceChangePercentage200d { get; set; }

        [JsonPropertyName("price_change_percentage_1y")]
        public double PriceChangePercentage1y { get; set; }

        [JsonPropertyName("price_change_24h_in_currency")]
        public PriceChange24hInCurrency PriceChange24hInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_1h_in_currency")]
        public PriceChangePercentage1hInCurrency PriceChangePercentage1hInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_24h_in_currency")]
        public PriceChangePercentage24hInCurrency PriceChangePercentage24hInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_7d_in_currency")]
        public PriceChangePercentage7dInCurrency PriceChangePercentage7dInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_14d_in_currency")]
        public PriceChangePercentage14dInCurrency PriceChangePercentage14dInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_30d_in_currency")]
        public PriceChangePercentage30dInCurrency PriceChangePercentage30dInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_60d_in_currency")]
        public PriceChangePercentage60dInCurrency PriceChangePercentage60dInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_200d_in_currency")]
        public PriceChangePercentage200dInCurrency PriceChangePercentage200dInCurrency { get; set; }

        [JsonPropertyName("price_change_percentage_1y_in_currency")]
        public PriceChangePercentage1yInCurrency PriceChangePercentage1yInCurrency { get; set; }
    }

    public class PriceChange24hInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class PriceChangePercentage1hInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class PriceChangePercentage24hInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class PriceChangePercentage7dInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class PriceChangePercentage14dInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class PriceChangePercentage30dInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class PriceChangePercentage60dInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class PriceChangePercentage200dInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }

    public class PriceChangePercentage1yInCurrency
    {
        [JsonPropertyName("eur")] public double Eur { get; set; }
        [JsonPropertyName("pln")] public double Pln { get; set; }
        [JsonPropertyName("usd")] public double Usd { get; set; }
    }
}