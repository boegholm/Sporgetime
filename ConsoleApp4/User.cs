class User
{
    private decimal balance;

    public event UserBalanceNotification UserBalanceChanged;

    public string Name { get; set; }
    public decimal Balance
    {
        get { return balance; }
        set
        {
            balance = value;
            UserBalanceChanged?.Invoke(this, value);
        }
    }

}
delegate void UserBalanceNotification(User user, decimal balance);

