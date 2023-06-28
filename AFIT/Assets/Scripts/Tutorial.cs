using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject O_Tutorial;
    [SerializeField] FuncionesController FC;
    [SerializeField] GameObject[] Paginas;
    [SerializeField] RectTransform Content;
    [SerializeField] float[] PaginasSize;
    int p = 1;
    private void Start() {
        //PlayerPrefs.DeleteAll();
        if(PlayerPrefs.GetInt("Tutorial",1) == 1){
            O_Tutorial.SetActive(true);
            FC.PuedeAbrirLaBarraLateral(false);
        }else{
            O_Tutorial.SetActive(false);
            FC.PuedeAbrirLaBarraLateral(true);
        }
    }
    public void Omitir(){
        FC.PuedeAbrirLaBarraLateral(true);
        O_Tutorial.SetActive(false);
        PlayerPrefs.SetInt("Tutorial",0);
    }
    public void Siguiente(){
        if(p>8){
            O_Tutorial.SetActive(false);
            PlayerPrefs.SetInt("Tutorial",0);
            FC.PuedeAbrirLaBarraLateral(true);
            return;
        }
        foreach(GameObject pagina in Paginas){
            if(pagina == Paginas[p]){
                pagina.SetActive(true);
                Content.sizeDelta = new Vector2(Content.sizeDelta.x,PaginasSize[p]);
                Content.anchoredPosition = new Vector2(Content.anchoredPosition.x,0);
            }else{
                pagina.SetActive(false);
            }
        }
        p++;
    }
}
