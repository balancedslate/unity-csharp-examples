using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    // Start is called before the first frame update
    Text playerUI;
    GameObject ourScript;
    ThomasGlobalHealth thomashealth;
    int PlayerHealth;

    void Start()
    {
        ourScript = GameObject.FindWithTag("health");
        thomashealth = ourScript.GetComponent<ThomasGlobalHealth>();
        playerUI = GetComponent<Text>();
    }
    void Update()
    {
        PlayerHealth = thomashealth.playerHealth;
        playerUI.text = "Player Health:" + PlayerHealth.ToString();
    }
}