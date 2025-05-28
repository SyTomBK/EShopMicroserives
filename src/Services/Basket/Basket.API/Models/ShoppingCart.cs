namespace Basket.API.Models;
public class ShoppingCart
{
    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    public decimal TotalPrice  => Items.Sum(p => p.Price * p.Quantity);

    public ShoppingCart(string userName) {
        this.UserName = userName;
    }
    public ShoppingCart()
    {
    }

}
