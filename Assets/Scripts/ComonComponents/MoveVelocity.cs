using UnityEngine;

public class MoveVelocity : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;
    
    private Vector2 _playerMovement = Vector2.zero;

    private void FixedUpdate()
    {
        _playerMovement.x = joystick.Horizontal * speed;
        _playerMovement.y = joystick.Vertical * speed;
		
        MoveRigidbody();
    }

    public void MoveRigidbody()
    {
        GetComponent<Rigidbody2D>().velocity = _playerMovement;
    }
}
