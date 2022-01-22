
namespace Domain.Interfaces;

public interface IVendingWarehouse
{
    IList<Coffe> CoffeList { get; set; }
    int CupAmount { get; set; }
    int MoneyAmount { get; set; }
    int WaterAmount { get; set; }
    int MilkAmount { get; set; }
    int CoffeBeanAmount { get; set; }

    Task PrintWarehouseState();
    Task PayOut();
    Task MakeDrink(Coffe drink);
    Task Refil();
}
