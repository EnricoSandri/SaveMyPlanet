using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GetInfo : MonoBehaviour
{
    //Gameobject references
    public GameObject[] structure;
    public GameObject gameCanvas;
    
    //public GameObject buildingError;
    public GameObject upgradeButton;
    public GameObject costTextObj;

    //Canvas text references
    public Text buildingName;
    public Text buildingSpecs;
    public Text buildingCost;
    public Text buildingPollution;
    public Text buildingError;

    //Variables
    private int selectedBuildingCost;
    public bool canvasOn = false;
    bool upgradeButtonBool = true;

    //Managers
    [SerializeField] CurrencyManager currency;
    [SerializeField] AudioManager audio;
    BuildingData buildingData;
    UpgradeManager building;

    void Start()
    {
        gameCanvas.SetActive(canvasOn);
    }

    void Update()
    {
        ShowInfoOnCanvas();
    }

    private void ShowInfoOnCanvas()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return; // checks if is clicking a non Canvas object

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform != null && hit.transform.GetComponent<DataHolder>() != null)
                {

                    canvasOn = true;
                    gameCanvas.SetActive(canvasOn);

                    buildingData = hit.transform.GetComponent<BuildingData>();

                    //set the text in the canvas based on the object selected
                    buildingName.text = buildingData.BuildingName;
                    buildingSpecs.text = buildingData.BuildingInfo;
                    buildingPollution.text = "Pollution produced: " + buildingData.PollutionLevel.ToString() + " Units";
                    buildingCost.text = "Cost to upgrade:  " + buildingData.Cost.ToString() + " Coins";


                    // store a reference of various variables of the object which was clicked, this so you can use them outside the scope of this function
                    building = hit.transform.GetComponentInParent<UpgradeManager>();
                    structure = building.structures;
                    selectedBuildingCost = buildingData.Cost;
                    upgradeButtonBool = buildingData.IsLastUpgrade;
                    CheckIfIsLastUpgrade();

                }
            }
        }
    }

    private void CheckIfIsLastUpgrade()
    {
        if (selectedBuildingCost == 0)
        {
            upgradeButtonBool = false;
            upgradeButton.SetActive(false);
            costTextObj.SetActive(false);
        }

        if (building.currentActiveBuilding < structure.Length - 1)
        {
            upgradeButtonBool = true;
            upgradeButton.SetActive(true);
            costTextObj.SetActive(true);
        }
        else
        {
            upgradeButtonBool = false;
        }
    }

    public void ResetCanvas()
    {
        canvasOn = false;
        gameCanvas.SetActive(canvasOn);
        // buildingError.SetActive(false); // Does it need to be here?? Consider using a coroutine so that the writting closes after certain time.
        buildingError.text = "";
    }


    public void UpgradeStructure()
    {
        if (currency.coins > selectedBuildingCost)
        {

            //Set the current active building to false
            structure[building.currentActiveBuilding].SetActive(false);

            //Change the reference to the next building
            building.currentActiveBuilding++;
            currency.coins -= selectedBuildingCost;

            //check if the refernce count goes beyond the array length, if so set it to to last element
            if (building.currentActiveBuilding >= structure.Length)
            {
                building.currentActiveBuilding = structure.Length - 1;

                //Remove the upgrade button and cost text if reached the last upgrade
                upgradeButtonBool = false;
            }

            if (upgradeButtonBool == false)
            {
                upgradeButton.SetActive(false);
                costTextObj.SetActive(false);
            }

            structure[building.currentActiveBuilding].SetActive(true);

            audio.Play("Upgrade"); 

            //TakeMyMoney();
            gameCanvas.SetActive(false);
        }
        else
        {
            StartCoroutine(ErrorText());
        }


    }

    IEnumerator ErrorText()
    {
        buildingError.text = "PAYMENT DECLINED. INSUFFICIENT FUNDS!";
        yield return new WaitForSeconds(.8f);
        buildingError.text = "";
        yield return new WaitForSeconds(.8f);
        buildingError.text = "PAYMENT DECLINED. INSUFFICIENT FUNDS!";
        yield return new WaitForSeconds(.8f);
        buildingError.text = "";
        yield return new WaitForSeconds(.8f);
        buildingError.text = "PAYMENT DECLINED. INSUFFICIENT FUNDS!";
        yield return new WaitForSeconds(.8f);
        buildingError.text = "";
        
    }



}


