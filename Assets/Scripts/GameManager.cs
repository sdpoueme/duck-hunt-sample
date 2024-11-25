// GameManager.cs
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;


using System.Threading.Tasks;
//using TMPro;



[System.Serializable] // Permet à Unity de sérialiser la classe dans l'Inspector
public class GameManager : MonoBehaviour
{
    [SerializeField] 
    public DuckStats duckStats;
    public GameObject normalDuckPrefab;
    public GameObject goldenDuckPrefab;
    public GameObject fastDuckPrefab;
    
    RaycastHit hit;
    
    public int level = 1; 

    
    public GameProgression myGameProgression = new GameProgression();

    private List<Duck> activeDucks = new List<Duck>();
    private List<Duck> killedDucks = new List<Duck>();
    private float spawnTimer;
    private Camera mainCamera;
    private int currentScore = 0;

    public delegate void goldenDuckHit();
    public static event goldenDuckHit OnGoldenDuckHit;

    //[SerializeField] private TextMeshProUGUI scoreText;


    void Start()
    {
        mainCamera = Camera.main;
        spawnTimer = duckStats.spawnInterval;
        InitializeGameData();
        GameManager.OnGoldenDuckHit += HandleGoldenDuckHit;
    }

    public async void InitializeGameData()
    {
        await GameData.Initialize();
    }

    void Update()
    {

       HandleSpawning();
       HandleInput();
    
        
    }

    private void OnEnable()
    {
        Duck.OnDuckShot += UpdateScore;
        Duck.OnDuckEscaped += UpdateScore;
    }

    private void OnDisable()
    {
        //GameData.realm.Dispose();
        Duck.OnDuckShot -= UpdateScore;
        Duck.OnDuckEscaped -= UpdateScore;
    }

    private void UpdateScore(int points)
    {
        currentScore += points;
        Debug.Log($"Score: {currentScore}");
        
        //scoreText.text = $"Score: {currentScore}";
    }

    private void HandleSpawning()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnDuck();
            spawnTimer = duckStats.spawnInterval;
        }

        // Utilisation de LINQ pour vérifier s'il faut créer un canard doré
        if (!activeDucks.Any(d => d.type == DuckType.Golden))
        {
            if (UnityEngine.Random.Range(0, 100) < 10) // 10% de chance
            {
                SpawnDuck(DuckType.Golden);
            }
        }

        if (!activeDucks.Any(d => d.type == DuckType.Fast))
        {
            if (UnityEngine.Random.Range(0, 100) < 10) // 10% de chance
            {
                SpawnDuck(DuckType.Fast);
            }
        }

        //display the count of active ducks by type
        /*int normalDucks = activeDucks.Count(d => d.type == DuckType.Normal);
        int goldenDucks = activeDucks.Count(d => d.type == DuckType.Golden);
        int fastDucks = activeDucks.Count(d => d.type == DuckType.Fast);*/

        /*var duckGroupsStats = activeDucks
            .GroupBy(d => d.type)
            .Select(g => new
            {
                Type = g.Key,
                Count = g.Count()
            })
            .ToList();*/

        var duckGroupsStats = from duck in activeDucks group duck by duck.type into typeGroup
                              select new
                              {
                                  Type = typeGroup.Key,
                                  Count = typeGroup.Count(),
                                  TotalValue = typeGroup.Sum(d => d.pointsValue)
                              };    
        

            
    }

    private void HandleDuckCleanup()
    {
        // Utilisation de LINQ pour nettoyer les canards hors écran
        var ducksToRemove = activeDucks
            .Where(duck => !IsOnScreen(duck.transform.position))
            .ToList();

        foreach (var duck in ducksToRemove)
        {
            activeDucks.Remove(duck);
            Destroy(duck.gameObject);
        }
    }

    private  void HandleInput()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked");

            //position of the mouse
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.z; 

            //we create a ray from the camera to the mouse position


            Debug.DrawRay(Camera.main.ScreenToWorldPoint(mousePosition), Camera.main.transform.forward, Color.red, 3f);

            //if we have a hit
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Camera.main.transform.forward, out hit, Mathf.Infinity))
                    {
                        //check if one of the ducks is hit using LINQ
                        if (activeDucks.Any(d => d.gameObject == hit.collider.gameObject))
                        {
                            Duck duck = activeDucks.FirstOrDefault(d => d.gameObject == hit.collider.gameObject);
                            HandleDuckHit(duck);
                        }
                         
                    }    
            
        }
    }

    private  async void HandleDuckHit(Duck duck)
    {
        if (duck.type == DuckType.Golden)
        {
            OnGoldenDuckHit?.Invoke();
        }

        duck.isAlive = false;
        killedDucks.Add(duck);
        activeDucks.Remove(duck);
        
        //update game progression
        GameStats stats = GetCurrentStats(); 
        myGameProgression.GameProgressionData(level.ToString(),stats.TotalScore.ToString(), DateTime.Now.ToString(), stats.Accuracy.ToString(),  stats.DucksKilled.ToString());
      
        await GameData.StoreGameProgression(myGameProgression);

        // Animation de chute
        StartCoroutine(DuckFallAnimation(duck));
    }

    private void HandleGoldenDuckHit()
    {
        Debug.Log("Golden duck hit");
 
    }

    private System.Collections.IEnumerator DuckFallAnimation(Duck duck)
    {
        float fallDuration = 1f;
        float elapsed = 0f;
        Vector3 startPos = duck.transform.position;
        Vector3 endPos = new Vector3(startPos.x, -2f, startPos.z);

        while (elapsed < fallDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fallDuration;
            duck.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        Destroy(duck.gameObject);
    }

    Duck SpawnDuck(DuckType type = DuckType.Normal)
    {
        GameObject prefab = type switch
        {
            DuckType.Golden => goldenDuckPrefab,
            DuckType.Fast => fastDuckPrefab,
            _ => normalDuckPrefab
        };

        Vector3 spawnPosition = new Vector3(
            UnityEngine.Random.Range(20f, 10f),
            duckStats.minHeight,
            0
        );

        GameObject duckObj = Instantiate(prefab, spawnPosition, Quaternion.identity);
        Duck duck = duckObj.GetComponent<Duck>();
        duck.Initialize(type, duckStats.baseSpeed, duckStats.pointsValue);
        activeDucks.Add(duck);
        return duck;
    }

    private bool IsOnScreen(Vector3 position)
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && 
               screenPoint.y >= 0 && screenPoint.y <= 1 && 
               screenPoint.z > 0;
    }

    public GameStats GetCurrentStats()
    {
        return new GameStats
        {
            TotalScore = killedDucks.Sum(d => d.pointsValue),
            DucksKilled = killedDucks.Count,
            GoldenDucksKilled = killedDucks.Count(d => d.type == DuckType.Golden),
            Accuracy = CalculateAccuracy()
        };
    }

    private float CalculateAccuracy()
    {
        if (killedDucks.Count == 0) return 0f;
        return (float)killedDucks.Count / (float)currentScore;
    }

    List<Duck> getActiveDucks()
    {
        return activeDucks;
    }

    void TestSpawning()
    {
        // Test de spawn massif
        for (int i = 0; i < 5; i++)
        {
            SpawnDuck();
        }

        // Test de requêtes LINQ intensives
        var stats = activeDucks
            .GroupBy(d => d.type)
            .Select(g => new { 
                Type = g.Key, 
                Count = g.Count(), 
                AverageSpeed = g.Average(d => d.speed) 
            })
            .ToList();

            Console.WriteLine("stats:"+stats);
    }

    
}

