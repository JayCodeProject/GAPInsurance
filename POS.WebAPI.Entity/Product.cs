namespace POS.WebAPI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public int SubProductId { get; set; }
        public int ItemNumber { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public float Tax { get; set; }
        public int Stock { get; set; }
        public float Weight { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string ImgURL { get; set; }
        public string CreatedUser { get; set; }
        public int CompanyId { get; set; }
    }
}
