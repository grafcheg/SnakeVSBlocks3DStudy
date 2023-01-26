using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameObject _gameManagerObject;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManagerObject = GameObject.FindWithTag("Finish");
        _gameManager = _gameManagerObject.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out Player player)) return;

        player.FinishLevel();
    }
}
