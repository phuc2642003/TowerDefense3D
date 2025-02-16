using UnityEngine;
public class StateManager : MonoBehaviour
{
    IState _currentState;
    
    public void ChangeState(IState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }

    public void Update() => _currentState?.Update();
}
