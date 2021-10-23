using System;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = PricePerShare * TotalNumberOfShares;
        }

        public string CompanyName { get; set; }

        public string Director { get; set; }

        public decimal PricePerShare { get; set; }

        public int TotalNumberOfShares { get; set; }

        public decimal MarketCapitalization { get; set; }

        public override string ToString()
        {
            return $"Company: {this.CompanyName}{Environment.NewLine}Director: {this.Director}{Environment.NewLine}Price per share: ${this.PricePerShare}{Environment.NewLine}Market capitalization: ${this.MarketCapitalization}";
        }
    }
}
