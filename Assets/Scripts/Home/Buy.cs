using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public int numberLife, numberFreeze, numberHint;
    public int numberGold;
    public LifeSystem lifeSystem;
    public ButtonEvent buttonEvent;
    public AudioSource buySound;
    public void Pay()
    {
        if(EventSystem.gold >= numberGold)
        {
            if ((lifeSystem.recoverText.text == "Full" || EventSystem.isInfinity == true) && numberGold != 1000)
            {
                buttonEvent.ShowMessage("Full life, you can't buy more");
                return;
            }
            EventSystem.gold -= numberGold;
            FreezeButton.freezeCount += numberFreeze;
            HintButton.hintCount += numberHint;
            PlayBuyAudio();
            if (EventSystem.heart + numberLife > lifeSystem.maxLife)
            {
                EventSystem.heart = lifeSystem.maxLife;
                lifeSystem.recoverText.text = "Full";
            }
            else
            {
                EventSystem.heart += numberLife;
            }
        }
        else
        {
            buttonEvent.ShowMessage("Not enough gold");
        }
    }
    public void SetInfinity()
    {
        if(EventSystem.gold >= numberGold)
        {
            Debug.Log("SetInfinity");
            EventSystem.isInfinity = true;
            CountInfinityTimeRemain();
        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }
    public void CountInfinityTimeRemain()
    {
            LifeSystem.tempTime = (int)LifeSystem.time;
            LifeSystem.time = lifeSystem.infinityTime;
    }
    public void PlayBuyAudio()
    {
        buySound.Play();
    }
}
