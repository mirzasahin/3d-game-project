using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text bulletText;
    public Text healthText;
    public GameObject fakeMenu;
    bool isGameStopped;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        isGameStopped = false;
        player = GameObject.Find("Agent");
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = player.GetComponent<FireSystem>().GetCharger().ToString() + "/" + player.GetComponent<FireSystem>().GetAmmo().ToString();
        healthText.text = "HP: " + player.GetComponent<CharacterController>().GetHealth().ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isGameStopped)
            {
                StopGame();
                isGameStopped = true;
            }
            else if(isGameStopped)
            {
                ContinueGame();
                isGameStopped = false;
            }
        }
    }

    public void ContinueGame()
    {
        fakeMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Mobil için
    public void StopGame()
    {
        fakeMenu.SetActive(true);
        Time.timeScale = 0;
    }

}
