using System.Collections;
using UnityEngine;

public class AnimationCTR : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterRotation rotation;
    private bool isFacingLeft = false;
    private bool isFacingRight = false;
    private bool isNadando = false;
    private bool isRotating = false;
    private bool isHitPlaying = false;
    [SerializeField][Range(1f, 100f)] private float rotationSpeed = 25f;

    private void Start()
    {
        rotation = GetComponentInChildren<CharacterRotation>();
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
        }
        isFacingRight = true;
        PlayIdle();
    }

    private void Update()
    {
        if (animator != null && !isRotating)
        {
            HandleInputForAnimations();
        }
    }

    private void HandleInputForAnimations()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
                        || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        if (isHitPlaying) // Si está reproduciendo la animación "hit", no procesar ninguna otra entrada
            return;

        if (isMoving)
        {
            PlayNadar();
        }
        else
        {
            StopNadar();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateRight();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(PlayHit());
        }

        if (!isMoving && !Input.anyKey)
        {
            PlayIdle();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllAnimations();
        }
    }

    private void SetAnimationState(string state)
    {
        animator.SetBool("isIdle", state == "isIdle");
        animator.SetBool("isNadar", state == "isNadar");
    }

    public void PlayIdle()
    {
        if (!isFacingLeft && !isFacingRight && !isNadando)
        {
            Debug.Log("idle");
            SetAnimationState("isIdle");
        }
    }

    public void PlayNadar()
    {
        if (!isNadando)
        {
            Debug.Log("nadar");
            SetAnimationState("isNadar");
            isNadando = true;
        }
    }

    public IEnumerator PlayComer()
    {
        Debug.Log("comer");
        //hace la animacion de comer una vez
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("isComer");
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isComer", false);
    }

    public IEnumerator PlayHit()
    {
        if (!isHitPlaying)
        {
            isHitPlaying = true;
            Debug.Log("hit");
            // Inicia la animación de "hit"
            animator.SetTrigger("isHit");
            // Espera un segundo
            yield return new WaitForSeconds(1f);
            animator.SetBool("isHit", false);
            isHitPlaying = false; // Restablecer la bandera después de un segundo
        }
    }


    public void StopNadar()
    {
        if (isNadando)
        {
            Debug.Log("stop nadar");
            animator.SetBool("isNadar", false);
            isNadando = false;
        }
    }

    public void RotateLeft()
    {
        if (!isFacingLeft)
        {
            Debug.Log("rotate left");
            StopAllAnimations();
            StartCoroutine(RotateOverTime(transform.GetChild(0), 180, rotationSpeed));
            isFacingLeft = true;
            isFacingRight = false;
        }
    }

    public void RotateRight()
    {
        if (!isFacingRight)
        {
            Debug.Log("rotate right");
            StopAllAnimations();
            StartCoroutine(RotateOverTime(transform.GetChild(0), -180, rotationSpeed));
            isFacingRight = true;
            isFacingLeft = false;
        }
    }

    private IEnumerator RotateOverTime(Transform target, float angle, float rotationSpeed)
    {
        isRotating = true;
        float startRotation = target.eulerAngles.y;
        float endRotation = startRotation + angle;

        // Calcular la duración basada en la velocidad de rotación
        float duration = Mathf.Abs(angle) / rotationSpeed * 0.1f; // Multiplicamos por un factor arbitrario

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float yRotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / duration) % 360.0f;
            target.eulerAngles = new Vector3(target.eulerAngles.x, yRotation, target.eulerAngles.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        target.eulerAngles = new Vector3(target.eulerAngles.x, endRotation % 360.0f, target.eulerAngles.z);
        isRotating = false;
        PlayNadar(); // Continuar nadando después de la rotación
    }

    public void StopAllAnimations()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isNadar", false);
        isFacingLeft = false;
        isFacingRight = false;
        isNadando = false;
    }

    private void SubscribeAnimationEndEvent()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            AnimationEvent animationEvent = new AnimationEvent();
            animationEvent.time = clip.length;
            animationEvent.functionName = "OnAnimationEnd";
            clip.AddEvent(animationEvent);
        }
    }

    private void OnAnimationEnd()
    {
        // Este método puede permanecer vacío o manejar cualquier lógica específica después de que la animación haya terminado
    }
}
