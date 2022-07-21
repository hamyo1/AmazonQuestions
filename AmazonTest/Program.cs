

int[] egArray = { 4, 12, 2, 7, 3,18,20,3,19 };
int ladder = 2;
int bricks = 10;
List<int> difList = new List<int>();
int[] difArray = { 8, 5, 15, 2, 16};

Console.WriteLine("result:" + FarthestBuilding(egArray, ladder, bricks));
for(int i = 0; i < egArray.Length-1; i++)
{
    if(egArray[i]<egArray[i+1])
    {
        difList.Add(egArray[i+1]-egArray[i]);
    }
}


int FarthestBuilding(int[] egArray, int ladder, int bricks,int currentBuilding = 0)
{

    if(currentBuilding == egArray.Length-1)
    {
        return currentBuilding;
    }
    if(egArray[currentBuilding]>=egArray[currentBuilding+1])
    {
        currentBuilding++;
        return FarthestBuilding(egArray, ladder, bricks,currentBuilding);
    }
    if(egArray[currentBuilding]<egArray[currentBuilding+1])
    {
        int dif=egArray[currentBuilding+1] - egArray[currentBuilding];
        if(dif<=bricks)
        {
            bricks=bricks-dif;
            currentBuilding++;
            return FarthestBuilding(egArray, ladder, bricks, currentBuilding);
        }
        if(dif>bricks&&ladder>=1)
        {
            ladder--;
            currentBuilding++;
            return FarthestBuilding(egArray, ladder, bricks, currentBuilding);
        }
        return currentBuilding;
    }


    return 0;

}

