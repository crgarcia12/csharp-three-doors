using System;
using System.Collections.Generic;

public static class ListExtension
{
    public static T GetAndRemoveRandomElement<T>(this List<T> theList, Random random)
    {
        int randomIndex = random.Next(0, theList.Count);
        T element = theList[randomIndex];
        theList.RemoveAt(randomIndex);

        return element;
    }
}

public class Game
{
    int[] scenario={0,0,0};
    List<int> closedDoors = new List<int>() {0,1,2};

    Random random;

    public Game(Random random)
    {
        this.random = random;
        scenario[random.Next(0,3)] = 1;

    }

    public bool OpenRandomDoor()
    {
        int doorIndex = closedDoors.GetAndRemoveRandomElement(random);
        if (scenario[doorIndex] == 1)
        {
            return true;
        }
        return false;
    }
}

public class GameEngine
{

    int wonGames = 0;
    int lostGames = 0;

    public GameEngine()
    {


    }

    public void StartSimulation()
    {
        var random = new Random();
        
        for(int games = 0; games < 10000; games++)
        {
            Game game = new Game(random);
        }

    }

    private void PlayGame(Game game)
    {
        for(int i = 0; i<2;i++)
        {
            if(game.OpenRandomDoor())
            {
                wonGames++;
                return;
            }
        }
        lostGames++;
    }
}