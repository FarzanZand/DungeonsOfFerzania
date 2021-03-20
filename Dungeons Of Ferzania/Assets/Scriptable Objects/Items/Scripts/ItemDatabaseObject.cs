using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// As soon as something changes on our Scriptable Objects that causes Unity to serialize that object,
// We're going to go look through all items in our container, and repopulate the item slot, 
// To make sure it is the same item which matches with the Item Id.

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items; // Array of all items in the game
    public Dictionary<ItemObject, int> GetId = new Dictionary<ItemObject, int>();
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>(); // use int as key to return ItemObject

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<ItemObject, int>();
        GetItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
    }
}

public void OnBeforeSerialize()
{

}
}
