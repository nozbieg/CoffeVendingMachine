using Domain.Interfaces;

namespace Domain;
public class VendingWarehouse : IVendingWarehouse
{
    public IList<Coffe> CoffeList { get; set; }
    public int CupAmount { get; set; }
    public int MoneyAmount { get; set; }
    public int WaterAmount { get; set; }
    public int MilkAmount { get; set; }
    public int CoffeBeanAmount { get; set; }

    public Task PayOut()
    {
        Console.WriteLine($"Withdrawing all Income in amont: {MoneyAmount}");
        MoneyAmount = 0;
        return Task.CompletedTask;
    }

    public Task PrintWarehouseState()
    {
        Console.WriteLine("Actual warehouse state:");
        Console.WriteLine($"Amount of cups: {CupAmount}");
        Console.WriteLine($"Amount of water: {WaterAmount}");
        Console.WriteLine($"Amount of milk: {MilkAmount}");
        Console.WriteLine($"Amount of coffe beans: {CoffeBeanAmount}");
        Console.WriteLine($"Amount of moneys: {MoneyAmount}");
        return Task.CompletedTask;
    }
    public async Task MakeDrink(Coffe drink)
    {
        Console.WriteLine($"Making {drink.Name}... PleaseWait");
        if (CupAmount <= 0) { throw new Exception("There is no enaught cups. Please refil machine."); }
        if (WaterAmount < drink.WaterNeeded) { throw new Exception("There is no enaught water. Please refil machine"); }
        if (MilkAmount < drink.MilkNeeded) { throw new Exception("There is no enaught milk. Please refil machine"); }
        if (CoffeBeanAmount < drink.CoffeBeanNeeded) { throw new Exception("There is no enaught coffe beans. Please refil machine"); }

        CupAmount--;
        WaterAmount -= drink.WaterNeeded;
        MilkAmount -= drink.MilkNeeded;
        CoffeBeanAmount -= drink.CoffeBeanNeeded;
        MoneyAmount += drink.Cost;

        await Task.Delay(1000);
        Console.WriteLine("...");
        await Task.Delay(1000);
        Console.WriteLine("...");

        Console.WriteLine($"Your {drink.Name} is ready");
        await Task.CompletedTask;
    }
    public async Task Refil()
    {
        Console.WriteLine("Refiling machine..");
        Console.WriteLine("Inserted water amount:");
        WaterAmount += TakeParametere("water");
        Console.WriteLine("Inserted milk amount:");
        MilkAmount += TakeParametere("milk"); ;
        Console.WriteLine("Inserted coffe beans amount:");
        CoffeBeanAmount += TakeParametere("coffe beans"); ;
        Console.WriteLine("Inserted cup amount:");
        CupAmount += TakeParametere("cup");

        await Task.Delay(1000);
        Console.WriteLine("...");
        await Task.Delay(1000);
        Console.WriteLine("...");
        await Task.Delay(1000);
        Console.WriteLine("Machine is refiled");

        await Task.CompletedTask;
    }

    int TakeParametere(string paramName)
    {
        int parameter;
        var success = int.TryParse(Console.ReadLine(), out parameter);
        if (!success)
        {
            Console.WriteLine($"{paramName} amount must be a number. Try again");
            TakeParametere(paramName);
        }
        return parameter;
    }
}
