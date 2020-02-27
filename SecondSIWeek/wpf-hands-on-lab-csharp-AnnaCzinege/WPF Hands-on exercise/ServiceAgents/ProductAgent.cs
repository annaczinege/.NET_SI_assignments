using System;
using HandsOnLab1.ClientEntities;

namespace HandsOnLab1.ServiceAgents
{
    /// <summary>
    /// This service provides functionality for getting product list.
    /// </summary>
    public class ProductAgent
    {
        /// <summary>
        /// Provide <see cref="ProductSummaryCollection"/> of current products.
        /// </summary>
        /// <returns><see cref="ProductSummaryCollection"/></returns>
        public static ProductSummaryCollection GetProductList()
        {
            ProductSummaryCollection products = new ProductSummaryCollection();

            ProductSummary prod = new ProductSummary
            {
                ProductId = 1,
                Sku = "0001-unit",
                Code = "0001",
                Name = "Tomcats DVD",
                ShortDescription = "Tomcats DVD Zone 4",
                Manufacturer = "Revolution Studios",
                LowestPrice = 10,
                UnitPrice = 12,
            };
            products.Add(prod);

            prod = new ProductSummary
            {
                ProductId = 2,
                Sku = "0002-unit",
                Code = "0002",
                Name = "Top Gun DVD",
                ShortDescription = "Top Gun DVD Zone 4",
                Manufacturer = "Paramount Pictures",
                LowestPrice = 15,
                UnitPrice = 25,
            };
            products.Add(prod);

            prod = new ProductSummary
            {
                ProductId = 3,
                Sku = "0003-unit",
                Code = "0003",
                Name = "Total Recall DVD",
                ShortDescription = "Total Recall DVD Zone 4",
                Manufacturer = "Carolco International N.V.",
                LowestPrice = 5,
                UnitPrice = 5,
            };
            products.Add(prod);

            prod = new ProductSummary
            {
                ProductId = 4,
                Sku = "0004-unit",
                Code = "0004",
                Name = "Trainspotting DVD",
                ShortDescription = "Trainspotting DVD Zone 4",
                Manufacturer = "Channel Four Films",
                LowestPrice = 52,
                UnitPrice = 60,
            };
            products.Add(prod);

            prod = new ProductSummary
            {
                ProductId = 5,
                Sku = "0005-unit",
                Code = "0005",
                Name = "True Lies DVD",
                ShortDescription = "True Lies DVD Zone 4",
                Manufacturer = "Lightstorm Entertainment",
                LowestPrice = 9,
                UnitPrice = 15,
            };
            products.Add(prod);

            prod = new ProductSummary
            {
                ProductId = 6,
                Sku = "0006-unit",
                Code = "0006",
                Name = "Two Hands DVD",
                ShortDescription = "Two Hands DVD Zone 4",
                Manufacturer = "CML Films",
                LowestPrice = 5,
                UnitPrice = 8,
            };
            products.Add(prod);

            prod = new ProductSummary
            {
                ProductId = 7,
                Sku = "0007-unit",
                Code = "0007",
                Name = "Underworld DVD",
                ShortDescription = "Underworld DVD Zone 4",
                Manufacturer = "Lakeshore Entertainment ",
                LowestPrice = 12,
                UnitPrice = 15,
            };
            products.Add(prod);

            prod = new ProductSummary
            {
                ProductId = 8,
                Sku = "0008-unit",
                Code = "0008",
                Name = "Underworld: Evolution DVD",
                ShortDescription = "Underworld: Evolution DVD Zone 4",
                Manufacturer = "Lakeshore Entertainment",
                LowestPrice = 15,
                UnitPrice = 18,
            };
            products.Add(prod);
            return products;
        }
    }
}
