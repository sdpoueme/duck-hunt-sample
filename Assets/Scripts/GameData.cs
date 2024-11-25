using System;
using System.Threading.Tasks;
using Realms;
using Realms.Sync;
using UnityEngine;

public static class GameData 
{
    public static Realm realm;
    public static User user;
    private static readonly string atlasAppId = "application-1-rbeetet"; //"application-0-tqprhce"; // Your Atlas App ID

    public static async Task Initialize() 
    {
        try 
        {
            var app = App.Create(atlasAppId);
            
            // Assuming you're using Anonymous authentication
            // For other auth methods (email/password, etc.), you'll need to modify this part
            user = await app.LogInAsync(Credentials.Anonymous());
            
            // Configure sync
            var config = new PartitionSyncConfiguration(user.Id, user);

            realm = await Realm.GetInstanceAsync(config);
            Debug.Log("Successfully connected to MongoDB Atlas");
        }
        catch (Exception e) 
        {
            Debug.LogError($"Failed to connect to MongoDB Atlas: {e.Message}");
        }
    }

    public static async Task StoreGameProgression(GameProgression myGameProgression)
    {
        try 
        {
            await realm.WriteAsync(() =>
            {
                realm.Add(myGameProgression);
            });
            Debug.Log("Game progression stored successfully");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to store game progression: {e.Message}");
        }
    }

    

}