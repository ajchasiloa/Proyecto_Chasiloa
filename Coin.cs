using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip sonidoRecoger;  // Arrastra aquí el sonido en el Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no tiene AudioSource, agregar uno
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (sonidoRecoger != null)
            {
                audioSource.PlayOneShot(sonidoRecoger);
            }

            // Destruir el objeto moneda tras reproducir sonido
            // Usamos un pequeño delay para que se escuche antes de destruir
            Destroy(gameObject, sonidoRecoger != null ? sonidoRecoger.length : 0f);

            // Avisar al GameManager para contar la moneda
            GameManager.Instance.RecogerMoneda();
        }
    }
}
