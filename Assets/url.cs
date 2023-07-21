using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class url : MonoBehaviour
{
    public string Url;
    public void Abrirpagina(){
        Application.OpenURL(Url);
    }
 
}
