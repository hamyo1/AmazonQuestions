

int[] egArray = { 4, 12, 2, 7, 3,18,20,3,19 };
int ladder = 2;
int bricks = 10;


Console.WriteLine("result:" + FarthestBuildingAllVariation(egArray, ladder, bricks,0));


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
