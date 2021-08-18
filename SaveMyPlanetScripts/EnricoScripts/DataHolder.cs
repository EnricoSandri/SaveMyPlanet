using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataHolder : MonoBehaviour
{
    [Header("properties")]
    [SerializeField] protected string buildingName;
    [TextArea(15,20)]
    [SerializeField] protected string buildingInfo = "";
    [SerializeField] protected float pollutionLevel = 0.0f;
    [SerializeField] protected int cost = 0;
    protected bool isLastUpgrade;

    //Getters
    public string BuildingName { get { return buildingName; } }
    public string BuildingInfo { get { return buildingInfo; } }
    public float PollutionLevel { get { return pollutionLevel; } }
    public int Cost { get { return cost; } }
    public bool IsLastUpgrade { get { return isLastUpgrade; } }

}
