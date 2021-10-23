using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            this.portfolio = new List<Stock>();
        }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public int Count => this.portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (this.portfolio != null)
            {
                if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
                {
                    this.MoneyToInvest -= stock.PricePerShare;
                    this.portfolio.Add(stock);
                }
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (this.portfolio != null)
            {
                if (this.portfolio.Any( s => s.CompanyName == companyName))
                {
                    var stock = this.portfolio.FirstOrDefault(s => s.CompanyName == companyName);
                    if (sellPrice < stock.PricePerShare )
                    {
                        return $"Cannot sell {companyName}.";
                    }
                    else
                    {
                        this.MoneyToInvest += sellPrice;
                        this.portfolio.Remove(stock);
                        return $"{companyName} was sold.";
                    }

                }
            }

            return $"{companyName} does not exist.";
        }

        public Stock FindStock(string companyName)
        {
            return this.portfolio.FirstOrDefault(s => s.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return this.portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            return $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:{Environment.NewLine}{string.Join(Environment.NewLine, this.portfolio)}";
        }
    }
}
