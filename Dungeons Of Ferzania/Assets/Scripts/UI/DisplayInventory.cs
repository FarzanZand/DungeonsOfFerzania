// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;
// using UnityEngine.Events;

// public class DisplayInventory : MonoBehaviour
// {


//     public InventoryObject inventory;
//     Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

//     void Start()
//     {
//         CreateSlots();
//     }

//     void Update()
//     {
//         UpdateSlots();
//     }

//     public void UpdateSlots()
//     {
//         foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
//         {
//             if (_slot.Value.ID >= 0)
//             {
//                 _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].uiDisplay;
//                 _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
//                 _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
//             }
//             else
//             {
//                 _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
//                 _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
//                 _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
//             }
//         }
//     }

//     public void CreateSlots()
//     {
//         itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
//         for (int i = 0; i < inventory.Container.Items.Length; i++)
//         {
//             var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
//             obj.GetComponentInChildren<RectTransform>().localPosition = GetPosition(i);

//             // All these functions will be added to added buttons
//             AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
//             AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
//             AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
//             AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
//             AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });


//             itemsDisplayed.Add(obj, inventory.Container.Items[i]);
//         }
//     }

//     private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
//     {
//         EventTrigger trigger = obj.GetComponent<EventTrigger>();
//         var eventTrigger = new EventTrigger.Entry();
//         eventTrigger.eventID = type;
//         eventTrigger.callback.AddListener(action);
//         trigger.triggers.Add(eventTrigger);
//     }

//     // Making sure that if mouse over inventory slot, mouseItem obj is set to that slot. 
//     public void OnEnter(GameObject obj)
//     {
//         mouseItem.hoverObj = obj;
//         if(itemsDisplayed.ContainsKey(obj))
//             mouseItem.hoverItem = itemsDisplayed[obj];
//     }
//     public void OnExit(GameObject obj)
//     {
//         mouseItem.hoverObj = null;
//         mouseItem.hoverItem = null;
//     }
//     public void OnDragStart(GameObject obj)
//     {
//         var mouseObject = new GameObject();
//         var rt = mouseObject.AddComponent<RectTransform>();
//         rt.sizeDelta = new Vector2(75, 75); // Set as same size as inventory icon
//         mouseObject.transform.SetParent(transform.parent);
//         if(itemsDisplayed[obj].ID >= 0)
//         {
//             var img = mouseObject.AddComponent<Image>();
//             img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
//             img.raycastTarget = false; // So it isn't in the way of our mouse
//         }

//         mouseItem.obj = mouseObject;
//         mouseItem.item = itemsDisplayed[obj];
//     }
//     public void OnDragEnd(GameObject obj)
//     {   
//         // Swap items
//         if(mouseItem.hoverObj)
//         {
//             inventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[mouseItem.hoverObj]);
//         }
//         else
//         {
//             inventory.RemoveItem(itemsDisplayed[obj].item);
//         }

//         Destroy(mouseItem.obj);
//         mouseItem.item = null; 
//     }
//     public void OnDrag(GameObject obj)
//     {
//         if(mouseItem.obj != null)
//         {
//             mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
//         }
//     }

//     public Vector3 GetPosition(int i)
//     {
//         return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumns)), yStart + (-ySpaceBetweenItems * (i / numberOfColumns)), 0f);
//     }
// }

// // public class MouseItem{
// //     public GameObject obj;
// //     public InventorySlot item;
// //     public InventorySlot hoverItem;
// //     public GameObject hoverObj;
// // }
