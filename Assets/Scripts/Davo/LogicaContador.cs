using UnityEngine;
using TMPro; // Esto le permite al código controlar tus números neón

public class LogicaContador : MonoBehaviour
{
    // Acá vamos a conectar tus números de la pantalla
    public TextMeshProUGUI textoDeLosGolpes; 
    private int cantidadGolpes = 0;

    void Start()
    {
        // Al darle Play, se asegura de que tu cartel arranque en 00
        ActualizarElTexto();
    }

    // Esta es la función mágica que usará tu compañero al golpear la pelota
    public void RegistrarGolpe()
    {
        cantidadGolpes++;
        ActualizarElTexto();
    }

    // Esto hace que el número siempre tenga dos dígitos (00, 01, 02...)
    private void ActualizarElTexto()
    {
        textoDeLosGolpes.text = cantidadGolpes.ToString("D2");
    }
}
