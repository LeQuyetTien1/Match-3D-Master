using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isOccupied = false;
    public Item item;
    private void OnTriggerStay(Collider other)
    {
        isOccupied = true;
        item = other.GetComponent<Item>();
    }
    private void OnTriggerExit(Collider other)
    {
        isOccupied = false;
        item = null;
    }
}
