/*
 getting from https://www.youtube.com/watch?v=yKz2kPip4sg&t=2s
 Given a grid of robot positions, indicate if it is a vaild time series 
for the number of robots specified if Robots can only travel
 up to 1 index further than their position One Step before.

Input format: an array of arrays, of which each index can be 0 or 1.
An index corresponds to the physical locatio which is either occupied by a robot (1) or empty (0)

Ex:
Grid: [[1,0,0,1],[0,1,1,0]] is a vaild time series for 2 rbots because the first robot moved from index 0 to index 1 and robot2 moved from index 3 to index 2)

Grid [[1,0,0,0,1],[1,0,1,0,0]] is not vaild becuse the secnd robot 
started at index 4 but did not hav a vaild position n the next step

 my sln including this variation = [[1,1,0,0],[1,0,0,1]]
 */

int[,] grid = new int[,] { { 1, 0, 0, 0, 1 }, { 1, 0, 1, 0, 0 } };
int numOfRobots = 2;
Console.WriteLine("result: " + isVaildPath(grid, numOfRobots));

bool isVaildPath(int[,] grid, int numOfRobots)
{
    int sum1RobotsArray = 0;
    int sum2RobotsArray = 0;

    if (numOfRobots >= 0)
    {
        if(grid.GetLength(0)==1)//only 1 array (the robots are not travel.)
        {
            for(int col = 0; col < grid.GetLength(1); col++)
            {
                if(grid[0,col] == 1)
                {
                    sum1RobotsArray++;
                }
            }
            return sum1RobotsArray == numOfRobots? true:false;
        }
        for (int raw = 0; raw < grid.GetLength(0) - 1; raw++)
        {
            int lastUsedIndex = -1;
            sum1RobotsArray = 0;
            sum2RobotsArray = 0;
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                if (grid[raw, col] > 1 || grid[raw, col] < 0 || grid[raw + 1, col] > 1 || grid[raw + 1, col] < 0) return false;

                //robos can turn just 1 index to the rghit or 1 to the left
                //robots can stay at they are position!
                //check if robots not stays on they are position
                //check if they are travel 1 to the left
                if (col != 0 && lastUsedIndex < col - 1
                    && grid[raw, col] == 1 && grid[raw + 1, col - 1] == 1)
                {
                    lastUsedIndex = col - 1;
                    sum1RobotsArray++;
                }
                //check if they are travel 1 to the rghit
                else if (col + 1 != grid.GetLength(1) && lastUsedIndex < col + 1
                    && grid[raw, col] == 1 && grid[raw + 1, col + 1] == 1)
                {
                    lastUsedIndex = col + 1;
                    sum1RobotsArray++;
                }
                // sum robots if they are stays on they are position
                else if (grid[raw, col] == 1 && grid[raw + 1, col] == 1)
                {
                    lastUsedIndex = col;
                    sum1RobotsArray++;

                }
                if (grid[raw + 1, col] == 1)
                {
                    sum2RobotsArray++;
                }

            }
            if (sum1RobotsArray != sum2RobotsArray && sum1RobotsArray != numOfRobots) return false;
        }
        if (sum1RobotsArray == sum2RobotsArray && sum1RobotsArray == numOfRobots) return true;

        return false;
    }


    return false;
}