using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MensajeControlador : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            // Cargar la escena del siguiente nivel (ahora GameOver como placeholder)
            SceneManager.LoadScene("NIVEL2");
        }
        else if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            // Cargar la escena de GameOver
            SceneManager.LoadScene("GameOver");
        }
    }
}
