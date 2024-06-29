using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Slot slot1, slot2;
    public GameObject gameOverPanel, gameWinPanel, pausePanel;
    public Button remuseButton, pauseButton, freezeButton, hintButton;
    public Stopwatch stopwatch;
    public GameObject blackPlane, messagePanel;
    public Text messageText;
    public UnityEvent increaseScore, gameWin;
    public AudioSource correctSound, fireworkSound;
    public Item[] listItem;
    private Item replaceItem;
    private float hitTime;

    private void OnValidate()
    {
        AddItemID();
    }
    private void Start()
    {
        Time.timeScale = 1;
        SpawnItem(1);
        SpawnItem(2);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Item") == null)
        {
            gameWin.Invoke();
        }
        if (slot1.item != null && slot2.item != null && slot1.item.id == slot2.item.id)
        {
            hitTime = Time.time;
            blackPlane.SetActive(true);
            replaceItem = Instantiate(slot1.item, new Vector3(-0.1f, 0.22f, -4.22f), slot1.item.transform.rotation);
            replaceItem.GetComponent<MeshCollider>().enabled = false;
            replaceItem.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(replaceItem.gameObject, 0.4f);
            DestroyObject(slot1);
            DestroyObject(slot2);
            PlayCorrectSound();
            increaseScore.Invoke();
        }
        if (hitTime != 0 && Time.time - hitTime >= 0.5)
        {
            HintButton.isEndJump = true;
            hitTime = 0;
        }
        if (replaceItem == null)
        {
            blackPlane.SetActive(false);
        }
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        DeactivateDragDrop();
        Time.timeScale = 0;
        pauseButton.enabled = false;
        freezeButton.enabled = false;
        hintButton.enabled = false;
        
    }
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
        Time.timeScale = 0;
        pauseButton.enabled = false;
        freezeButton.enabled = false;
        hintButton.enabled = false;
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
        for (int i = 0; i < listItem.Length; i++)
        {
            if (listItem[i] != null)
            {
                listItem[i].id = i + 1;
            }
        }
    }
    public void SpawnItem(int number)
    {
        for (int i = 0; i < listItem.Length; i++)
        {
            listItem[i].number = number;
            Instantiate(listItem[i], new Vector3(Random.Range(-6.2f, 6.2f), Random.Range(0.75f, 2.5f), Random.Range(-1f, 2.7f)), Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));
        }
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        DeactivateDragDrop();
        Time.timeScale = 0;
        freezeButton.enabled = false;
        hintButton.enabled = false;
    }
    public void Remuse()
    {
        pausePanel.SetActive(false);
        ActivateDragDrop();
        Time.timeScale = 1;
        freezeButton.enabled = true;
        hintButton.enabled = true;
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
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("Home");
        ScoreBar.SetScore();
        LeaderBoard.CheckRank();
        Debug.Log(LeaderBoard.currentScore);
        if (EventSystem.isInfinity) return;
        EventSystem.heart--;
        if (LifeSystem.tempTime != 0)
        {
            LifeSystem.time = LifeSystem.tempTime;
            LifeSystem.tempTime = 0;
        }
    }
    public void ContinuePlaying()
    {
        if (EventSystem.gold >= 100)
        {
            EventSystem.gold -= 100;
            stopwatch.gameTime = stopwatch.limitTime;
            gameOverPanel.SetActive(false);
            ActivateDragDrop();
            pauseButton.enabled = true;
            freezeButton.enabled = true;
            hintButton.enabled = true;
            Time.timeScale = 1;
        }
        else
        {
            ShowMessage("Not enough gold");
        }
    }
    public void PlayCorrectSound()
    {
        correctSound.Play();
    }
    public void HideMessage()
    {
        messagePanel.SetActive(false);
    }
    public void ShowMessage(string message)
    {
        messagePanel.SetActive(true);
        messageText.text = message;
    }
    public void Restart()
    {
        if (EventSystem.isInfinity) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (EventSystem.heart > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            EventSystem.heart--;
        }
        else ShowMessage("Can't restart! You have no life");
    }
    public void Next()
    {
        SceneManager.LoadScene("Home");
        Pass();
    }
    public void Pass()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "Level1")
        {
            LevelMap.isPasslv1 = true;
        }
        else if(sceneName == "Level2")
        {
            LevelMap.isPasslv2 = true;
        }
        else if (sceneName == "Level3")
        {
            LevelMap.isPasslv3 = true;
        }
        else if (sceneName == "Level4")
        {
            LevelMap.isPasslv4 = true;
        }
        else
        {
            return;
        }
    }
}
