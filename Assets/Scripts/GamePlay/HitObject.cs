using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    HintButton hintButton;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        hintButton.isEndJump = true;
    }
}
