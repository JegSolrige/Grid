namespace Models
{
    public class Grid
    {
        public Grid()
        {
            var items = new Dictionary<Tuple<int, int>, GridItem>();
            for (int y = 1; y < 10; y++)
            {
                var newGridItem = new GridItem();

                for (int x = 1; x < 10; x++)
                {
                    items.TryGetValue(Tuple.Create(x - 1, y), out GridItem? leftGridItem);
                    if (leftGridItem != null)
                    {
                        newGridItem.Left = leftGridItem;
                        leftGridItem.Right = newGridItem;
                    }

                    items.TryGetValue(Tuple.Create(x, y - 1), out GridItem? aboveGridItem);
                    if (aboveGridItem != null)
                    {
                        newGridItem.Above = aboveGridItem;
                        aboveGridItem.Below = newGridItem;
                    }
                }
            }
            Items = items;
        }

        public Dictionary<Tuple<int,int>,GridItem> Items { get; set; } = new Dictionary<Tuple<int, int>, GridItem>();
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
                    var gridItem = grid.Items.GetValueOrDefault(Tuple.Create(x, y), new GridItem());
                    row.Add(new GridItemViewModel(gridItem));
                }
                Items.Add(row);
            }
        }

        public List<List<GridItemViewModel>> Items { get; set;}
    }
}