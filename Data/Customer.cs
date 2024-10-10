namespace BlazorThucTap.Data
{
    public class CustomerInfo
    {
        public int ID { get; set; }
        public string TextName { get; set; }
        public string TextUser { get; set; }
        public string TextEmail { get; set; }
        public string TextPhone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TextAddress { get; set; }
        public string TextPass { get; set; }

        public int IdBill { get; set; }
        public int TotalAm { get; set; }
        private DateTime? dateBuy = DateTime.Now;
        public DateTime DateBuy { get; set; }
        
    }
}
