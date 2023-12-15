using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    private Rigidbody2D _rb;
    private bool isGrounded;
    private float move = 0.0f;

    public event Action<float> OnMove; //Evento para quando o jogador caminha

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        GroundChecker groundChecker = GetComponent<GroundChecker>();
        if (groundChecker != null)
        {
            groundChecker.OnGroundedChanged += UpdateGroundedStatus;
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            move = Input.GetAxis("Horizontal");
            _rb.velocity = new Vector2(move * moveSpeed, _rb.velocity.y);
        }
        
        OnMove?.Invoke(move);
    }

    private void UpdateGroundedStatus(bool grounded)
    {
        isGrounded = grounded;
    }
}
