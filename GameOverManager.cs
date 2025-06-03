using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameOverManager : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            // Leer el nivel guardado para revivir
            string nivelParaRevivir = PlayerPrefs.GetString("NivelParaRevivir", "Proyecto_final");
            // Si no existe, por defecto carga "Proyecto_final"

            SceneManager.LoadScene(nivelParaRevivir);
        }
    }
}
