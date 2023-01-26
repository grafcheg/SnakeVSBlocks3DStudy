using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform snakeHead;
    public Transform playerBallPrefab; 
    public float circleDiameter;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        positions.Add(snakeHead.position);
    }

    private void Update()
    {
        float distance = (snakeHead.position - positions[0]).magnitude;

        if (distance > circleDiameter)
        {
            Vector3 direction = (snakeHead.position - positions[0]).normalized;
            
            positions.Insert(0, positions[0] + direction * circleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= circleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / circleDiameter);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(playerBallPrefab, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        _player.Health++;
    }

    public void AddMultipleCircles(int numberToAdd)
    {
        for (int i = 0; i < numberToAdd; i++)
        {
            AddCircle();
        }
    }

    public void RemoveCircle()
    {
        
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);
    }
}
