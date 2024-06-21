using System.Collections;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField] private Transform fbxTransform;
    private const float angleMinus180 = -180f;
    private const float angle90 = 90f;
    

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            fbxTransform.rotation = Quaternion.Euler(0, angleMinus180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            fbxTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
/*
   

    public IEnumerator Rotate(int toRot)
    {
        yield return new WaitForSeconds(1.2f);
        switch (toRot)
        {
            case 0:
                fbxTransform.rotation = Quaternion.Euler(0, angleMinus180, 0);
                break;
            case 1:
                fbxTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;

        }
    }*/
}