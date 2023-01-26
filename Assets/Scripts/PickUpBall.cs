using TMPro;
using UnityEngine;

public class PickUpBall : MonoBehaviour
{
    public int length = 1;

    public TMP_Text lengthText;
    
    private void Start()
    {
        lengthText.SetText(length.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        var playerGameObject = collision.gameObject;
        
        if (!playerGameObject.TryGetComponent(out SnakeTail player)) return;

        Destroy(gameObject);
        player.AddMultipleCircles(length);
    }
}
