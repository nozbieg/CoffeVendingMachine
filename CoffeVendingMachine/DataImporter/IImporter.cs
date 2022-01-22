using System;
using System.Linq;
using Domain;

namespace CoffeVendingMachine.DataImporter;

public interface IImporter
{
    Task<IList<Coffe>> ImportWerehouseFromFile(string fileName);
}
