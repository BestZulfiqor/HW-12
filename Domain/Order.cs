namespace Domain;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
}