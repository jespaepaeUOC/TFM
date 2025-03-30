using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GrassManager : MonoBehaviour
{
    public Transform player;                // Asigna al jugador en el inspector
    public float activationDistance = 1.5f; // Distancia de activación
    public float windSpeed = 10f;           // Velocidad de movimiento
    public float windStrength = 0.1f;       // Intensidad del movimiento

    private Vector3 originalPosition;
    private float wiggleTime;

    void Start()
    {
        originalPosition = transform.localPosition;
        wiggleTime = Random.Range(0f, 100f); // Para variar el movimiento entre hierbas
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(player.position, transform.position);

        if (distance < activationDistance)
        {
            wiggleTime += Time.deltaTime * windSpeed;
            float offset = Mathf.Sin(wiggleTime) * windStrength;
            transform.localPosition = originalPosition + new Vector3(offset, 0f, 0f);
        }
        else
        {
            // Suavemente volver a la posición original
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * 5f);
        }
    }
}
