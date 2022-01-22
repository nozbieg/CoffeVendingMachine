using System;
using System.Linq;
using Domain.Interfaces;

namespace CoffeVendingMachine
{
    public interface IVendingMachine
    {
        IVendingWarehouse warehouse { get; }
        Task BuyDrink(int drinkNumber);
        Task RefilMachine();
        Task CheckState();
        Task GetIncome();
    }
}
