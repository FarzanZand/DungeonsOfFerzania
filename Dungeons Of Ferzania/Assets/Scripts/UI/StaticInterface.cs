using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StaticInterface : UserInterface
{
    public GameObject[] slots;

    public override void CreateSlots()
    {   

        // Create a new dictionary of our items. Loop through all database equipment.
        // Create an obj linked to our Array of Gameobjects
        // Take those slotPrefabs in the array and link to the same slots in the database

        // For deciding what goes where: We have five slotPrefabs in EquipmentScreen. Order defines element nr
        // In the player equipment scriptable object, each element decides what can and can't be there.
        // What types there are is defined in enum ItemType from ItemObject.cs

        // in element nr, select allowed items and choose which type is allowed there. 

        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = slots[i];

            // All these functions will be added to added to the inv-prefab, which are buttons. 
            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            slotsOnInterface.Add(obj, inventory.Container.Items[i]);
        }
    }
}
