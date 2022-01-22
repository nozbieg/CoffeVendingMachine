namespace Domain
{
    public interface IDrink
    {
        string Name { get; set; }
        int WaterNeeded { get; set; }
        int MilkNeeded { get; set; }
        int CoffeBeanNeeded { get; set; }

    }
}
