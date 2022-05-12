

class App
{
    public App(UI ui)
    {
        Ui = ui;
    }
    List<User> users = new List<User>();

    public UI Ui { get; }

    public void Withdraw(int index, decimal amount)
    {
        users[index].Balance -= amount;
    }

    public void Buy(int index, Product p)
    {
        users[index].Balance -= p.Price;
    }

    public void WithdrawFromAll(decimal amount)
    {
        foreach (var item in users)
        {
            item.Balance -= amount;
        }
    }

    void AddUser(string Name)
    {
        User u = new User() { Name = Name, Balance = 30 };
        u.UserBalanceChanged += (sender, newbalance) => Ui.DisplayMessage(u.Name + " har nu "+ u.Balance);
        u.UserBalanceChanged += UserBalanceWarning;
        users.Add(u);
    }

    private void UserBalanceWarning(User user, decimal newbalance)
    {
        if (newbalance < 0)
        {
            Ui.DisplayWarning($"{user.Name} har nu negativ balance");
        }
    }

    public void Run()
    {
        AddUser("Thomas");
        AddUser("Hans");
        Withdraw(0, 10);
        Buy(0, new Product { Price = 5 });
        Withdraw(0, 10);
        Buy(0, new Product { Price = 5 });
        Buy(0, new Product { Price = 5 });
        Withdraw(1, 10);
        Buy(0, new Product { Price = 5 });
        Buy(0, new Product { Price = 5 });
        WithdrawFromAll(5);
        WithdrawFromAll(5);
        WithdrawFromAll(5);
        WithdrawFromAll(5);
        WithdrawFromAll(5);
        WithdrawFromAll(5);
    }
}
