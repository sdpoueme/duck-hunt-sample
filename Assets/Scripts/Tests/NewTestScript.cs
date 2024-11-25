using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
     // A Test behaves as an ordinary method
    [Test]
    public void GameManagerCreationTest()
    {
        //Test to validate that we can create a game manager
        
        /*GameManager gameManager = new GameManager();
        gameManager.TestSpawning();

        Assert.IsNotNull(gameManager);*/

    }

    [Test]
    public void NormalDuckCreationTest()
    {
     

        // Use the duck factory to create a duck
        /*GameManager gameManager = new GameManager();

        DuckType type = DuckType.Normal;

        Duck normalDuck = gameManager.SpawnDuck(type);

        Assert.IsNotNull(normalDuck);*/

    }

   
}
