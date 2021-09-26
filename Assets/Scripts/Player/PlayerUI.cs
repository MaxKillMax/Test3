using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject restartUI;
    [SerializeField] private Text score;

    public void TryChangeSpeed(float speed)
    {
        if (Mathf.Abs(speed).ToString() != score.text)
        {
            score.text = Mathf.Abs(speed).ToString();
        }
    }

    public void openDeathUI()
    {
        inGameUI.SetActive(false);
        restartUI.SetActive(true);
    }
}
