using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameUpdate : MonoBehaviour
{
    [SerializeField] private Text scoreName;
    // Start is called before the first frame update
    void Start()
    {
        scoreName.text = $"Best Score : {DataManager.Instance.playerName} : 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
