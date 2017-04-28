using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models
{
    public class BuyerReviewModel
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string BuyerImage { get; set; }
        public string BuyerLocation { get; set; }
        public DateTime OrderDeliveredDate { get; set; }
        public string BuyerCompliments { get; set; }
        public double Stars { get; set; }

       
    }
}