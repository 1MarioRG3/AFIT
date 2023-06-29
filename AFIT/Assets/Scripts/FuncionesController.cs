using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuncionesController : MonoBehaviour
{
    public bool BarraLateralAbierta,ZonaAbrirBarraLateral;
    bool AbrirBarraLateralDeslizandoDedo=true;
    [SerializeField] GameObject[] botones;
    [SerializeField] Animator BarraLateralAnimator;
    [SerializeField] Color c_activo,c_disable;
    [SerializeField] GameObject Datos,Info,Content,Flechita,Limite;
    [SerializeField] Animator A_BarraLateral;
    bool infoAbierta = false;
    [SerializeField] float DistanciaMinima;
    
    Vector2 dedoInicio;
    [SerializeField] Toggle tgP,tgS,tgM;
    [SerializeField] float tiempoEntreFotos;
    [SerializeField] Image BarraLateralArriba;
    [SerializeField] Sprite[] fotos;
    float contador;
    int i;
    private void Start() {
        
        if(PlayerPrefs.GetInt("pc",0)==1){
            tgP.isOn = true;
            
        }else{
            tgP.isOn = false;
            
        }
        if(PlayerPrefs.GetInt("musica",1)==1){
            tgM.isOn = true;
            
        }else{
            tgM.isOn = false;
            
        }
        if(PlayerPrefs.GetInt("sonido",1)==1){
            tgS.isOn = true;
            
        }else{
            tgS.isOn = false;
            
        }
        PantallaCompleta();
    }
    
    private void Update() {
        #region RETROCEDER CON ESCAPE
        GameObject Atras = GameObject.FindGameObjectWithTag("ATRAS");
        if(Atras != null && Input.GetKeyDown(KeyCode.Escape)){
            Atras.GetComponent<Button>().onClick.Invoke();
        }
        #endregion

        
        if(AbrirBarraLateralDeslizandoDedo){
            if(Input.touchCount > 0 ){
                //ZonaAbrirBarraLateral = Input.GetTouch(0).position.x<Limite.GetComponent<RectTransform>().position.x?true:false;
            }
            
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
                dedoInicio = Input.GetTouch(0).position;
            }
        
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended&&dedoInicio.x<Limite.GetComponent<RectTransform>().position.x){
                Vector2 dedoFinal = Input.GetTouch(0).position;
                float DeltaX = dedoFinal.x - dedoInicio.x;
                float DeltaY = dedoFinal.y - dedoInicio.y;
                if(Mathf.Abs(DeltaX)>Mathf.Abs(DeltaY)){
                    if(DeltaX>DistanciaMinima){
                        A_BarraLateral.Play("MenuAmburguesaSaliendo");
                        
                    }else if(DeltaX<DistanciaMinima*-1){
                    
                        A_BarraLateral.Play("MenuAmburguesaOcultandose");
                        
                    }
                }
                dedoInicio = dedoFinal;
            }
        }
        if(BarraLateralAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.MenuAmburguesaSaliendo")){
            BarraLateralAbierta = true;
        }else if (BarraLateralAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.MenuAmburguesaOcultandose")){
            BarraLateralAbierta = false;
        }
        if(BarraLateralAbierta){
            CambiarImagenes();
        }
        
       
        
    }
    public void SeleccionarBotonBarraInferior(GameObject boton){
        Image i = boton.GetComponent<Image>();
        foreach(GameObject b in botones){
            
            if(b == boton){
                b.GetComponent<Image>().color = c_activo;
            }else{
                b.GetComponent<Image>().color = c_disable;
            }
        }

    }
    public void CambiarImagenes(){
        if(contador<tiempoEntreFotos){
            contador += Time.deltaTime;
        }else{
            BarraLateralArriba.sprite = fotos[i];
            if(i>=fotos.Length-1){
                i = 0;
            }else{
                i++;
            }
            contador = 0;
        }
        
    }
    public void hipervinculo(string vinculo){
        Application.OpenURL(vinculo);
    }
    
    public void AbrirInfo(){
        RectTransform rtd= Datos.GetComponent<RectTransform>();
        RectTransform rti= Info.GetComponent<RectTransform>();
        RectTransform rtf= Flechita.GetComponent<RectTransform>();
        RectTransform rtc= Content.GetComponent<RectTransform>();
        if(infoAbierta){
            rtd.sizeDelta =new Vector2(rtd.sizeDelta.x,rtd.sizeDelta.y-rti.sizeDelta.y);
            rtc.sizeDelta =new Vector2(rtc.sizeDelta.x,rtc.sizeDelta.y-rti.sizeDelta.y);
            rtf.rotation = Quaternion.Euler(0,0,270);
            Info.SetActive(false);
            infoAbierta = false;
        }else{
            rtd.sizeDelta =new Vector2(rtd.sizeDelta.x,rtd.sizeDelta.y+rti.sizeDelta.y);
            rtc.sizeDelta =new Vector2(rtc.sizeDelta.x,rtc.sizeDelta.y+rti.sizeDelta.y);
            rtf.rotation = Quaternion.Euler(0,0,90);
            Info.SetActive(true);
            infoAbierta = true;
        }
    }
    public void PantallaCompleta(){
        Screen.fullScreenMode = tgP.isOn?FullScreenMode.ExclusiveFullScreen:FullScreenMode.Windowed;
        Screen.fullScreen = tgP.isOn?true:false;
        ApplicationChrome.statusBarState = tgP.isOn?ApplicationChrome.States.Hidden:ApplicationChrome.States.Visible;
        //ApplicationChrome.statusBarColor= 0xFF3B3B40;
        PlayerPrefs.SetInt("pc",tgP.isOn?1:0);
       
    }
    public void PuedeAbrirLaBarraLateral(bool siOno){
        AbrirBarraLateralDeslizandoDedo = siOno;
    }
    public void EnZonaParaAbrirBarraLateral(bool siOno){
        ZonaAbrirBarraLateral = siOno;
    }

}
//POR SI EL UI NO ES DETECTADO POR EL INTELLYSENSE
/*<Reference Include="UnityEngine.UI">
 <HintPath>Library/ScriptAssemblies/UnityEngine.UI.dll</HintPath>
 </Reference> */