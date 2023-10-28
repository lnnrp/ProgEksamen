using System;
using Astar;

/// <summary>
/// Size of "level grid"
/// </summary>
int sizeX, sizeY;

/// <summary>
/// Movement grid
/// </summary>
Point[,] grid = null, oldGrid = null;

/// <summary>
/// The default cost to move from one point to another
/// </summary>
const int moveCost = 10;

while (true)
{
    // Size of the level
    sizeX = Console.BufferWidth - 1;
    sizeY = Console.BufferHeight - 1;

    // 2D array that acts as level for A* to go from Point A to Point B
    grid = new Point[sizeX, sizeY];

    // Double for-loop that adds points into grid with their given positions
    for(int x = 0; x < sizeX; x++)
    {
        for(int y = 0; y < sizeY; y++)
        {
            grid[x, y] = new Point(x, y);
        }
    }

    // Randomly assigns places in grid as walls
    Random rnd = new Random();
    for(int i = 0; i < sizeX * sizeY / 3; i++)
    {
        grid[rnd.Next(0, sizeX), rnd.Next(0, sizeY)].SetColor(ConsoleColor.Gray).SetWalkable(false);
    }

    // Random start point for A* algorithm
    Point start = grid[rnd.Next(0, sizeX), rnd.Next(0, sizeY)].SetColor(ConsoleColor.Green).SetWalkable(true);

    // Random end point for A* algorithm
    Point end = grid[rnd.Next(0, sizeX), rnd.Next(0, sizeY)].SetColor(ConsoleColor.Red).SetWalkable(true);

    // Updates conolse
    UpdateUI();
    Console.ReadLine();

    // Starts A*
    FindPath(start, end);
    Console.ReadLine();
    
}

void FindPath(Point start, Point end)
{
    // List of all points that aren't part of the final path
    // Haven't been searched through
    List<Point> openList = new List<Point>() { start };

    // List of points searched through that can be a part of final part
    List<Point> closedList = new List<Point>();

    bool pathFound = false;

    // Searches for path until found or openlist isn't empty
    while(!pathFound && openList.Count > 0)
    {
        // Sets best point to be the one with lowest F value
        // First point is the best in first rin through
        Point best = openList.First(x => x.F == openList.Min(p => p.F));
        openList.Remove(best);
        closedList.Add(best);

        // Changes color of points placed in closedList
        if(best.Color == ConsoleColor.Yellow)
        {
            best.SetColor(ConsoleColor.DarkYellow);
            UpdateUI();
        }

        // Checks neighbour points and calculates F/G/H values and places them in openList
        for(int x = -1; x <= 1; x++)
        {
            if (pathFound)
                break;

            for(int y = -1; y <= 1; y++)
            {
                if (pathFound)
                    break;

                // Finds best points neighbor x & y
                int neighborX = best.X + x;
                int neighborY = best.Y + y;

                // Checks if neighbor x/y is outside of grid
                if (neighborX < 0 || neighborY < 0 || neighborX > sizeX - 1 || neighborY > sizeY - 1)
                    continue;

                if (x != 0 || y != 0)
                    continue;

                // Finds neighbor Point in grid array
                Point neighbor = grid[neighborX, neighborY];

                // Checks if neighbor point already exists in closedList
                if (openList.Contains(neighbor))
                    continue;

                // Checks if neighor is walkable
                if (!neighbor.Walkable)
                    continue;

                // Makes new G value as cost for moving to neighbor
                int newG = best.G + moveCost;

                bool updateNeighbor = false;

                // Checks if neighbor exists in openList, adds if not
                if (openList.Contains(neighbor))
                {
                    // If neighbor G is bigger than new G, update is sat to true
                    // Checks if neighbor is faster for A* to move through from new best than earlier best
                    if (neighbor.G > newG)
                        updateNeighbor = true;
                }
                else
                {
                    openList.Add(neighbor);
                    updateNeighbor = true;
                }

                // Updates neighbors G & H values and sets neighbors parent
                if (updateNeighbor)
                {
                    neighbor.SetParent(best);

                    neighbor.G = newG;

                    neighbor.H = neighbor.DistanceTo(end) * moveCost;
                }

                if (neighbor == end)
                    pathFound = true;
                else
                {
                    // CPU performance 
                    Thread.Sleep(1);
                    neighbor.SetColor(ConsoleColor.Yellow);
                    UpdateUI();
                }
            }
        }
    }

    if (end.Parent == null)
        throw new Exception("Can't find a path :(");
    // Makes path back to start
    else
    {
        Point pointPath = end;
        // Backtracks from end point to start
        while(pointPath != start)
        {
            pointPath = pointPath.Parent;
            if (pointPath != start)
            {
                pointPath.SetColor(ConsoleColor.Blue);
            }
        }

        UpdateUI();
    }

}

void UpdateUI()
{
    if(oldGrid == null)
    {
        // Fills oldgrid with Points set to black if null
        oldGrid = new Point[sizeX, sizeY];
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                oldGrid[x, y] = new Point(x, y).SetColor(ConsoleColor.Black);
            }
        }
    }

    for (int x = 0; x < sizeX; x++)
    {
        for (int y = 0; y < sizeY; y++)
        {
            // Updates oldGrid based on if grids color aren't the same
            if (oldGrid[x, y].Color != grid[x, y].Color)
            {
                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = grid[x, y].Color;
                Console.Write(' ');
            }

            // oldGrid color gets updated to match grid
            oldGrid[x, y].SetColor(grid[x, y].Color);
        }
    }
}