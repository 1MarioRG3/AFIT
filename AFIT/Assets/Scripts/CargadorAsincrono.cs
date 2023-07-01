using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CargadorAsincrono : MonoBehaviour
{
  
   // [SerializeField] Image i;

    float tiempo;
    [SerializeField] float espera;
    Color32 c;
    bool yaCargando,entiempo;
    private void Awake() {
        Application.targetFrameRate = 60;
        
    }
    void Start()
    {
        /*
        if(PlayerPrefs.GetInt("pc",1)==1){
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            //ApplicationChrome.statusBarState = ApplicationChrome.States.Hidden;
            //ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
            
        }else{
            Screen.fullScreenMode = FullScreenMode.Windowed;
            //ApplicationChrome.statusBarState = ApplicationChrome.States.Visible;
            //ApplicationChrome.navigationBarState = ApplicationChrome.States.Visible;
        }*/
    }

    void Update()
    {
        if(yaCargando == false){
            tiempo += Time.deltaTime;
            if(tiempo >= espera){
                yaCargando = true;
                SceneManager.LoadSceneAsync(1,LoadSceneMode.Single);
            }
        }
        
        
        
        
    }
    
}
