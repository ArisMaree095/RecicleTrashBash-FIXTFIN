using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP Button ButtonBlue;

    public void UpdateButton()
    {
       GameObject.find("Button Blue").GetComponentInChildren<TextTMPro>().text = "10 monedas";

    }
}
