using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IHittable
{
    public GameManager gameManager;

    [field: SerializeField]
    public int Health { get; set; } = 1;
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }
    
    private bool _dead = false;
    private SnakeTail _snakeTail;

    private void Start()
    {
        _snakeTail = GetComponent<SnakeTail>();
    }

    public void GetHit()
    {
        if (_dead) return;

        Health--;
        
        if (Health <= 0)
        {
            OnDie?.Invoke();
            _dead = true;
            return;
        }
        
        _snakeTail.RemoveCircle();
        OnGetHit?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
        gameManager.OnPlayerDeath();
    }

    public void FinishLevel()
    {
        Destroy(gameObject);
        gameManager.OnFinish();
    }
}
