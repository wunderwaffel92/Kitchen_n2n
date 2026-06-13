namespace Kitchen.Models
{
    public class Order
    {
        public long Id { get; set; }

        public int UserId { get; set; }

        public decimal KitchenWidth { get; set; }

        public decimal KitchenHeight { get; set; }

        public decimal KitchenDepth { get; set; }

        public string BodyMaterial { get; set; }

        public string FacadeMaterial { get; set; }

        public string Color { get; set; }

        public string Comment { get; set; }

        public string Status { get; set; }
    }
}
