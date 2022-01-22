using Domain.Interfaces;

namespace Domain;

public class Coffe : IDrink, IVending, IMagazine
{
    public Coffe(string[] splitedLine)
    {
        Name = splitedLine[0];
        WaterNeeded = int.Parse(splitedLine[1]);
        MilkNeeded = int.Parse(splitedLine[2]);
        CoffeBeanNeeded = int.Parse(splitedLine[3]);
        Cost = int.Parse(splitedLine[4]);
        Amount = int.Parse(splitedLine[5]);
    }

    public string Name { get; set; }
    public int WaterNeeded { get; set; }
    public int MilkNeeded { get; set; }
    public int CoffeBeanNeeded { get; set; }
    public int Cost { get; set; }
    public int Amount { get; set; }
}
