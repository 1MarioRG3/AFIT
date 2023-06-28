using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YogaTextoController : MonoBehaviour
{
    [SerializeField] RectTransform content;
    RectTransform texto;
    [SerializeField] GameObject[] textos;
    public void AparecerTexto(int indice){
        content.anchoredPosition = new Vector2(0,0);
        foreach(GameObject tx in textos){
            if(textos[indice] == tx){
                tx.SetActive(true);
            }else{
                tx.SetActive(false);
            }
        }
        AjustarTamaño(indice);
    }
    public void AjustarTamaño(int indice){
        texto = textos[indice].GetComponent<RectTransform>();
        content.sizeDelta = new Vector2(content.sizeDelta.x,texto.sizeDelta.y);
    }
}
