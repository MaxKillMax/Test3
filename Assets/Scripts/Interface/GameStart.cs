using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] GameObject inGameInterface;
    [SerializeField] GameObject startInterface;

    [SerializeField] GameObject[] destroyList;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        inGameInterface.SetActive(true);
        startInterface.SetActive(false);
    }

    public void LightStart()
    {
        for (int i = 0; i < destroyList.Length; i++)
        {
            destroyList[i].SetActive(false);
        }

        playerMove.AddSpeed(250);
        StartGame();
    }
}
