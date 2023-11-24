namespace Disaster_Alleviation_Foundation.Models
{
    public class HomeViewModel
    {
        public List<Disaster> Disasters { get; set; }
        public List<MonetaryDonation> MonetaryDonations { get; set; }
        public List<GoodsDonation> GoodsDonations { get; set; }

        public List<GoodsAllocation> GoodsAllocation { get; set; }

        public List<MonetaryAllocation> MonetaryAllocation { get; set; }

        public int TotalMoneyDonated { get; set; }
        public int TotalGoodsDonated { get; set; }
        public int AvailableMoney { get; set; }
        public int AvailableGoods { get; set; }
    }
}
