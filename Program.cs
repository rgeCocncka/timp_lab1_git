List<Goods> GoodsList = new List<Goods>();
string Name;
bool Paid, Shipped;
int Amount;
bool stage = true;
int choice;
int i = 0;
while (stage)
{
    Console.Clear();
    Console.WriteLine("________________________________________________");
    Console.WriteLine("|    Name   ||   Paid? || Shipped?||Amount(rub)|");
    foreach (Goods good in GoodsList)
    {
        Console.WriteLine(good.GoodsWrite());
    }
    Console.WriteLine("What do you want to do?\n" +
    "1. Add an order\n2. End Programm");
    while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1) || (choice > 2))
    {
        Console.WriteLine("Error! ONLY 1 OR 2 YOU DUMMY!");
    }
    switch (choice)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Enter name of product: ");
            Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Type 1 if product is paid OR 2 if it's not paid: ");
            if (Console.ReadLine() == "1")
                Paid = true;
            else
                Paid = false;
            Console.Clear();
            Console.WriteLine("Type 1 if product is shipped OR 2 if it's not shipped: ");
            if (Console.ReadLine() == "1")
                Shipped = true;
            else
                Shipped = false;
            Console.Clear();
            Console.WriteLine("Enter the amount in rubles (>0)");
            while (!int.TryParse(Console.ReadLine(), out Amount) || (Amount < 0))
            {
                Console.WriteLine("TRY AGAIN!!");
            }
            Console.Clear();
            Goods goods = new Goods(Name, Paid, Shipped, Amount);
            GoodsList.Add(goods);
            break;

        case 2:
            Console.Clear();
            int TotalSum = 0;
            Console.WriteLine("REPORT:");
            Console.WriteLine("________________________________________________");
            Console.WriteLine("|  Product  ||   Paid? || Shipped?||Amount(rub)|");
            foreach (Goods good in GoodsList)
            {
                if (good.isPaid() && !good.isShipped())
                {
                    Console.WriteLine(good.GoodsWrite());
                    TotalSum += good.GetAmount();
                }
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"\nTotal sum of products: {TotalSum} rub");
            stage = false;
            break;
    }
}
Console.WriteLine("Programm has ended!");

public class Goods
{
    string Name { get; set; }
    bool Paid { get; set; }
    bool Shipped { get; set; }
    int Amount { get; set; }

    public Goods(string name, bool paid, bool shipped, int amount)
    {
        this.Name = name;
        this.Paid = paid;
        this.Shipped = shipped;
        this.Amount = amount;
    }

    public bool isPaid()
    {
        if (this.Paid) return true;
        else return false;
    }

    public bool isShipped()
    {
        if (this.Shipped) return true;
        else return false;
    }
    public int GetAmount()
    {
        return this.Amount;
    }

    public string GoodsWrite()
    {
        return ($"|{Name,10} || {Paid,7} || {Shipped,7} || {Amount,10}|");
    }
}