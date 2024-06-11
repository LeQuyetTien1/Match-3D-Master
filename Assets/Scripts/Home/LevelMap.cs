using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMap : MonoBehaviour
{
    public static bool isPasslv1, isPasslv2, isPasslv3, isPasslv4;
    public Image lv2Image, lv3Image, lv4Image, lv5Image;
    public Image sourceImage;
    void Start()
    {
        CheckPass(isPasslv1, lv2Image);
        CheckPass(isPasslv2, lv3Image);
        CheckPass(isPasslv3, lv4Image);
        CheckPass(isPasslv4, lv5Image);
    }
    public void CheckPass(bool isPass, Image lvImage)
    {
        if (isPass) lvImage.sprite = sourceImage.sprite;
    }
}
