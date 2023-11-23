using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_Alleviation_Foundation.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int DisasterId { get; set; }
        public int GoodsId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int AmountSpent { get; set; }

        // Define the relationships with other tables
        [ForeignKey("DisasterId")]
        public virtual Disaster? Disaster { get; set; }

        [ForeignKey("GoodsId")]
        public virtual GoodsDonation? GoodsDonation { get; set; }

    }
}
