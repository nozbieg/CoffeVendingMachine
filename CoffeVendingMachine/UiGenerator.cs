using System;
using System.Linq;

namespace CoffeVendingMachine
{
    public class UiGenerator : IInterface
    {
        readonly IVendingMachine _machine;

        public UiGenerator(IVendingMachine machine)
        {
            _machine = machine;
        }
        public Task PrintMenu()
        {
            var counter = 1;
            Console.WriteLine("Hello. Please select your drink or enter service mode");
            foreach (var drink in _machine.warehouse.CoffeList)
            {
                Console.WriteLine($"{counter} - {drink.Name}");
                counter++;
            }
            Console.WriteLine($"{counter} - Service Mode");
            return Task.CompletedTask;
        }

        async Task EnterToServiceMode()
        {
            Console.Clear();
            Console.WriteLine("Welcome to service mode. What would you like to do?");
            Console.WriteLine("1 - Check machine warehouse state");
            Console.WriteLine("2 - Refil machine");
            Console.WriteLine("3 - Get payout");

            var input = WaitForInput();

            switch (input)
            {
                case 1:
                    await _machine.CheckState();
                    break;
                case 2:
                    await _machine.RefilMachine();
                    break;
                case 3:
                    await _machine.GetIncome();
                    break;
            }
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Thanks for operation. Returning to menu.");
            Console.Clear();
            await PrintMenu();
            await TakeInput();
        }
        public async Task TakeInput()
        {
            var input = WaitForInput();
            if (input == _machine.warehouse.CoffeList.Count() + 1)
            {
                await EnterToServiceMode();
            }
            await _machine.BuyDrink(input - 1);

            Console.WriteLine("Thanks for purshe. Press enter to continue or \"alt +f4\" to quit");
            Console.ReadLine();
            Console.Clear();
            await PrintMenu();
            await TakeInput();

            await Task.CompletedTask;
        }

        int WaitForInput()
        {
            int parameter;
            var success = int.TryParse(Console.ReadLine(), out parameter);
            if (!success)
            {
                Console.WriteLine($"Please select only numbers from list. Try again");
                TakeInput();
            }
            return parameter;
        }
    }
}
