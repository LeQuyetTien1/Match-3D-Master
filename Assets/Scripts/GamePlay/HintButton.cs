using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{
    public static int hintCount = 10;
    public Text hintCountText;
    private Vector3 dropSlot1 = new Vector3(-1.09f, 0.3f, -4f);
    private Vector3 dropSlot2 = new Vector3(0.91f, 0.3f, -4f);
    private GameObject[] listObject;
    public bool isEndJump = true;
    public Slot slot1;
    public AudioSource hintSound;
    private void Update()
    {
        hintCountText.text = hintCount.ToString();
        listObject = GameObject.FindGameObjectsWithTag("Item");
        IsContact(dropSlot1);
        IsContact(dropSlot2);
    }
    public void UseHint()
    {
        if (hintCount == 0 || isEndJump == false) return;
        isEndJump = false;
        hintCount--;
        if (slot1.isOccupied == true)
        {
            var targetObject = slot1.item;
            if (slot1.item.number == 1)
            {
                JumpToDropPoint(targetObject, 2, dropSlot2);
            }
            else JumpToDropPoint(targetObject, 1, dropSlot2);
            /*PlayHintAudio();*/
        }
        else
        {
            var randomObject = listObject[Random.Range(0, listObject.Length - 1)].GetComponent<Item>();
            JumpToDropPoint(randomObject, 1, dropSlot1);
            JumpToDropPoint(randomObject, 2, dropSlot2);
            /*PlayHintAudio();*/
        }       
    }
    public void JumpToDropPoint(Item randomObj, int number, Vector3 dropSlot)
    {
        for (int i = 0; i < listObject.Length; i++)
        {
            var checkObj = listObject[i].GetComponent<Item>();
            if (checkObj.id == randomObj.id)
            {
                listObject[i].transform.eulerAngles = Vector3.zero;
                listObject[i].GetComponent<Rigidbody>().isKinematic = true;
                if (checkObj.number == number)
                {
                    listObject[i].transform.DOLocalJump(dropSlot, 1, 1, 1);
                }
            }
        }
    }
    public void IsContact(Vector3 dropSlot)
    {
        for (int i = 0; i < listObject.Length; i++)
        {
            var checkObj = listObject[i].transform.position;
            if (checkObj == dropSlot)
            {
                listObject[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
    /*private void PlayHintAudio()
    {
        hintSound.Play();
    }*/
}
