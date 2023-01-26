using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float sensitivity = 10;
    public bool donNotMoveForward = false;

    public int length = 1;

    public TMP_Text lengthText;

    private Camera _mainCamera;
    private Rigidbody _rigidbody;
    private Player _player;
    
    private Vector2 _mouseLastPosition;

    private float _angularVelocity;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        length = _player.Health;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseLastPosition = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _angularVelocity = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)_mainCamera.ScreenToViewportPoint(Input.mousePosition) - _mouseLastPosition;
            _angularVelocity += delta.x * sensitivity;
            _mouseLastPosition = _mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        length = _player.Health;
        lengthText.SetText(length.ToString());
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_angularVelocity) > 4)
        {
            _angularVelocity = 4 * Mathf.Sign(_angularVelocity);
        }

        if (donNotMoveForward)
        {
            _rigidbody.velocity = new Vector3(_angularVelocity * 5, 0f, 0f);
        }
        else
        {
            _rigidbody.velocity = new Vector3(_angularVelocity * 5, 0f, speed);
        }
        _angularVelocity = 0;
    }
}
