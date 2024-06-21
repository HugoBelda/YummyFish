using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigAN : StateMachineBehaviour
{

    public Animator animator; // Referencia al Animator
    private string parameterName = "isTriggered"; // Nombre del parámetro en el Animator

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el objeto que entra tiene la etiqueta "Player" o la etiqueta que prefieras
        {
            animator.SetBool(parameterName, true); // Activa la animación "comer"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el objeto que sale tiene la etiqueta "Player" o la etiqueta que prefieras
        {
            animator.SetBool(parameterName, false); // Desactiva la animación si es necesario
        }
    }
}


