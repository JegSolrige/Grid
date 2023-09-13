namespace Services
{
    public interface IGridValueService
    {

    }
    public class GridValueService : IGridValueService
    {
        private static readonly double quantityIncrease = 1.5;
        private static readonly NormalStarRatio baseNormalStarRatio = new NormalStarRatio(0.5, 0.5);
        private static readonly NormalStarRatio qualityNormalStarRatio = new NormalStarRatio(0.2, 0.8);
        private static readonly Dictionary<string, GridItemAttributes> gridItemAttributeLookup = new Dictionary<string, GridItemAttributes>
        {
            ["C"] = new GridItemAttributes(23, 34, 3, 2, 1, 4)
        };
    }
    public class NormalStarRatio
    {
        public NormalStarRatio(double normal, double star)
        {
            Normal = normal;
            Star = star;
        }

        public double Normal { get; set; }
        public double Star { get; set; }
    }

    public class GridItemAttributes 
    {
        public GridItemAttributes(int normalValue, int starValue, int avgDays, int harvestAmount, int forRecipe, int fromRecipe)
        {
            NormalValue = normalValue;
            StarValue = starValue;
            AvgDays = avgDays;
            HarvestAmount = harvestAmount;
            ForRecipe = forRecipe;
            FromRecipe = fromRecipe;
        }

        public int NormalValue { get; set; }
        public int StarValue { get; set;}
        public int AvgDays { get; set; }
        public int HarvestAmount { get; set; }
        public int ForRecipe { get; set; }
        public int FromRecipe { get; set; }
    }
}