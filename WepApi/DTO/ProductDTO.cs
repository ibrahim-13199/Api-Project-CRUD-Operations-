namespace WepApi.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CatId { get; set; }
        public string CategoryName { get; set; }
    }
}
