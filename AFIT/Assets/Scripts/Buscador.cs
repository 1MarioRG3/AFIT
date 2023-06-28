using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Buscador : MonoBehaviour
{
    //[SerializeField]InputField inp;
    [SerializeField]RectTransform Content;
    Text[] textos;
    [SerializeField] TMP_InputField inp;
    string v;
    void Start(){
        textos = gameObject.GetComponentsInChildren<Text>(true).Where(t=>t.CompareTag("indexado")).ToArray();
        BuscarTexto();
    }
    void Update(){
    }
    public void BuscarTexto(){
        string textobuscado = inp.text;
        foreach(Text texto in textos){
            if(texto.text.ToUpper().Contains(textobuscado.ToUpper())){
                if(texto.transform.parent.gameObject.activeInHierarchy == false){
                    RectTransform rt = texto.transform.parent.GetComponent<RectTransform>();
                    Content.sizeDelta = new Vector2(Content.sizeDelta.x,Content.sizeDelta.y + rt.sizeDelta.y);
                }
                texto.transform.parent.gameObject.SetActive(true);
                
                }else{
                if(texto.transform.parent.gameObject.activeInHierarchy == true){
                    RectTransform rt = texto.transform.parent.GetComponent<RectTransform>();
                    Content.sizeDelta = new Vector2(Content.sizeDelta.x,Content.sizeDelta.y - rt.sizeDelta.y);
                }
                texto.transform.parent.gameObject.SetActive(false);
               
            }
        }
    }
}
/*<Reference Include="Unity.TextMeshPro">
 <HintPath>C:\Program Files\Unity\Unity 2019\Editor\Data\Resources\PackageManager\ProjectTemplates\libcache\com.unity.template.universal-7.1.8\ScriptAssemblies\Unity.TextMeshPro.dll</HintPath>
 </Reference>*/