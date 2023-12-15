using UnityEngine;
using System; // Necessário para usar Action

public class Enemy : MonoBehaviour
{
    public event Action OnPlayerHit; // Evento disparado quando o inimigo atinge o jogador

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica se colidiu com o jogador
        {
            OnPlayerHit?.Invoke(); // Dispara o evento
        }
    }
}
