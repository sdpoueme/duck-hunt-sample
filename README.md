# **duck-hunt-sample**

# **Description du jeu**

Notre implémentation de base de la chasse au canard permettra au joueur de choisir un niveau de difficulté lors du lancement du jeu. Le joueur utilisera une arme pour faire autant de coups que possible sur des canards en vol. Le jeu se déroulera dans un paysage forestier.

# **Architecture**

Voici notre hiérarchie de jeu :

```mermaid
flowchart LR
    subgraph DuckHuntGame
        direction TB
        A((DuckHuntGame)) --> B{GameLeaderboard}
        A --> C{GameMatch}
    end
    subgraph GameMatch
        direction TB
        C --> D{GamePlayer}
        C --> E{GameDucks}
        E --> F{NormalDucks}
        E --> G{FlyingDucks}
        C --> H{GameEnvironment}
        H --> I{ForestBackground}
        H --> J{Trees}
        H --> K{Music}
    end


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
