namespace Models
{
    public class Grid
    {
        public static Grid GetBlankGrid()
        {
            var grid = new Grid();

            var items = new Dictionary<(int, int), GridItem>();
            for (int y = 1; y < 10; y++)
            {
                var newGridItem = new GridItem();

                for (int x = 1; x < 10; x++)
                {
                    items.TryGetValue((x - 1, y), out GridItem? leftGridItem);
                    if (leftGridItem != null)
                    {
                        newGridItem.Left = leftGridItem;
                        leftGridItem.Right = newGridItem;
                    }

                    items.TryGetValue((x, y - 1), out GridItem? aboveGridItem);
                    if (aboveGridItem != null)
                    {
                        newGridItem.Above = aboveGridItem;
                        aboveGridItem.Below = newGridItem;
                    }
                }
            }
            grid.Items = items;
            return grid;
        }

        public static Grid GetRandomGrid()
        {
            var grid = new Grid();
            Array values = Enum.GetValues(typeof(GridItemType));
            Random random = new();

            var items = new Dictionary<(int, int), GridItem>();
            for (int y = 1; y < 10; y++)
            {
                var newGridItem = new GridItem {
                    Type = (GridItemType)(values.GetValue(random.Next(values.Length)) ?? 0)
                };

                for (int x = 1; x < 10; x++)
                {
                    items.TryGetValue((x - 1, y), out GridItem? leftGridItem);
                    if (leftGridItem != null)
                    {
                        newGridItem.Left = leftGridItem;
                        leftGridItem.Right = newGridItem;
                    }

                    items.TryGetValue((x, y - 1), out GridItem? aboveGridItem);
                    if (aboveGridItem != null)
                    {
                        newGridItem.Above = aboveGridItem;
                        aboveGridItem.Below = newGridItem;
                    }
                }
            }
            grid.Items = items;
            return grid;
        }

        public static void affectGridItems()
        {

        }
        // some kind of method that takes in a function and executes that function on each of the grid items?


        public Dictionary<(int,int),GridItem> Items { get; set; } = new Dictionary<(int, int), GridItem>();
    }

    public class GridViewModel
    {
        public GridViewModel(Grid grid)
        {
            Items = new List<List<GridItemViewModel>>();
            for (int y = 1; y < 10; y++)
            {
                var row = new List<GridItemViewModel>();
                for (int x = 1; x < 10; x++)
                {
                    var gridItem = grid.Items.GetValueOrDefault((x, y), new GridItem());
                    row.Add(new GridItemViewModel(gridItem));
                }
                Items.Add(row);
            }
        }

        public List<List<GridItemViewModel>> Items { get; set;}
    }
}