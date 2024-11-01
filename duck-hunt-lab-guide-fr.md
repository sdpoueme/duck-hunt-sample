# Duck Hunt avec Delegates - Guide du Laboratoire

## Configuration Initiale

1. Créez un nouveau projet Unity 2D
2. Configurez votre scène :
   - Créez un GameObject vide nommé "GameManager"
   - Créez un Canvas UI avec un élément Text (TextMeshPro) pour le score
   - Créez un sprite de canard ou utilisez un placeholder (un simple carré suffira pour les tests)

## Étape 1 : Créer le Script du Canard

1. Créez un nouveau script nommé `Duck.cs`
2. Ajoutez cette implémentation de base :

```csharp
using UnityEngine;

public class Duck : MonoBehaviour
{
    // Étape 1.1 : Créer le delegate
    public delegate void DuckHandler(int points);
    
    // Étape 1.2 : Créer les événements utilisant le delegate
    public static event DuckHandler OnDuckShot;
    
    [SerializeField] private int pointValue = 100;
    [SerializeField] private float speed = 5f;
    
    private void Update()
    {
        // Étape 1.3 : Ajouter le mouvement de base
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        // Étape 1.4 : Déclencher l'événement quand le canard est cliqué
        OnDuckShot?.Invoke(pointValue);
        Destroy(gameObject);
    }
}
```

## Étape 2 : Créer le Gestionnaire de Jeu

1. Créez un nouveau script nommé `GameManager.cs`
2. Implémentez la gestion du score :

```csharp
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject duckPrefab;
    
    private int currentScore = 0;

    // Étape 2.1 : S'abonner aux événements
    private void OnEnable()
    {
        Duck.OnDuckShot += UpdateScore;
    }

    // Étape 2.2 : Se désabonner des événements
    private void OnDisable()
    {
        Duck.OnDuckShot -= UpdateScore;
    }

    // Étape 2.3 : Gérer les mises à jour du score
    private void UpdateScore(int points)
    {
        currentScore += points;
        scoreText.text = $"Score: {currentScore}";
    }
}
```

## Étape 3 : Système d'Apparition des Canards

1. Mettez à jour `GameManager.cs` pour inclure l'apparition :

```csharp
// Ajoutez ces variables au GameManager
[SerializeField] private float spawnInterval = 2f;
private float spawnTimer;

// Ajoutez ceci à la méthode Update
private void Update()
{
    spawnTimer += Time.deltaTime;
    if (spawnTimer >= spawnInterval)
    {
        SpawnDuck();
        spawnTimer = 0f;
    }
}

private void SpawnDuck()
{
    Vector3 spawnPosition = new Vector3(-10f, Random.Range(-4f, 4f), 0f);
    Instantiate(duckPrefab, spawnPosition, Quaternion.identity);
}
```

## Étape 4 : Ajouter le Comportement de Fuite des Canards

1. Mettez à jour `Duck.cs` pour inclure le comportement de fuite :

```csharp
// Ajoutez aux delegates de Duck.cs
public static event DuckHandler OnDuckEscaped;

// Ajoutez ces variables
[SerializeField] private float escapeDuration = 5f;
private float timeAlive;

// Mettez à jour la méthode Update
private void Update()
{
    transform.Translate(Vector3.right * speed * Time.deltaTime);
    
    timeAlive += Time.deltaTime;
    if (timeAlive >= escapeDuration)
    {
        OnDuckEscaped?.Invoke(-pointValue); // Perte de points quand le canard s'échappe
        Destroy(gameObject);
    }
}
```

2. Mettez à jour `GameManager.cs` pour gérer les canards qui s'échappent :

```csharp
// Ajoutez à OnEnable
Duck.OnDuckEscaped += UpdateScore;

// Ajoutez à OnDisable
Duck.OnDuckEscaped -= UpdateScore;
```

## Étapes de Test

1. Attachez le script `GameManager` au GameObject GameManager
2. Créez un prefab de canard :
   - Créez un nouveau GameObject avec un sprite
   - Ajoutez un Box Collider 2D
   - Ajoutez le script Duck
   - Faites glisser le GameObject dans la fenêtre Project pour créer un prefab
   - Supprimez l'instance de la scène

3. Configurez les références :
   - Faites glisser le composant TextMeshPro du score vers le champ scoreText dans GameManager
   - Faites glisser le prefab du canard vers le champ duckPrefab dans GameManager

4. Testez le jeu :
   - Appuyez sur Play
   - Cliquez sur les canards pour les tirer
   - Observez le score augmenter quand vous tirez les canards
   - Observez le score diminuer quand les canards s'échappent

## Problèmes Courants

- Si les clics ne sont pas détectés, vérifiez que :
  - Le canard a bien un composant Collider 2D
  - Le collider du canard n'est pas réglé sur Trigger
  - La caméra a un composant Physics Raycaster

- Si le score ne se met pas à jour, vérifiez que :
  - La référence scoreText est bien définie dans l'inspecteur
  - Les événements delegate sont correctement abonnés dans OnEnable

## Prochaines Étapes

Une fois l'implémentation de base fonctionnelle, vous pouvez ajouter :
1. Différents types de canards avec différentes valeurs de points
2. Des effets sonores lors des tirs
3. Un système de munitions limitées
4. Des power-ups ou des canards spéciaux

Tous ces ajouts peuvent utiliser le système de delegates que vous avez construit !
