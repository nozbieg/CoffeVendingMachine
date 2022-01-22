using System;
using System.Linq;
using Domain.Interfaces;

namespace CoffeVendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        readonly IVendingWarehouse warehouse;

        IVendingWarehouse IVendingMachine.warehouse { get { return warehouse; } }

        public VendingMachine(IVendingWarehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public async Task BuyDrink(int drinkNumber)
        {
            var drink = warehouse.CoffeList.ElementAt(drinkNumber);
            await warehouse.MakeDrink(drink);
            await Task.CompletedTask;
        }

        public async Task RefilMachine()
        {
            await warehouse.Refil();
            await Task.CompletedTask;
        }

        public Task CheckState()
        {
            warehouse.PrintWarehouseState();
            return Task.CompletedTask;
        }

        public Task GetIncome()
        {
            warehouse.PayOut();
            return Task.CompletedTask;
        }

    }
}
