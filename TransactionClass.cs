public class Transaction
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}

public class Income : Transaction
{
    // Additional properties or methods specific to Income, if any
}

public class Expense : Transaction
{
    // Additional properties or methods specific to Expense, if any
}
