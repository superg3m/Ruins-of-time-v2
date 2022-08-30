using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public InventoryObject inventory;
    private GameObject player;
    public void OnTriggerEnter2D(Collider2D other)
    {
        var item = GetComponent<Item>();
        player = GameObject.Find("PlayerSprite");
        if (other.gameObject == player && inventory.Container.Count < 56)
        {
            inventory.AddItem(item.item, 1);
            Destroy(gameObject);
        }
        else if(other.gameObject == player && inventory.Container.Count >= 56)
        {
            Debug.Log("You are carrying to much!");
        }
    }
}
