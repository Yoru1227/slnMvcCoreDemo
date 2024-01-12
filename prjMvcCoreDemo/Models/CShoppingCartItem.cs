using System.ComponentModel;

namespace prjMvcCoreDemo.Models
{
    public class CShoppingCartItem
    {
        public int productId { get; set; }
        [DisplayName("採購量")]
        public int count { get; set; }
        [DisplayName("售價")]
        public decimal price { get; set; }
        [DisplayName("小計")]
        public decimal total { get { return this.count * this.price; } }
        public TProduct product { get; set; }
    }
}
