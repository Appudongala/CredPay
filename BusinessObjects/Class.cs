namespace Payments.BusinessObjects
{
    public class Class
    {
        public class CardData
        {
            public string? CardNumber { get; set; }
            public string? Expiry { get; set; }
            public string? CVV { get; set; }
            public string? UPIID { get; set; }
        }
        public class OrderDetails
        {
            public string name { get; set; }
            public string email { get; set; }
            public string amount { get; set; }
            public string MobileNumber { get; set; }
            public string TransactionID { get; set; }
            public string OrderID { get; set; }
            public DateTime DateTime { get; set; }
        }
    }
}
