// PostProcesadoOscuro.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcesadoOscuro : MonoBehaviour
{
    public PostProcessVolume volume;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            volume.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            volume.enabled = false;
        }
    }
}