using UnityEngine;
using UnityEngine.UI;

public class PlayerFinishMode : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Text taps;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private PlayerFinishMode playerFinishMode;
    [SerializeField] private PlayerFinishMove playerFinishMove;
    [SerializeField] private Animator animator;

    private int lastTouch;
    private int clickCount = 0;

    public void Finish()
    {
        playerMove.StartFinish();
        playerFinishMode.enabled = true;
        restartButton.SetActive(false);
    }

    public void EndFinish()
    {
        Debug.Log(clickCount);
        playerMove.enabled = false;
        playerFinishMode.enabled = false;
        playerFinishMove.enabled = true;
        playerFinishMove.GetInformation(clickCount);
        animator.SetBool("FinishJump", true);
    }

    private void Update()
    {
        if (Input.touchCount > lastTouch)
        {
            clickCount++;
            taps.text = clickCount.ToString();
        }

        lastTouch = Input.touchCount;
    }
}
