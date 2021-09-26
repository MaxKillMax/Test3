using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerUI playerUI;

    public void Kill()
    {
        Time.timeScale = 0;
        playerUI.openDeathUI();
    }
}
