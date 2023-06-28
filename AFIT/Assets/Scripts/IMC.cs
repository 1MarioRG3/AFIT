using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMC : MonoBehaviour
{
    [SerializeField] InputField peso,altura;
    
    [SerializeField] Text resultadoN,resultadoC;
    [SerializeField] Color MuyMal,Normal,Mal;
    float pesof,alturaf,resultadof;
    public void CalcularIMC(){
        if(peso.text == "" || altura.text == ""){
            resultadoN.text = "";
            resultadoC.text = "";
        }else{
            pesof = (float)System.Convert.ToDouble(peso.text);
            alturaf = (float)System.Convert.ToDouble(altura.text);
            alturaf /= 100;
            resultadof = pesof / (alturaf*alturaf);
            
            if(resultadof < 18.5f){
                resultadoC.color = MuyMal;
                resultadoN.color = MuyMal;
                resultadoC.text = "BAJO PESO";
            }else if(resultadof > 18.5 && resultadof <24.9){
                resultadoC.color = Normal;
                resultadoN.color = Normal;
                resultadoC.text = "NORMAL";
            }else if(resultadof > 25.0 && resultadof <29.9){
                resultadoC.color = Mal;
                resultadoN.color = Mal;
                resultadoC.text = "SOBREPESO";
            }else if(resultadof > 30.0){
                resultadoC.color = MuyMal;
                resultadoN.color = MuyMal;
                resultadoC.text = "OBESIDAD";
            }

            resultadoN.text = resultadof.ToString("0.0");


        }
    }
}
