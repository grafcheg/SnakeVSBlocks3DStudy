using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SquareBlock : MonoBehaviour, IHittable
{
    public Color colorMaxHP = Color.red;
    public Color colorMinHP = Color.green;
    public TMP_Text lengthText;
    
    [field: SerializeField]
    public int Health { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    private bool _waitBeforeNextAttack;
    private bool _dead = false;
    private int _maxHealth = 15;
    private Renderer _renderer;

    private void Start()
    {
        lengthText.SetText(Health.ToString());
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        float t = Mathf.InverseLerp(_maxHealth, 1f, Health);
        _renderer.material.color = Color.Lerp(colorMaxHP, colorMinHP,  t);
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (!collisionInfo.collider.gameObject.CompareTag("Player")) return;
        
        if (!_waitBeforeNextAttack)
        {
            Attack(collisionInfo);
            StartCoroutine(WaitCoroutine());
        }
    }

    private void OnCollisionExit(Collision other)
    {
        StopCoroutine(WaitCoroutine());
    }

    private void Attack(Collision collision)
    {
        var hittable = collision.gameObject.GetComponent<IHittable>();
        hittable?.GetHit();
        GetHit();
    }
    
    public void GetHit()
    {
        if (_dead) return;
        
        Health--;
        lengthText.SetText(Health.ToString());
        OnGetHit?.Invoke();

        if (Health <= 0)
        {
            OnDie?.Invoke();
            _dead = true;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
    IEnumerator WaitCoroutine()
    {
        _waitBeforeNextAttack = true;
        yield return new WaitForSeconds(0.5f);
        _waitBeforeNextAttack = false;
    }
}
