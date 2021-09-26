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
    [SerializeField] private PlayerUI playerUI;
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Animator animator;

    private int lastTouch;
    private int clickCount = 0;

    public void Finish()
    {
        playerMove.enabled = false;
        playerUI.TryChangeSpeed(500);
        playerFinishMode.enabled = true;
        restartButton.SetActive(false);
    }

    public void EndFinish()
    {
        playerFinishMode.enabled = false;
        playerFinishMove.enabled = true;
        playerFinishMove.GetInformation(clickCount);
        animator.SetBool("FinishJump", true);
    }

    private void Update()
    {
        rigidBody.velocity = new Vector3((playerStatus.rightBorder + playerStatus.leftBorder) / 2 - transform.position.x, 0.1f, 500 * Time.fixedDeltaTime);

        if (Input.touchCount > lastTouch)
        {
            clickCount++;
            taps.text = clickCount.ToString();
        }

        lastTouch = Input.touchCount;
    }
}
