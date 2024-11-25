using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;

public partial class GameProgression : IRealmObject
{
    [MapTo("_id")]
    [PrimaryKey]
    public ObjectId Id { get; set; }

    [MapTo("accuracy")]
    public string Accuracy { get; set; }

    [MapTo("duckskilled")]
    public string Duckskilled { get; set; }

    [MapTo("level")]
    public string Level { get; set; }

    [MapTo("score")]
    public string Score { get; set; }

    [MapTo("timestamp")]
    public string Timestamp { get; set; }

    public void GameProgressionData(string accuracy, string duckskilled, string level, string score, string timestamp)
    {
        Accuracy = accuracy;
        Duckskilled = duckskilled;
        Level = level;
        Score = score;
        Timestamp = timestamp;
    }
}
