namespace Models 
{
    public class GridItem
    {
        public GridItem? Above { get; set; } = null;
        public GridItem? Below { get; set; } = null;
        public GridItem? Left { get; set; } = null;
        public GridItem? Right { get; set;} = null;
        public GridItemType Type { get; set; } = GridItemType.None;
        public bool IsWatered { get; set; } = false;
        public bool IsWeeded { get; set; } = false;
        public bool IsQuantityIncreased { get; set; } = false;
        public bool IsQualityIncreased { get; set; } = false;
        public bool IsFertilized { get; set; } = false;
    }

    public class GridItemViewModel
    {
        public GridItemViewModel(GridItem gridItem)
        {
            Type = gridItem.Type.ToString();
        }

        public string Type { get; set; } = GridItemType.None.ToString();
    }

    public enum GridItemType
    {
        None = 0,
        Ca = 1,
        O = 2,
        P = 3,
        T = 4,
        W = 5,
        R = 6,
        Co = 7,
        A = 8,
        B = 9,
    }
}