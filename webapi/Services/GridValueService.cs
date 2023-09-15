using Models;
using System.Collections.Generic;

namespace Services
{
    public interface IGridValueService
    {

    }
    public class GridValueService : IGridValueService
    {
        public void HandleWatered(GridItem gridItem) { }
        public void HandleWeeded(GridItem gridItem) { }
        public void HandleQuantity(GridItem gridItem) { }
        public void HandleQuality(GridItem gridItem) { }
        public void HandleSpeed(GridItem gridItem) { }

        public double CalculateGridValue(Grid grid)
        {
            for (int y = 1; y < 10; y++)
            {
                for (int x = 1; x < 10; x++)
                {
                    GridItem gridItem = grid.Items.GetValueOrDefault((x, y)) 
                        ?? throw new Exception("Invalid grid (not 9x9)");
                    var gridItemAttributes = GridItemPropertyLookups.gridItemAttributeLookup.GetValueOrDefault(gridItem.Type.ToString())
                        ?? throw new Exception($"Grid item type is invalid: {gridItem.Type}");

                }
            }
            return 0;
        }
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
        public int NormalValue { get; set; }
        public int StarValue { get; set;}
        public double AvgDays { get; set; }
        public int TotalDays { get; set; }
        public int HarvestAmount { get; set; }
        public int ForRecipe { get; set; }
        public int FromRecipe { get; set; }
        public int PickleValue { get; set; }
        public int SeedValue { get; set; }
    }

    public class GridItemPropertyLookups
    {
        public static readonly double quantityIncrease = 1.5;
        public static readonly NormalStarRatio baseNormalStarRatio = new NormalStarRatio(0.5, 0.5);
        public static readonly NormalStarRatio qualityNormalStarRatio = new NormalStarRatio(0.2, 0.8);
        public static readonly Dictionary<string, GridItemAttributes> gridItemAttributeLookup = new Dictionary<string, GridItemAttributes>
        {
            ["C"] = new GridItemAttributes
            {
                AvgDays = 3,
                TotalDays = 3,
                ForRecipe = 1,
                FromRecipe = 4,
                HarvestAmount = 2,
                NormalValue = 23,
                StarValue = 34,
                PickleValue = 0,
                SeedValue = 0,
            },
            ["O"] = new GridItemAttributes
            {
                AvgDays = 4,
                TotalDays = 4,
                ForRecipe = 1,
                FromRecipe = 4,
                HarvestAmount = 2,
                NormalValue = 30,
                StarValue = 45,
                PickleValue = 0,
                SeedValue = 0,
            },
            ["P"] = new GridItemAttributes
            {
                AvgDays = 5,
                TotalDays = 5,
                ForRecipe = 1,
                FromRecipe = 4,
                HarvestAmount = 2,
                NormalValue = 45,
                StarValue = 67,
                PickleValue = 0,
                SeedValue = 0,
            },
            ["T"] = new GridItemAttributes
            {
                AvgDays = 2.5,
                TotalDays = 10,
                ForRecipe = 3,
                FromRecipe = 2,
                HarvestAmount = 2,
                NormalValue = 23,
                StarValue = 34,
                PickleValue = 0,
                SeedValue = 0,
            },
            ["W"] = new GridItemAttributes
            {
                AvgDays = 4,
                TotalDays = 4,
                ForRecipe = 1,
                FromRecipe = 4,
                HarvestAmount = 2,
                NormalValue = 33,
                StarValue = 49,
                PickleValue = 0,
                SeedValue = 0,
            },
            ["R"] = new GridItemAttributes
            {
                AvgDays = 4,
                TotalDays = 4,
                ForRecipe = 1,
                FromRecipe = 4,
                HarvestAmount = 2,
                NormalValue = 27,
                StarValue = 40,
                PickleValue = 0,
                SeedValue = 0,
            },
            ["Cot"] = new GridItemAttributes
            {
                AvgDays = 5,
                TotalDays = 5,
                ForRecipe = 1,
                FromRecipe = 3,
                HarvestAmount = 2,
                NormalValue = 45,
                StarValue = 67,
                PickleValue = 0,
                SeedValue = 0,
            },
            ["Cor"] = new GridItemAttributes
            {
                AvgDays = 5,
                TotalDays = 5,
                ForRecipe = 1,
                FromRecipe = 4,
                HarvestAmount = 2,
                NormalValue = 0,
                StarValue = 0,
                PickleValue = 0,
                SeedValue = 0,
            },
        };
    }
}