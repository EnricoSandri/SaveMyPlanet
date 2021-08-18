using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutingAgent : MonoBehaviour
{
    //Variables pollution
    [SerializeField] Healthbar healthbarData;
    public float amount;

    private void Start()
    {
        StartCoroutine(PollutionOverTime());
    }
    
    IEnumerator PollutionOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            healthbarData.ChangeHealth(amount);
        }
    }
}

