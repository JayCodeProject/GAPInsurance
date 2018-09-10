namespace POS.WebAPI.Entity
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string MenuState { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string ShortLabel { get; set; }
        public string MenuType { get; set; }
        public string Icon { get; set; }
        public bool MenuTarget { get; set; }
    }
}
