using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoObjeto : MonoBehaviour
{
    bool arrastrandose;
    Vector3 posicionInicial;
    RectTransform rt;
    
    public void OnPointerDown(){
        arrastrandose = true;
        
    }
    public void GuardarPosicion() {
        if(rt == null){
            rt = this.GetComponent<RectTransform>();
            posicionInicial = rt.position;
        }
        
    }
    public void OnDrag(){
        if(arrastrandose){
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
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
