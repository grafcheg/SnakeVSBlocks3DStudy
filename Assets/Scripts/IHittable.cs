using UnityEngine.Events;

public interface IHittable
{
    int Health { get; }
    UnityEvent OnDie { get; set; }
    UnityEvent OnGetHit { get; set; }
    void GetHit();
}
