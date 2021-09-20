using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject restartUI;

    public void Kill()
    {
        Time.timeScale = 0;
        inGameUI.SetActive(false);
        restartUI.SetActive(true);
    }
}
