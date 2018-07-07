using StoreFront.Models;
using System;
using System.Collections.Generic;

namespace StoreFront.Logic
{
    public class Order
    {
        public Decimal Total;
        public Decimal salesTaxes;

        private Product[] products { get; }

        //List of items purchased -- allows duplicate items
        public List<KeyValuePair<string, Decimal>> orderItems = new List<KeyValuePair<string, Decimal >>();

        
        public Order(Product[] p)
        {
            this.products = p;
            setOrderItems();
            setTotal();
            
        }

        public Decimal getTotal()
        {
            return Total;
        }

        //Adds item totals
        private void setTotal()
        {
            foreach(KeyValuePair<String, Decimal> entry in this.orderItems)
            {
                this.Total += entry.Value;
            };
        }

        public Decimal getSalesTaxes()
        {
            return salesTaxes;
        }


        private Decimal ItemTotal(Decimal price, Boolean imported, Boolean exempt)

        {
            Decimal itemTotal = price;
            Decimal saleTax = Tax(price, 10);
            Decimal importTax = Tax(price, 5);

            //Calculates sales tax on non-exempt items
            if (exempt == false)
            {
                itemTotal += saleTax;
                this.salesTaxes += saleTax;
            }

            //Calculates tax on imports
            if (imported == true)
            {
                itemTotal += importTax;
                this.salesTaxes += importTax;
            }

            return itemTotal;
        }

        //Populates orderItem List
        public void setOrderItems()
        {
            foreach (Product p in this.products)
            {

                this.orderItems.Add(new KeyValuePair<string, Decimal>(
                    p.Name, ItemTotal(p.Price, p.Import, p.Exempt)));
            }
        }

        private Decimal Tax(Decimal price, Decimal rate)
        {
            Decimal tax = (price * rate) / 100;

            //Rounds up to the neares $.05
            return Math.Ceiling(tax * 20) / 20;
        }

        

    }
}
