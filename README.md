# **duck-hunt-sample**

# **Description du jeu**

Notre implémentation de base de la chasse au canard permettra au joueur de choisir un niveau de difficulté lors du lancement du jeu. Le joueur utilisera une arme pour faire autant de coups que possible sur des canards en vol. Le jeu se déroulera dans un paysage forestier.

# **Architecture**

Voici notre hiérarchie de jeu :

DuckHuntGame (Singleton)
- GameLeaderboard (Singleton)
- GameMatch
  - GamePlayer
  - GameDucks (Factory)
    - NormalDucks
    - FlyingDucks
  - GameEnvironment (Composite)
    - ForestBackground
    - Trees
    - Music

- classe a: DuckHuntGame

| Attribut | Fonctions |
|---------:|-----------|
| string uuid |  |
| GameLeaderboard ld | BuildGameEnvironment() |
| list GameMatch | launchGameMatch() |


- classe b: GameMatch
  
| Attribut | Fonctions |
|---------:|-----------|
| string id | public setGameMathId(), public getGameMatchId() |
| int score | private setGameScore() |
| gameEnvironment ge | private gameEnvironment () |
| GamePlayer player1 | public getPlayerInfo() |
| GameDucks ennemies | public spawnDucks() |



#  Logique de l'engin de Jeu 

## **Évaluation de l'algorithme de Dijkstra dans Duck Hunt**

### **Algorithme de Dijkstra et Duck Hunt**
* **Description de l'algorithme:** Fournir une explication claire de l'algorithme de Dijkstra, y compris ses étapes et son fonctionnement.
* **Application à Duck Hunt:** Discuter de la manière dont l'algorithme de Dijkstra peut être adapté au jeu Duck Hunt, comme représenter la carte du jeu sous forme de graphe et déterminer le plus court chemin vers le canard cible.

# Description du Game Manager

## GameManager.cs Overview
🎮 Core Purpose
Duck hunting game manager in Unity

Controls duck spawning, scoring, and game mechanics

🔑 Key Components
Duck Management
```bash
private List<Duck> activeDucks = new List<Duck>();
private List<Duck> killedDucks = new List<Duck>();
```

