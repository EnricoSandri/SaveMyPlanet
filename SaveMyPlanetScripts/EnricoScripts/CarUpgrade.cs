using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUpgrade : MonoBehaviour
{

    public GameObject[] Cars;
    public UpgradeManager petrolStation;
    private int carIndex;
   
   
    void Update()
    {
        UpgradeCars();
    }

    private void UpgradeCars()
    {
        foreach (GameObject car in Cars)
        {
            GameObject oldCar = car.gameObject.transform.GetChild(0).gameObject;
            GameObject NewCar = car.gameObject.transform.GetChild(1).gameObject;

            NewCar.SetActive(false);
           
            if (petrolStation.currentActiveBuilding > carIndex)
            {
                oldCar.SetActive(false);
                NewCar.SetActive(true);
            }     
        } 
    }
}
