using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PE : MonoBehaviour
{
    [SerializeField] InputField i_FCR,i_FCM; 
    [SerializeField] Text t_resultado; 
    float fcr,fcm,resultado;

    public void CalcularFM(){
        if(i_FCR.text == "" || i_FCM.text == ""){
            t_resultado.text = "";
        }else{
            fcr = (float)System.Convert.ToDouble(i_FCR.text);
            fcm = (float)System.Convert.ToDouble(i_FCM.text);
            resultado=(fcm-fcr)*0.8f+fcr;
            t_resultado.text = resultado.ToString("0.0");
        }
    }
}
