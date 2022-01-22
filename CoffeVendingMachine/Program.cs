// See https://aka.ms/new-console-template for more information
using CoffeVendingMachine;
using CoffeVendingMachine.DataImporter;
using Domain;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Coffe Vending Machine!");

var serviceProvider = new ServiceCollection()
    .AddTransient<IImporter, Importer>()
    .AddSingleton<IVendingWarehouse, VendingWarehouse>()
    .AddSingleton<IVendingMachine, VendingMachine>()
    .AddSingleton<IInterface, UiGenerator>()
    .BuildServiceProvider();

var importer = serviceProvider.GetRequiredService<IImporter>();
var warehouse = serviceProvider.GetRequiredService<IVendingWarehouse>();


warehouse.CoffeList = await importer.ImportWerehouseFromFile("databaseFile.txt");
warehouse.CupAmount = 100;
warehouse.WaterAmount = 5000;
warehouse.MilkAmount = 5000;
warehouse.CoffeBeanAmount = 500;
warehouse.MoneyAmount = 500;

var vendingMachine = serviceProvider.GetRequiredService<IVendingMachine>();

var ui = serviceProvider.GetRequiredService<IInterface>();

await ui.PrintMenu();
await ui.TakeInput();





