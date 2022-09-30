public class Payment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Amount { get; set; }
    public bool Status { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}
