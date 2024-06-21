using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigAN : StateMachineBehaviour
{

    public Animator animator; // Referencia al Animator
    private string parameterName = "isTriggered"; // Nombre del par�metro en el Animator

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el objeto que entra tiene la etiqueta "Player" o la etiqueta que prefieras
        {
            animator.SetBool(parameterName, true); // Activa la animaci�n "comer"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el objeto que sale tiene la etiqueta "Player" o la etiqueta que prefieras
        {
            animator.SetBool(parameterName, false); // Desactiva la animaci�n si es necesario
        }
    }
}


