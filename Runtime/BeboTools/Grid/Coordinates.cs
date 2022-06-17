// ReSharper disable InconsistentNaming
namespace BeboTools.Grid
{
    public struct Coordinates
    {
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public readonly int x;
        public readonly int y;
    }
}