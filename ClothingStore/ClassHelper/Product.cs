namespace ClothingStore.DB
{
    using System;
    using System.Collections.Generic;

    public partial class Product
    {
        public int Count { get; set; }

        public string Color
        {
            get
            {
                if (Count <= 3)
                {
                    return "Red";
                }
                else
                {
                    return "White";
                };
            }
        }
    }
}
