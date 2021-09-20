using UnityEngine;
using UnityEngine.UI;

public class FinishPostJump : MonoBehaviour
{
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject finishUI;
    [SerializeField] private Text textScore;
    [SerializeField] private int score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Time.timeScale = 0;
            inGameUI.SetActive(false);
            finishUI.SetActive(true);
            textScore.text = "Your score: " + score.ToString();
        }
    }
}
