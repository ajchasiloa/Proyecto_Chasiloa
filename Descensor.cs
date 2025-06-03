using UnityEngine;

public class Descensor : MonoBehaviour
{
    public float distancia = 2f;      // Cuánto se mueve hacia abajo desde la posición inicial
    public float velocidad = 2f;      // Velocidad del movimiento

    private Vector3 posicionInicial;
    private Vector3 posicionObjetivo;
    private bool bajando = true;

    void Start()
    {
        posicionInicial = transform.position;
        posicionObjetivo = posicionInicial - new Vector3(0, distancia, 0);
    }

    void Update()
    {
        if (bajando)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);
            if (Vector3.Distance(transform.position, posicionObjetivo) < 0.01f)
                bajando = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
            if (Vector3.Distance(transform.position, posicionInicial) < 0.01f)
                bajando = true;
        }
    }
}
