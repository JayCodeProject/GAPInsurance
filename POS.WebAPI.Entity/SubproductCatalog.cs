namespace POS.WebAPI.Entity
{
    public class SubProductCatalog
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }        
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Position { get; set; }
    }
}
