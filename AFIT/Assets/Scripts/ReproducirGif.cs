using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReproducirGif : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Texture2D texture2D;
    void Start()
    {
        GetComponent<RawImage>().texture = texture2D;
        StartCoroutine(PlayGif());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PlayGif(){
    /*    while(true){
            for(int i = 0; i<texture2D.frameCount;i++){
                texture2D.SetActiveTexture(i);*/
                yield return new WaitForSeconds(/*texture2D.GetDelayTime(i)*/2);
            /*}
        }*/
    }
}
