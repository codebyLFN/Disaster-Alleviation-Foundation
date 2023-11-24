using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class GoodsAllocation
    {

        [Key]
        public int AllocationId { get; set; }


        public int DisasterId { get; set; }


        public int GoodsId { get; set; }


        public DateTime AllocationDate { get; set; }


        public int ItemCount { get; set; }

        // Define the relationships with other tables
        [ForeignKey("DisasterId")]
        public virtual Disaster? Disaster { get; set; }

        [ForeignKey("GoodsId")]
        public virtual GoodsDonation? GoodsDonation { get; set; }
    }
}
