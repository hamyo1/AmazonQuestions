Amazon Challenges 

its came with projecrt on .net 6.0
the main exercize file is https://github.com/hamyo1/AmazonTest/blob/master/BuildingsQuestion/Program.cs
and the tracking Table in here https://github.com/hamyo1/AmazonTest/blob/master/buildingProblem.drawio.png
(you will need to move to the side to see all of variation (I edited it with drawio))

i upload ne more exercize from here https://www.youtube.com/watch?v=yKz2kPip4sg&t=2s and share my sln to this question also..
here is the main file to this question https://github.com/hamyo1/AmazonTest/blob/master/RobotsQuestion/Program.cs

i was adding calculation for the time complex in o notation in the end of each code..



you can also copy the sln for the bulding question from here..

```
/*
Here is the question:
Given a skyline (in a 1 dimensional array), your goal is to get to the furthest building possible.
you start at zeroth building, with a finite number of bricks and ladder it doesn't cost you anything
to move to the building ahead of you
if it is at the same level or lower.
However, if the building is higher, you must use either bricks or a ladder.
A ladder lets you scale any height difference. However if you use bricks, to scale
a height difference of N, you must use N bricks

write a function to return the index of the furthest building you can get to, in the optimal case
e.g. [4,2,20,1,5], 1 ladder, 4 bricks => return 4 (use ladder for 2-> 20, bricks for 1> 5)
*/


int[] egArray = { 4, 12, 2, 7, 3,18,20,3,19 };
int ladder = 2;
int bricks = 10;


Console.WriteLine("result:" + FarthestBuildingAllVariation(egArray, ladder, bricks,0));
//output for this array { 4, 12, 2, 7, 3,18,20,3,19 } is result:7
//output for this array { 4, 12, 2, 7, 3,18,20,3,6 } is result:8


int FarthestBuildingAllVariation(int[] egArray, int ladder, int bricks, int currentBuilding)
{
    if (currentBuilding == egArray.Length-1) return currentBuilding;
    
    int dif= egArray[currentBuilding+1]-egArray[currentBuilding];
    int currentLadder = currentBuilding;
    int currentBricks = currentBuilding;
    
    if(dif<=0) return FarthestBuildingAllVariation(egArray, ladder, bricks, currentBuilding + 1);

    if (ladder==0&&bricks<dif)
    {
        return currentBuilding;
    }

    if(bricks>=dif && dif>0)
    {
        currentBricks = FarthestBuildingAllVariation(egArray, ladder, bricks-dif, currentBuilding+1);
    }

    if (ladder > 0 && dif > 0)
    {
        currentLadder = FarthestBuildingAllVariation(egArray, ladder-1, bricks, currentBuilding+1);
    }
    
    return currentBricks>=currentLadder?currentBricks:currentLadder;
}

// in my calculation for the time complex in o notation => O(2^n) n is the length of the building array

```
