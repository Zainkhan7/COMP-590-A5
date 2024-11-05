using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class SlashMotion : MonoBehaviour
{
    public float slashAngle = 90f; 
    public float slashDuration = 0.5f; 
    public Slider staminaBar;
    float staminaLeft = 100F;
    float staminaRecharge = 5F;
    private float initialRotationZ; 
    private float targetRotationZ; 
    private float elapsedTime = 0f; 
    public bool isSlashing = false; 

    void Start()
    {
        
        initialRotationZ = transform.eulerAngles.z;
        targetRotationZ = initialRotationZ - slashAngle;
    }

    void Update()
    {
         AudioSource swingSound = GetComponent<AudioSource>();
        if (Input.GetMouseButtonDown(0) && !isSlashing)
        {
            swingSound.Play();
            staminaLeft -= 25F;
            print(staminaLeft);
            staminaBar.value = staminaLeft;
            isSlashing = true;
            elapsedTime = 0f; 
        }
        if(staminaLeft>0){

        
            if (isSlashing)
            {
               
                elapsedTime += Time.deltaTime;

                float t = elapsedTime / slashDuration;
                float currentRotationZ = Mathf.Lerp(initialRotationZ, targetRotationZ, t);

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentRotationZ);

                if (elapsedTime >= slashDuration)
                {
                isSlashing = false;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, initialRotationZ);
                }
            }
            
            
        }
        if(staminaLeft<100){
                staminaLeft  += staminaRecharge *Time.deltaTime;
                staminaBar.value = staminaLeft;
            }
    }
}
