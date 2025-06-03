using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Jugador : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float fuerzaSalto = 10f;
    public float velocidadMovimiento = 5f;

    private int saltosRestantes = 2;

    public AudioClip sonidoSalto;
    public AudioClip sonidoMuerte;
    private AudioSource audioSource;

    private bool estaMuerto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        if (estaMuerto) return;

        transform.rotation = Quaternion.identity;

        float movX = 0f;
        float movY = 0f;

        var keyboard = UnityEngine.InputSystem.Keyboard.current;

        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            movX = -1f;
        else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            movX = 1f;

        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
            movY = 1f;
        else if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
            movY = -1f;

        if (movX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movX < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        Vector2 movimiento = new Vector2(movX, movY).normalized * velocidadMovimiento;

        rb.linearVelocity = new Vector2(movimiento.x, rb.linearVelocity.y);

        if (keyboard.spaceKey.wasPressedThisFrame && saltosRestantes > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            anim.SetBool("estaSaltando", true);
            saltosRestantes--;

            if (sonidoSalto != null)
                audioSource.PlayOneShot(sonidoSalto);
        }

        anim.SetFloat("velocidadX", Mathf.Abs(movX));
        anim.SetFloat("velocidadY", movY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo") || collision.gameObject.CompareTag("corredera"))
        {
            anim.SetBool("estaSaltando", false);
            saltosRestantes = 2;
        }

        if (collision.gameObject.CompareTag("objetoDeMuerte") && !estaMuerto)
        {
            estaMuerto = true;

            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;

            anim.SetTrigger("morir");

            if (sonidoMuerte != null)
                audioSource.PlayOneShot(sonidoMuerte);

            StartCoroutine(CargarEscenaConDelay(0.1f)); // Pequeño delay para que empiece a sonar el sonido
        }
    }

    private IEnumerator CargarEscenaConDelay(float delay)
    {
        // Guardar el nivel actual antes de cargar GameOver
        string nivelActual = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("NivelParaRevivir", nivelActual);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("GameOver");
    }
}
