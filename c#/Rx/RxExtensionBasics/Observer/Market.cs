namespace RxExtensionBasics
{
    using System.Collections.Generic;
    using System;

    public partial class Market
    {
        private List<float> prices = new List<float>();

        public void Add(float price)
        {
            prices.Add(price);
            AddPrice?.Invoke(this, price);
        }

        public event EventHandler<float> AddPrice;
    }
}