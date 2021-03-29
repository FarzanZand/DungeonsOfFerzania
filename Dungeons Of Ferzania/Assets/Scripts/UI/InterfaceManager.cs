using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject equipmentUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.activeInHierarchy)
            {
                inventoryUI.SetActive(false);
                equipmentUI.SetActive(false);
            }
            else
            {
                inventoryUI.SetActive(true);
                equipmentUI.SetActive(true);
            }

        }
    }
}
