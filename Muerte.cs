using UnityEngine;
using System.Collections;

public class Muerte : MonoBehaviour
{
    public GameObject[] objetosDeMuerte;
    public float distanciaEntrePiedras = 5f;
    public Transform objetoMovible;

    private float posicionUltimaPiedraX;

    void Start()
    {
        posicionUltimaPiedraX = objetoMovible.position.x;
    }

    void Update()
    {
        if (Mathf.Abs(objetoMovible.position.x - posicionUltimaPiedraX) >= distanciaEntrePiedras)
        {
            int cantidadPiedras = Random.Range(1, 4); // Genera entre 1 y 3 piedras
            GenerarObjetos(cantidadPiedras);
            posicionUltimaPiedraX = objetoMovible.position.x;
        }
    }

    private void GenerarObjetos(int cantidad)
    {
        float x = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 1f;
        float yBase = -2f;  // Base Y fija

        for (int i = 0; i < cantidad; i++)
        {
            // Espaciado vertical entre piedras para que no se monten
            float y = yBase + i * 0.8f;

            GameObject objetoSeleccionado = objetosDeMuerte[Random.Range(0, objetosDeMuerte.Length)];
            GameObject obj = Instantiate(objetoSeleccionado, new Vector3(x, y, 0f), Quaternion.identity);
            obj.transform.SetParent(null);
            obj.AddComponent<MoverObjetoDeMuerte>();
        }
    }
}
