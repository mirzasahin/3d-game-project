using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text bulletText;
    public Text healthText;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Agent");
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = player.GetComponent<FireSystem>().GetCharger().ToString() + "/" + player.GetComponent<FireSystem>().GetAmmo().ToString();
        healthText.text = "HP: " + player.GetComponent<CharacterController>().GetHealth().ToString();
    }
}
