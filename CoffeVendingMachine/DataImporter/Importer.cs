using System;
using System.Linq;
using Domain;

namespace CoffeVendingMachine.DataImporter
{
    public class Importer : IImporter
    {
        public async Task<IList<Coffe>> ImportWerehouseFromFile(string fileName)
        {
            var fileLines = await File.ReadAllLinesAsync(fileName);
            var coffeList = new List<Coffe>();

            foreach (var line in fileLines)
            {
                coffeList.Add(ImportCoffe(line));
            }
            return coffeList;
        }

        Coffe ImportCoffe(string inputLine)
        {
            var splitedLine = inputLine.Split(';');
            return new Coffe(splitedLine);
        }
    }
}
