using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private ParticleSystem fog;
    [SerializeField] private Healthbar heathBarData;
    public int fogSizeMultiplier;

    
    // Update is called once per frame
    void Update()
    {
        ChangeFogAmmount(heathBarData.currentHealth/1000000) ;

    }

    private void ChangeFogAmmount(float amountToApply)
    {
     
        var main = fog.main;
        if(heathBarData.currentHealth >= (heathBarData.maxHealth / 2))
        {
            fog.Play();

            main.startSize = amountToApply * fogSizeMultiplier;
            
            main.startLifetime = amountToApply * fogSizeMultiplier;
        }
        else
        {
            fog.Stop();
        }
    }
}
