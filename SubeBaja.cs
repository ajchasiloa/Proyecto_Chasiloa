using UnityEngine;

public class SubeBaja : MonoBehaviour
{
    public float distancia = 2f;      // Cuánto sube desde la posición inicial
    public float velocidad = 2f;      // Velocidad del movimiento

    private Vector3 posicionInicial;
    private Vector3 puntoArriba;
    private bool subiendo = true;

    void Start()
    {
        posicionInicial = transform.position;             // Guarda la posición original
        puntoArriba = posicionInicial + Vector3.up * distancia;  // Calcula el punto arriba
    }

    void Update()
    {
        if (subiendo)
        {
            // Mover hacia arriba desde la posición inicial
            transform.position = Vector3.MoveTowards(transform.position, puntoArriba, velocidad * Time.deltaTime);
            if (Vector3.Distance(transform.position, puntoArriba) < 0.01f)
                subiendo = false;  // Cambia a bajar
        }
        else
        {
            // Mover hacia abajo hacia la posición inicial
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
            if (Vector3.Distance(transform.position, posicionInicial) < 0.01f)
                subiendo = true;   // Cambia a subir
        }
    }
}
