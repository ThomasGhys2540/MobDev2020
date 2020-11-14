using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject AudioMaster;
    public GameObject PauseMenu;
    public GameObject CastleMenu;
    public GameObject ShopMenu;
    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.Find("AudioMaster").GetComponent<AudioManager>();
    }

    public void Click()
    {
        audioManager.Play("ButtonClick");
    }

    public void ShopSFX(string player)
    {
        audioManager.Play(player);
    }

    public void Toggle(string toggle)
    {
        switch (toggle)
        {
            case "Shop":
                PauseMenu.SetActive(false);
                CastleMenu.SetActive(false);
                ShopMenu.SetActive(!ShopMenu.activeSelf);
                break;
            case "Pause":
                ShopMenu.SetActive(false);
                CastleMenu.SetActive(false);
                PauseMenu.SetActive(!PauseMenu.activeSelf);
                break;
            case "Castle":
                PauseMenu.SetActive(false);
                ShopMenu.SetActive(false);
                CastleMenu.SetActive(!CastleMenu.activeSelf);
                break;
            default:
                break;
        }
    }
}
