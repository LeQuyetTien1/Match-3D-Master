using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    private void OnValidate()
    {
        if (gameObject.GetComponent<DragDrop>() == null)
        {
            gameObject.AddComponent<DragDrop>();
        }
        if (gameObject.GetComponent<MeshCollider>() == null)
        {
            gameObject.AddComponent<MeshCollider>();
            gameObject.GetComponent<MeshCollider>().convex = true;
        }
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }
}
