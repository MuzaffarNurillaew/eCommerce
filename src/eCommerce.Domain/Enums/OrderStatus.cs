namespace eCommerce.Domain.Enums
{
    public enum OrderStatus
    {
        Picking = 0,
        Pending = 10,
        Processing = 20,
        Shipping = 30,
        Shipped = 40,
        Rejected = 50
    }
}
