using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoObjeto : MonoBehaviour
{
    bool arrastrandose;
    Vector3 posicionInicial,offset;
    RectTransform rt;
    
    public void OnPointerDown(){
        arrastrandose = true; 
        offset = transform.position - Input.mousePosition;
    }
    public void GuardarPosicion() {
        if(rt == null){
            rt = this.GetComponent<RectTransform>();
            posicionInicial = rt.position;
        }
        
    }
    public void OnDrag(){
        if(arrastrandose){
            transform.position = Input.mousePosition + offset;
        }
    }
    public void OnPointerUp(){
        arrastrandose = false;
        //transform.position = posicionInicial;
    }
    public void VolverAPosicionInicial(){
        transform.position = posicionInicial;
    }
}
