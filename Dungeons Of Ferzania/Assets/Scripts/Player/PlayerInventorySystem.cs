using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventorySystem : MonoBehaviour
{

    //public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;
    public InventoryObject equipment;


    public void OnTriggerEnter2D(Collider2D other) {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {
            Item _item = new Item(item.item);
            if(inventory.AddItem(_item, 1))
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
            equipment.Save();
            Debug.Log("Save");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.Load();
            equipment.Load();
            Debug.Log("Load");
        }
    }

    private void OnApplicationQuit() {
        inventory.Container.Clear();
        equipment.Container.Clear();
    }
}
  