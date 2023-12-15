using UnityEngine;
using System; // Para usar eventos

public class PlayerJump : MonoBehaviour
{
    public float initialJumpForce = 6.0f;
    public float maxJumpForce = 10.0f;
    public float jumpForceIncrementPerSecond = 10.0f;
    private Rigidbody2D _rb;
    private bool isGrounded;
    private float jumpButtonPressTime;

    public event Action<bool> OnJump; // Evento para quando o jogador pula ou aterrissa
    public event Action<bool> OnFalling; // Evento para quando o jogador está caindo

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        // Se inscreve no evento de mudança de estado de estar no chão
        GroundChecker groundChecker = GetComponent<GroundChecker>();
        if (groundChecker != null)
        {
            groundChecker.OnGroundedChanged += UpdateGroundedStatus;
        }
    }

    void Update()
    {
        // Inicia o acumulo de força de pulo quando o botão de pulo é pressionado
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpButtonPressTime = 0f;
            OnJump?.Invoke(true); // Notifica que o pulo começou
        }

        // Acumula força de pulo enquanto o botão está pressionado
        if (Input.GetButton("Jump") && isGrounded)
        {
            jumpButtonPressTime += Time.deltaTime;
        }

        // Realiza o pulo quando o botão é solto
        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            float jumpForce = Mathf.Min(initialJumpForce + jumpButtonPressTime * jumpForceIncrementPerSecond, maxJumpForce);
            _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (!isGrounded && _rb.velocity.y < 0)
        {
            OnFalling?.Invoke(true); // Notifica que o jogador está caindo
        }
        else if (isGrounded || _rb.velocity.y >= 0)
        {
            OnFalling?.Invoke(false); // Notifica que o jogador não está caindo
        }
    }

    private void UpdateGroundedStatus(bool grounded)
    {
        if (isGrounded != grounded)
        {
            isGrounded = grounded;
            if (grounded)
            {
                OnJump?.Invoke(false); // Notifica que o jogador aterrissou
            }
        }
    }
}
