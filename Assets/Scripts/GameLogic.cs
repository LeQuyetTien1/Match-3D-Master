using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class GameLogic : MonoBehaviour
{
    public Slot slot1, slot2;
    public GameObject gameOverPanel, gameWinPanel;
    public Button remuseButton, pauseButton, freezeButton;
    public Stopwatch stopwatch;
    public GameObject blackPlane;
    public UnityEvent increaseScore;
    public Item[] listItem;
    private Item replaceItem;
    
    private void OnValidate()
    {
        AddItemID();
    }
    private void Start()
    {
        SpawnItem(1);
        SpawnItem(2);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Item") == null)
        {
            GameWin();
        }
        if (slot1.item != null && slot2.item != null && slot1.item.id == slot2.item.id)
        {
            blackPlane.SetActive(true);
            replaceItem = Instantiate(slot1.item, new Vector3(-0.1f, 0.22f, -4.22f), slot1.item.transform.rotation);
            replaceItem.GetComponent<MeshCollider>().enabled = false;
            replaceItem.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(replaceItem.gameObject,0.5f);
            DestroyObject(slot1);
            DestroyObject(slot2);
            increaseScore.Invoke();
        }
        if (replaceItem == null) blackPlane.SetActive(false);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        DeactivateDragDrop();
        pauseButton.enabled = false;
        freezeButton.enabled = false;
    }
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
        Time.timeScale = 0;
        pauseButton.enabled = false;
        freezeButton.enabled = false;
    }
    private void DestroyObject(Slot slot)
    {
        Destroy(slot.item.gameObject);
        slot.isOccupied = false;
        slot.item = null;        
    }
    [ContextMenu("Add Item ID")]
    public void AddItemID()
    {
        for(int i=0; i<listItem.Length; i++)
        {
            if (listItem[i] != null)
            {
                listItem[i].id = i + 1;
            }           
        }
    }
    public void SpawnItem(int number)
    {
        for(int i=0; i < listItem.Length; i++)
        {
            listItem[i].number = number;
            Instantiate(listItem[i], new Vector3(Random.Range(-6,6),Random.Range(0.5f,2.5f),Random.Range(-0.3f,3f)), Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));            
        }
    }
    public void Pause()
    {
        remuseButton.gameObject.SetActive(true);
        DeactivateDragDrop();
        Time.timeScale = 0;
        freezeButton.enabled = false;
    }
    public void Remuse()
    {
        remuseButton.gameObject.SetActive(false);
        ActivateDragDrop();
        Time.timeScale = 1;
        freezeButton.enabled = true;
    }
    public void DeactivateDragDrop()
    {
        GameObject[] listObject = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < listObject.Length; i++)
        {
            listObject[i].gameObject.layer = 2;
        }
    }
    public void ActivateDragDrop()
    {
        GameObject[] listObject = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < listObject.Length; i++)
        {
            listObject[i].gameObject.layer = 6;
        }
    }
    [ContextMenu("Use Hint")]
    public void UseHint()
    {
        GameObject[] listObject = GameObject.FindGameObjectsWithTag("Item");
        var randomObject = listObject[Random.Range(0, listObject.Length - 1)];
        /*int randomID = Random.Range(1, listItem.Length);*/
        for (int i = 0; i < listObject.Length; i++)
        {
            if (listObject[i] != null && listObject[i].GetComponent<Item>().id == randomObject.GetComponent<Item>().id)
            {
                listObject[i].transform.eulerAngles = Vector3.zero;
                if (listObject[i].GetComponent<Item>().number == 1)
                {
                    /*listObject[i].transform.DOMove(DragDrop.slot1Pos, 1);*/
                    listObject[i].transform.DOLocalJump(DragDrop.slot1Pos, 1, 1, 1);
                }
                else if (listObject[i].GetComponent<Item>().number == 2)
                {
                    /*listObject[i].transform.DOMove(DragDrop.slot2Pos, 1);*/
                    listObject[i].transform.DOLocalJump(DragDrop.slot2Pos, 1, 1, 1);
                }
                
            }
        }
    }
}
