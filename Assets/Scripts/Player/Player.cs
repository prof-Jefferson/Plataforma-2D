using UnityEngine;

public class Player : MonoBehaviour
{
	private int health = 100; // Saúde do jogador

	void Start()
	{
		Enemy[] enemies = FindObjectsOfType<Enemy>(); // Encontra todos os inimigos
		foreach (Enemy enemy in enemies)
		{
			enemy.OnPlayerHit += HandlePlayerHit; // Se inscreve no evento de cada inimigo
		}
	}

	private void HandlePlayerHit()
	{
		health -= 50; // Reduz a saúde
		if (health <= 0)
		{
			Debug.Log("Player Morreu.");
			// Lógica para quando a saúde do jogador chega a zero
		}
	}

	void OnDestroy()
	{
		Enemy[] enemies = FindObjectsOfType<Enemy>();
		foreach (Enemy enemy in enemies)
		{
			enemy.OnPlayerHit -= HandlePlayerHit; // Desinscreve-se para evitar vazamentos de memória
		}
	}
}
