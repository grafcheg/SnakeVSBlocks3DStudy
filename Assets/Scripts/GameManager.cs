using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Play,
        Win,
        Loss,
    }
    
    public State CurrentState { get; private set; }
}
