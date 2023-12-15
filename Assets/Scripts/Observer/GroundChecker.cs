using UnityEngine;
using System; // Para usar eventos

public class GroundChecker : MonoBehaviour
{
    public event Action<bool> OnGroundedChanged; // Evento para quando o estado de estar no chão mudar
    public LayerMask groundLayer; // Defina isso no Unity Inspector
    public float groundCheckDistance = 0.2f; // Distância para checar o chão
    private bool isGrounded;

    void Update()
    {
        bool wasGrounded = isGrounded;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;

        // Desenha uma linha no editor para visualizar o raycast
        Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, Color.red);

        if (wasGrounded != isGrounded)
        {
            OnGroundedChanged?.Invoke(isGrounded);
        }
    }
}
