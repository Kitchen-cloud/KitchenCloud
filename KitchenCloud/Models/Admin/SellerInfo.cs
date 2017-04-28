namespace KitchenCloud.Models.Admin
{
    public class SellerInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Location { get; set; }
        public float Rank { get; set; }
        public int Recipes { get; set; }
    }
}