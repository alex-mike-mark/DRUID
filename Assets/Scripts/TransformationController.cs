using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationController : MonoBehaviour
{
    public GameObject[] chars;
    private int selectedChar;
    // Start is called before the first frame update
    void Start()
    {
        selectedChar = -1;
        TransformPC();
    }

    // Update is called once per frame
    void Update()
    {
        bool cK = Input.GetButtonDown("Fire3");
        if ( cK ){
            TransformPC();
        }
    }

    void TransformPC(){
        selectedChar = (selectedChar+1)%chars.Length;
        for(int i =0;i<chars.Length;i++){
            if(i==selectedChar){
                Debug.Log("Enabling "+i);
                chars[i].SetActive(true);
            } else {
                Debug.Log("Disabling "+i);
                chars[i].SetActive(false);
            }
        }
    }
}
