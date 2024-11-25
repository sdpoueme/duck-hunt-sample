[System.Serializable] // Cette ligne est cruciale !

public class DuckStats
{
    //vitesse de base du canard qui vole
    public float baseSpeed = 5f;

    //nombre total de points
    public int pointsValue = 100;

    //fréquence à laquelle un canard est créé
    public float spawnInterval = 2f;

    //hauteur de vol maximale du canard
    public float maxHeight = 10f;

    //hauteur de vol minimale du canard
    public float minHeight = 1f;

    //difficulté du jeu
     public int GameDifficulty =1; 
}