//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClothingStore.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderProduct
    {
        public int IDOrdProd { get; set; }
        public int IDOrder { get; set; }
        public int Quantity { get; set; }
        public int IDClothingBarn { get; set; }
        public decimal Price { get; set; }
    
        public virtual ClothingBarn ClothingBarn { get; set; }
        public virtual Order Order { get; set; }
    }
}
