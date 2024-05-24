using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager Instance;

    [SerializeField] private TextMeshProUGUI promptText;


    public void Awake()
    {
        Instance = this;
    }
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

}
