using System.Net.NetworkInformation;

internal class Program
{
    private static void Main(string[] args)
    {
        string[,] grid = new string[10,10];
        // Creates the grid.
        int x = 0;
        int y = 0;
        // Stores the x and y position.
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                grid[i, j] = "empty";
            }
        }
        // For loop that sets every value to empty.
        Console.WriteLine("Welcome to the bomb game, get to position 9,9, but if you step on a bomb you explode!");
        Console.WriteLine("How many bombs do you want to be placed in the grid?");
        int bombs = int.Parse(Console.ReadLine());
        // The use enters the number of bombs they want in the grid
        for (int i = 0;i < bombs; i++)
        {
            int pos1 = new Random().Next(0,9);
            int pos2 = new Random().Next(0,9);
            while (pos1 == 0 || pos2 == 0)
            {
                pos1 = new Random().Next(0, 9);
                pos2 = new Random().Next(0, 9);
            }
            grid[pos1, pos2] = "bomb";
        }
        // For loop that places the bombs in the grid.
        Console.WriteLine("Bombs have been placed");
        while (x != 9 || y != 9)
        {
            Console.WriteLine("You are in position {0},{1}, what direction do you want to move?(N E S W)", x, y);
            string direction = Console.ReadLine();
            switch (direction)
            {
                case "N":
                    y = north(y);
                    break;
                case "E":
                    x =east(x);
                    break;
                case "S":
                    y = south(y);
                    break;
                case "W":
                    x = west(x);
                    break;
                default : Console.WriteLine("An invalid value has been entered, no movement will occur.");
                    break;
            }
            // Switch case statement that uses subroutines to handle movement.
            int nearby = 0;
            if (grid[x, y] == "bomb")
            {
                Console.WriteLine("You stepped on a bomb, game over!");
                break;
            }
            //If statement to handle game overs.
            if (x < 9)
            {
                if (grid[x + 1, y] == "bomb")
                {
                    nearby += 1;
            }   }
            if (x > 0)
            {
                if (grid[x - 1, y] == "bomb")
                {
                    nearby += 1;
                }
            }
            if (y < 9)
            {
                if (grid[x , y + 1] == "bomb")
                {
                    nearby += 1;
                }
            }
            if (y > 0)
            {
                if (grid[x, y - 1] == "bomb")
                {
                    nearby += 1;
                }
            }
            //If chain to count how many bombs are nearby.
            string nb = Convert.ToString(nearby);
            if (nearby == 1)
            {
                Console.WriteLine("There is 1 bomb nearby");
            }
            else
            {
                Console.WriteLine("There are {0} bombs nearby", nb);
            }
            //Tells the user how many bombd are in spaces they could move to.
        }
        if (x ==9 &&  y == 9)
        {
            Console.WriteLine("Congratulations, you won!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
    public static int north(int y)
    {
        y += 1;
        if (y > 9)
        {
            Console.WriteLine("Outside bounds of the grid, no movement will occur.");
            y -= 1;
        }
        else
        {
            Console.WriteLine("Moving north 1 space.");
        }
        return y;
    }
    public static int east(int x)
    {
        x += 1;
        if (x > 9)
        {
            Console.WriteLine("Outside bounds of the grid, no movement will occur.");
            x -= 1;
        }
        else
        {
            Console.WriteLine("Moving east 1 space.");
        }
        return x;
    }
    public static int south(int y)
    {
        y -= 1;
        if (y < 0)
        {
            Console.WriteLine("Outside bounds of the grid, no movement will occur.");
            y += 1;
        }
        else 
        {
            Console.WriteLine("Moving south 1 space.");
        }
        return y;
    }
    public static int west(int x)
    {
        x -= 1;
        if (x < 0)
        {
            Console.WriteLine("Outside bounds of the grid, no movement will occur");
            x += 1;
        }
        else
        {
            Console.WriteLine("Moving west 1 space.");
        }
        return x;
    }
}