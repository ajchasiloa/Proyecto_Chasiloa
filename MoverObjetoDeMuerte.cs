using UnityEngine;

public class MoverObjetoDeMuerte : MonoBehaviour
{
    public float velocidad = 3f;
    public float rangoMovimiento = 5f; // cuánto se mueve a izquierda y derecha desde la posición inicial

    // ¿El sprite apunta originalmente a la derecha? (Escala X positiva)
    public bool spriteMiraDerecha = true;

    private int direccion = 1; // 1 para derecha, -1 para izquierda
    private Vector3 escalaOriginal;
    private Vector3 posInicial;

    void Start()
    {
        escalaOriginal = transform.localScale;
        posInicial = transform.position; // Guardamos la posición inicial
        AplicarFlip(direccion);
    }

    void Update()
    {
        // Mover según dirección y velocidad
        transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);

        // Limites relativos a la posición inicial
        if (transform.position.x >= posInicial.x + rangoMovimiento && direccion == 1)
        {
            direccion = -1;
            AplicarFlip(direccion);
        }
        else if (transform.position.x <= posInicial.x - rangoMovimiento && direccion == -1)
        {
            direccion = 1;
            AplicarFlip(direccion);
        }
    }

    private void AplicarFlip(int dir)
    {
        Vector3 escala = escalaOriginal;

        if (spriteMiraDerecha)
        {
            escala.x = Mathf.Abs(escalaOriginal.x) * dir;
        }
        else
        {
            escala.x = Mathf.Abs(escalaOriginal.x) * -dir;
        }

        transform.localScale = escala;
    }
}
