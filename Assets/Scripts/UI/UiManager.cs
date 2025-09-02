using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject inventory;
    public GameObject pauseMenu;

    public TMP_Text moneyCountText;
    public TMP_Text meatCountText;
    public TMP_Text woodCountText;

    public TMP_Text healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void OpenOrCLoseInventory()
    {
        inventory.SetActive(!inventory.activeSelf);
    }

    public void UpdateMoney(int value)
    {
        moneyCountText.text = value.ToString();
    }
    public void UpdateWood(int value)
    {
        woodCountText.text = value.ToString();
    }
    public void UpdateMeat(int value)
    {
        meatCountText.text = value.ToString();
    }

    public void UpdateHealth(int hpValue)
    {
        healthText.text = hpValue.ToString();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
