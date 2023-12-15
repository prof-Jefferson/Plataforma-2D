using UnityEngine;

public class EnemyFloat : MonoBehaviour
{
    public float horizontalSpeed = 2.0f;
    public float verticalAmplitude = 0.5f;
    public float verticalFrequency = 1.0f;
    public float horizontalDistance = 5.0f; // Distância antes de inverter o movimento

    private Vector2 startPosition;
    private bool movingRight = true;
    private float traveledDistance = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula a nova posição X
        float newX = transform.position.x + (movingRight ? 1 : -1) * horizontalSpeed * Time.deltaTime;
        traveledDistance += horizontalSpeed * Time.deltaTime;

        // Inverte a direção se a distância percorrida ultrapassar o limite
        if (traveledDistance >= horizontalDistance)
        {
            movingRight = !movingRight;
            traveledDistance = 0f;
            startPosition.x = transform.position.x; // Atualiza a posição inicial para a nova direção
        }

        // Movimento vertical oscilatório (senoidal)
        float newY = startPosition.y + Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;

        transform.position = new Vector2(newX, newY);
    }
}
