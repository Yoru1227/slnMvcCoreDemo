using System.ComponentModel;

namespace prjMvcCoreDemo.Models
{
    public class CProductWrap
    {
        private TProduct _product;
        public TProduct product {
            get { return _product; } 
            set {_product = value; } 
        }
        public CProductWrap() 
        {
            _product = new TProduct();
        }
        public int FId { 
            get { return _product.FId; }
            set { _product.FId = value; } 
        }
        [DisplayName("商品名稱")]
        public string? FName
        {
            get { return _product.FName; }
            set { _product.FName = value; }
        }
        [DisplayName("庫存量")]
        public int? FQty
        {
            get { return _product.FQty; }
            set { _product.FQty = value; }
        }
        [DisplayName("成本")]
        public decimal? FCost
        {
            get { return _product.FCost; }
            set { _product.FCost = value; }
        }
        [DisplayName("價格")]
        public decimal? FPrice
        {
            get { return _product.FPrice; }
            set { _product.FPrice = value; }
        }

        public string? FImagePath
        {
            get { return _product.FImagePath; }
            set { _product.FImagePath = value; }
        }
        public IFormFile photo
        {
            get; set;
        }
    }
}
