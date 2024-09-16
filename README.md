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
