using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProbabilidadCoral : MonoBehaviour
{
    public Transform pos; //Pos almacena la posici�n de los corales
    public GameObject[] objectsToInstantiate; //Array de los corales que se pueden instanciar
    public float[] probabilities; //Contiene las probabilidades de cada coral

    void Start()
    {
        int n = SelectIndexBasedOnProbability();//Se llama a la funci�n para seleccionar el objeto basado en su probabilidad

        //Se instancia el objeto correspondienta en la posici�n definida
        Instantiate(objectsToInstantiate[n], pos.position, objectsToInstantiate[n].transform.rotation);
    }

    int SelectIndexBasedOnProbability()
    {
        //Calcula el total de probabilidades
        float total = probabilities.Sum();

        //Genera un n�mero aleatorio entre 0 y el total de probabilidades
        float randomPoint = Random.value * total;


        //Recorre el array de probabilidades
        for (int i = 0; i < probabilities.Length; i++)
        {
            //Si el num aleatorio es menor que la prob., devuelve el �ndice de esa prob.
            if (randomPoint < probabilities[i])
            {
                return i;
            }

            //Si no, resta la prob. del numero aleatorio
            else
            {
                randomPoint -= probabilities[i];
            }
        }
        //Esto es por si no selecciona ninguna prob. que devuel el �ltimo �ndice de prob.
        return probabilities.Length - 1;
    }
}




