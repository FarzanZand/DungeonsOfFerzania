using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject equipmentUI;

    void Start()
    {
        inventoryUI.SetActive(true);
        equipmentUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (equipmentUI.transform.localScale.x == 1 || inventoryUI.transform.localScale.x == 1)
            {
                equipmentUI.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0, 1, 1));
                inventoryUI.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0, 1, 1));
            }
            else
            {
                inventoryUI.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 1));
                equipmentUI.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 1));
            }
        }
    }
}
