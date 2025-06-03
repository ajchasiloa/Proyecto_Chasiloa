using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Importante para TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Renderer bg;
    private float velocidad = 2;
    public GameObject col1;
    public List<GameObject> suelo;
    public GameObject generadorDeObjetos;

    public int monedasRecolectadas = 0;
    public int totalMonedas = 3;

    public TextMeshProUGUI textoMonedas; // Cambiado a TextMeshProUGUI

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        generadorDeObjetos.transform.SetParent(null);
        ActualizarTextoMonedas();
    }

    void Update()
    {
        // Fondo y suelo estánticos, no mueven nada

        // Si quieres activar movimiento, descomenta y ajusta aquí:

        /*
        bg.material.mainTextureOffset += new Vector2(0.015f, 0) * velocidad * Time.deltaTime;

        for (int i = 0; i < suelo.Count; i++)
        {
            if (suelo[i].transform.position.x <= -10)
            {
                suelo[i].transform.position = new Vector3(10f, -3, 0);
            }
            suelo[i].transform.position += new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
        }
        */
    }

    public void RecogerMoneda()
    {
        monedasRecolectadas++;
        ActualizarTextoMonedas();

        if (monedasRecolectadas >= totalMonedas)
        {
            SceneManager.LoadScene("Victoria");
        }
    }

    void ActualizarTextoMonedas()
    {
        if (textoMonedas != null)
            textoMonedas.text = "Monedas: " + monedasRecolectadas + "/" + totalMonedas;
    }
}
