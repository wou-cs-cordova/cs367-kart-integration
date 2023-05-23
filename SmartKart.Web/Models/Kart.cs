namespace SmartKart.Web.Models;

public class Kart
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public List<KartItem?> Items { get; set; } = new();

    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in Items) totalPrice += item!.Price * item.Quantity;

            return totalPrice;
        }
    }
}