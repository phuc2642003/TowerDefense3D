using UnityEngine;

#region GameplayState
public class PrepareState : IState
{
    public void Enter()
    {
        Debug.Log("Prepare State Enter");
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        
    }
}
public class PlayingState : IState
{
    public void Enter()
    {
        SpawnManager.Instance.StartRound();
        GUIManager.Instance.startRoundUI.SetActive(false);
    }

    public void Update()
    {
        GameplayManager.Instance.CheckWinCondition();
        GameplayManager.Instance.CheckLoseCondition();
    }

    public void Exit()
    {
        
    }
}
public class GameWinState : IState
{
    public void Enter()
    {
        Debug.Log("Win Game");
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        
    }
}
public class GameLoseState : IState
{
    public void Enter()
    {
        SpawnManager.Instance.StopSpawning();
        Time.timeScale = 0;
        Debug.Log("Lose Game");
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        
    }
}

#endregion

