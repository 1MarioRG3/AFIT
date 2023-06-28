using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FM : MonoBehaviour
{
    [SerializeField] InputField i_repeticiones,i_peso; 
    [SerializeField] Text t_resultado; 
    float repeticiones,peso,resultado;

    public void CalcularFM(){
        if(i_repeticiones.text == "" || i_peso.text == ""){
            t_resultado.text = "";
        }else{
            repeticiones = (float)System.Convert.ToDouble(i_repeticiones.text);
            peso = (float)System.Convert.ToDouble(i_peso.text);
            resultado=(repeticiones*peso)*0.03f+peso;
            t_resultado.text = resultado.ToString("0.0");
        }
    }
}
