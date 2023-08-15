using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator;
    public Button eatButton;
    private bool eatButtonPressed = false;
    private float timeSinceLastButtonPress = 0f;
    private const float angryThreshold = 30f; // 30 seconds

    private void Start()
    {
        // Iniciar en el estado "Idle"
        animator.SetTrigger("Idle");

        // Agregar el evento para el bot�n "Eat"
        if (eatButton != null)
        {
            eatButton.onClick.AddListener(EatButtonPressed);
        }
        else
        {
            Debug.LogError("Eat button reference not assigned.");
        }
    }

    private void EatButtonPressed()
    {
        // Cambiar a la animaci�n "Eat"
        animator.SetTrigger("Eat");
        eatButtonPressed = true;
    }

    private void Update()
    {
        // Incrementar el contador de tiempo si el bot�n no ha sido presionado
        if (!eatButtonPressed)
        {
            timeSinceLastButtonPress += Time.deltaTime;

            // Cambiar a la animaci�n "Angry" despu�s de 30 segundos
            if (timeSinceLastButtonPress >= angryThreshold)
            {
                animator.SetTrigger("Angry");
                timeSinceLastButtonPress = 0f;
            }
        }

        // Cambiar a la animaci�n "Happy" desde "Eat"
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Eat"))
        {
            if (eatButtonPressed)
            {
                animator.SetTrigger("Happy");
                eatButtonPressed = false;
            }
        }

        // Cambiar a la animaci�n "Idle" desde "Happy"
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Happy"))
        {
            // Puedes agregar un tiempo de espera aqu� si es necesario
            animator.SetTrigger("Idle");
        }
    }
}
