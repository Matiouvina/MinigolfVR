using UnityEngine;
using System.Collections; // OBLIGATORIO para usar los segundos de espera

public class DetectorHoyo : MonoBehaviour
{
    // Arrastrás acá tu pantalla de Ganaste desde la jerarquía
    public GameObject pantallaGanaste; 

    // Al detectar que la pelota entra al hoyo
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si lo que entró al hoyo es la pelota de golf
        if (other.CompareTag("Player") || other.name.ToLower().Contains("pelota"))
        {
            // Arranca la cuenta regresiva en segundo plano
            StartCoroutine(MostrarCartelConRetraso());
        }
    }

    // Esta es la función mágica que espera los 3 segundos
    IEnumerator MostrarCartelConRetraso()
    {
        Debug.Log("¡Pelota embocada! Esperando 3 segundos...");
        
        // El código se frena acá por 3 segundos exactos
        yield return new WaitForSeconds(3f); 

        // Pasados los 3 segundos, prende tu cartel neón
        if (pantallaGanaste != null)
        {
            pantallaGanaste.SetActive(true);
            Debug.Log("¡Cartel de Ganaste activado!");
        }
    }
}
