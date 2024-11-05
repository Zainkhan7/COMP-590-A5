using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Extension : MonoBehaviour
{
    public GameObject blade;
    float extenstionSpeed = 0.1F;
    bool isOn = true;
    float minScalingValue = 0.0F;
    float maxScalingValue = 0;
    float interpolationValue = 0;
    float saberScale = 0;
    float x= 0;
    float z = 0;


    // Start is called before the first frame update
    void Start()
    {   
    x= transform.localScale.x;
    z = transform.localScale.z;
    maxScalingValue = transform.localScale.y;
    saberScale = maxScalingValue;
    interpolationValue = maxScalingValue/extenstionSpeed;
    isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            interpolationValue = isOn ? -Mathf.Abs(interpolationValue):
                                        Mathf.Abs(interpolationValue);
        }
        saberScale += interpolationValue+ Time.deltaTime;
        saberScale = Mathf.Clamp(saberScale,minScalingValue,maxScalingValue);
        transform.localScale = new Vector3(x,saberScale,z);
        isOn = saberScale>0;

        if(isOn && !blade.activeSelf){
            blade.SetActive(true);
        }
        else if(!isOn && blade.activeSelf){
            blade.SetActive(false);
        }
        
    }

}
