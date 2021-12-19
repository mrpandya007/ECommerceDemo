using System;

namespace ECommerceDemo.DataTransferObjects
{
    public class ProductDTO
    {
        public long ProductId { get; set; }

        public int ProdCatId { get; set; }
        public int AttributeId { get; set; }

        public string ProdName { get; set; }

        public string ProdDescription { get; set; }

    }
}
