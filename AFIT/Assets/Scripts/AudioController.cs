using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField]AudioSource S_boton1,S_boton2,S_Musica;
    bool Sonidos = true;
    [SerializeField]Toggle tgS,tgM;
    
    private void Start() {
        
        if(PlayerPrefs.GetInt("musica",1)==1){
            S_Musica.Play();
        }else{
            S_Musica.Stop();
        }
         if(PlayerPrefs.GetInt("sonido",1)==1){
            Sonidos = true;
        }else{
            Sonidos = false;
        }     
    }
    public void Sonido(){
        if(tgS.isOn){
            Sonidos = true;
            PlayerPrefs.SetInt("sonido",1);
        }else{
            Sonidos = false;
            PlayerPrefs.SetInt("sonido",0);
        }
    }
    public void Musica(){
        if(tgM.isOn){
            S_Musica.Play();
            PlayerPrefs.SetInt("musica",1);
        }else{
            S_Musica.Stop();
            PlayerPrefs.SetInt("musica",0);
        }
        
    }
    public void ReproducirSonidoBoton1(){
        if(Sonidos == true){
            S_boton1.Play();
        }
    }
    public void ReproducirSonidoBoton2(){
        if(Sonidos == true){
            S_boton2.Play();
        }
    }
    public void PausarMusica(bool pausar){
        if(pausar){
            S_Musica.Pause();
        }else{
            S_Musica.UnPause();
        }
    }
    
}
