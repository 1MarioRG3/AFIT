using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReproductorAudio : MonoBehaviour
{
    [SerializeField] AudioSource a;
    bool pausado;
    [SerializeField] Slider s,sc;
    [SerializeField] int segundosTotales;
    [SerializeField] Sprite play,pause;
    [SerializeField] GameObject bpause;
    [SerializeField] Text textTiempo;
    string segundostominutos(int segundos){
        int minutos = segundos/60;
        int segundosRestantes = segundos % 60;

        return minutos.ToString("00")+":"+ segundosRestantes.ToString("00");
    }
    void Update(){
        s.value = a.time;
        textTiempo.text = segundostominutos((int) a.time);
        
    }
    void OnEnable(){
        a.Play();
        s.maxValue = segundosTotales;
        sc.maxValue = segundosTotales;
    }
    public void pausaPlay(){
        if(pausado==true){
            a.UnPause();
            bpause.GetComponent<Image>().sprite = pause;
            pausado = false;
        }else{
            a.Pause();
            bpause.GetComponent<Image>().sprite = play;
            pausado = true;
        }  
    }
    public void adelantar(){
        if(a.time+5<=segundosTotales){
            a.time = a.time+5;
            
        }else{
            a.time = segundosTotales;
        }
    }
    public void atrasar(){
        if(a.time-5>=0){
            a.time = a.time-5;
        }else{
            a.time = 0;
        }
    }
    public void cambiarBarra(){
        a.time = sc.value;
    }
    
}
