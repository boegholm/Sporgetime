
abstract class Transaction
{
    public abstract void Execute();

}

class BuyTransaction : Transaction
{
    public User User { get; set; }
    public Product Product { get; set; }
    public override void Execute()
    {
        User.Balance -= Product.Price;
    }
}

class InsertcashTransaction : Transaction
{
    public User User { get; set; }
    public decimal Amount { get; set; }
    public override void Execute()
    {
        User.Balance += Amount;
    }
}


class App
{
    List<Transaction> Transactions = new List<Transaction>();

    void ExecuteTransaction (Transaction t)
    {
        t.Execute();
        LogTransaction("TRansaktion udført: "+ t.GetType().Name);
    }

    private void LogTransaction(string v)
    {
        throw new NotImplementedException();
    }

    public void BuyProduct(int userindex, Product o)
    {
        BuyTransaction t = new BuyTransaction { User = users[userindex], Product = o };
        ExecuteTransaction (t);
    }

    public void AddCash(int userindex, decimal amount)
    {
        InsertcashTransaction it = new InsertcashTransaction { User = users[userindex], Amount = amount };
        ExecuteTransaction(it);
    }


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
