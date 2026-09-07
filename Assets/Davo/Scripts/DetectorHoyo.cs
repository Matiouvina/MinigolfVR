using UnityEngine;
using System.Collections;
using TMPro; // OBLIGATORIO para poder manejar tus textos de TextMeshPro

public class DetectorHoyo : MonoBehaviour
{
    [Header("Pantalla de Victoria")]
    public GameObject pantallaGanaste; 
    public TextMeshProUGUI golpesFinalText; // El texto vacío en tu cartel de Ganaste
    public TextMeshProUGUI tiempoFinalText; // El reloj vacío en tu cartel de Ganaste

    [Header("Contadores de Arriba a Borrar")]
    public GameObject contadorGolpesArriba;
    public GameObject contadorTiempoArriba;

    [Header("Textos Vivos de Arriba (De donde sacamos los puntos)")]
    public TextMeshProUGUI golpesDeArribaText; // El GolpesText original
    public TextMeshProUGUI tiempoDeArribaText; // El TiempoText original

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.name.ToLower().Contains("pelota"))
        {
            StartCoroutine(MostrarCartelConRetraso());
        }
    }

    IEnumerator MostrarCartelConRetraso()
    {
        Debug.Log("¡Pelota embocada! Esperando 3 segundos...");
        yield return new WaitForSeconds(3f); 

        // TRASPASO DE DATOS: Copiamos lo que dicen los textos de arriba en los textos del cartel
        if (golpesFinalText != null && golpesDeArribaText != null)
        {
            golpesFinalText.text = golpesDeArribaText.text;
        }

        if (tiempoFinalText != null && tiempoDeArribaText != null)
        {
            tiempoFinalText.text = tiempoDeArribaText.text;
        }

        // 1. Apaga los marcadores de arriba (Limpia la pantalla)
        if (contadorGolpesArriba != null) contadorGolpesArriba.SetActive(false);
        if (contadorTiempoArriba != null) contadorTiempoArriba.SetActive(false);

        // 2. Prende el cartel de Ganaste solo en el centro con tus resultados puestos
        if (pantallaGanaste != null)
        {
            pantallaGanaste.SetActive(true);
            Debug.Log("¡Resultados estampados y cartel de Ganaste activado!");
        }
    }
}
