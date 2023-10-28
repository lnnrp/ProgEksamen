using System;

namespace Astar
{
    public class Point
    {
        #region Properties
        /// <summary>
        /// X position
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Y position
        /// </summary>
        public int Y { get; private set; }

        public ConsoleColor Color { get; private set; }

        public bool Walkable { get; private set; }

        public Point Parent { get; private set; }

        /// <summary>
        /// Value that A* uses to determine point to go after
        /// </summary>
        public int F { get => G + H; }

        /// <summary>
        /// The cost of moving to this point
        /// </summary>
        public int G { get; set; }

        /// <summary>
        /// Estimated prixe to move from start to end (direct way, doesn't account for walls)
        /// </summary>
        public int H { get; set; }
        #endregion

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Changes color for point
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Point SetColor(ConsoleColor color)
        {
            Color = color;
            return this;
        }

        /// <summary>
        /// Sets walkable for point
        /// </summary>
        /// <param name="walkable"></param>
        /// <returns></returns>
        public Point SetWalkable(bool walkable)
        {
            Walkable = walkable;
            return this;
        }

        /// <summary>
        /// Sets parent to this point
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public Point SetParent(Point parent)
        {
            Parent = parent;
            return this;
        }

        /// <summary>
        /// Calculates distance to a point using pythagoras
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public int DistanceTo(Point point)
        {
            return (int)Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));
        }
    }
}
