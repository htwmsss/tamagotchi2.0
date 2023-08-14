using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public float speed;
   
    // Update is called once per frame
    void Update()
    {
        // Obtener la posici�n del toque en la pantalla.
        Touch touch = Input.GetTouch(0);

        // Mover el personaje a la posici�n del toque.
        transform.Translate(touch.position.x * speed, 0, 0);
    }
}
