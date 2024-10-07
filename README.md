# duck-hunt-sample

Welcome to this code sample showing how to build a duck hunt project in Unity. 

# Game description

Our basic duck hunt implementation will allow a player to choose a difficulty level when lauching the game. The player will use a weapon to make as many hits as possible on flying ducks. The game will take place in a forest landscape. 

# Architecture

Here is our game hierarchy:

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
          
Our game will feature the following objects:


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



## **Évaluation de l'algorithme de Dijkstra dans Duck Hunt**

### **Algorithme de Dijkstra et Duck Hunt**
* **Description de l'algorithme:** Fournir une explication claire de l'algorithme de Dijkstra, y compris ses étapes et son fonctionnement.
* **Application à Duck Hunt:** Discuter de la manière dont l'algorithme de Dijkstra peut être adapté au jeu Duck Hunt, comme représenter la carte du jeu sous forme de graphe et déterminer le plus court chemin vers le canard cible.

### **Méthodologie d'évaluation**
* **Cas de test:** Décrire les cas de test ou les scénarios spécifiques qui seront utilisés pour évaluer les performances de l'algorithme. Cela peut inclure différentes configurations de cartes, des positions de canards et des points de départ du joueur.
* **Métriques:** Définir les métriques qui seront utilisées pour mesurer l'efficacité de l'algorithme, telles que :
    * **Longueur du chemin:** La distance totale parcourue par le joueur pour atteindre le canard cible.
    * **Temps d'exécution:** Le temps nécessaire à l'algorithme pour calculer le plus court chemin.
    * **Précision:** Le pourcentage de cas de test où l'algorithme trouve avec succès le plus court chemin.
* **Configuration expérimentale:** Spécifier l'environnement matériel et logiciel utilisé pour l'évaluation, y compris le langage de programmation et les bibliothèques pertinentes.

### **Résultats**
* **Présentation des données:** Présenter les résultats de l'évaluation de manière claire et concise, en utilisant des tableaux, des graphiques ou d'autres visualisations.
* **Analyse:** Analyser les résultats et discuter des conclusions, en comparant les performances de l'algorithme de Dijkstra à d'autres approches potentielles ou méthodes de référence.

### **Conclusion**
* **Résumé:** Résumer les principales conclusions de l'évaluation, en soulignant les forces et les faiblesses de l'algorithme de Dijkstra dans le contexte de Duck Hunt.
* **Recommandations:** Sur la base des résultats de l'évaluation, fournir des recommandations pour d'éventuelles améliorations ou approches alternatives qui pourraient être envisagées.

**Exemple de tableau Markdown pour les résultats:**

| Cas de test | Longueur du chemin | Temps d'exécution | Précision |
|---|---|---|---|
| 1 | 100 | 0,025 | 100% |
| 2 | 120 | 0,030 | 100% |
| 3 | 85 | 0,020 | 95% |
| ... | ... | ... | ... |

**Remarque:** Ce modèle fournit une structure générale pour l'évaluation. Vous devrez peut-être l'adapter à vos besoins spécifiques et à la complexité de votre implémentation.
