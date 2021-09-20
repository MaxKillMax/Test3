using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Text score;

    [Header("Vars")]
    [SerializeField] private float speed;
    private float lastSpeed;
    private float direction;
    private bool finishMode;

    private void Start()
    {
        lastSpeed = speed;
    }

    private void Update()
    {
        print(speed);
        if (!finishMode && Input.touchCount > 0)
        {
            direction = Input.GetTouch(0).position.x / (Screen.width / 10) - 5;

            if (!playerStatus.positive || (playerStatus.positive && playerStatus.vectorX))
            {
                direction *= -1;
            }
        }

        float num;
        if (playerStatus.vectorX)
        {
            rigidBody.velocity = new Vector3(speed * Time.deltaTime, 0.1f, direction * 32 * Time.deltaTime * (speed / 200));
            num = transform.position.z;
        }
        else
        {
            rigidBody.velocity = new Vector3(direction * 32 * Time.deltaTime * (speed / 200), 0.1f, speed * Time.deltaTime);
            num = transform.position.x;
        }

        CheckBorders(num);
        CheckSpeed();
        direction = 0;
    }

    private void CheckBorders(float num)
    {
        Vector3 pos = transform.position;
        if (playerStatus.vectorX)
        {
            if (playerStatus.positive)
            {
                if (num < playerStatus.rightBorder + 0.3f)
                    transform.position = new Vector3(pos.x, pos.y, playerStatus.rightBorder + 0.3f);
                else if (num > playerStatus.leftBorder - 0.3f)
                    transform.position = new Vector3(pos.x, pos.y, playerStatus.leftBorder - 0.3f);
            }
            else
            {
                if (num < playerStatus.leftBorder + 0.3f)
                    transform.position = new Vector3(pos.x, pos.y, playerStatus.leftBorder + 0.3f);
                else if (num > playerStatus.rightBorder - 0.3f)
                    transform.position = new Vector3(pos.x, pos.y, playerStatus.rightBorder - 0.3f);
            }
        }
        else
        {
            if (playerStatus.positive)
            {
                if (num > playerStatus.rightBorder - 0.3f)
                    transform.position = new Vector3(playerStatus.rightBorder - 0.3f, pos.y, pos.z);
                else if (num < playerStatus.leftBorder + 0.3f)
                    transform.position = new Vector3(playerStatus.leftBorder + 0.3f, pos.y, pos.z);
            }
            else
            {
                if (num > playerStatus.leftBorder - 0.3f)
                    transform.position = new Vector3(playerStatus.leftBorder - 0.3f, pos.y, pos.z);
                else if (num < playerStatus.rightBorder + 0.3f)
                    transform.position = new Vector3(playerStatus.rightBorder + 0.3f, pos.y, pos.z);
            }
        }
    }

    private void CheckSpeed()
    {
        if (lastSpeed != speed)
        {
            lastSpeed = speed;
            score.text = Mathf.Abs(speed).ToString();
        }
    }

    public void StartFinish()
    {
        finishMode = true;
        speed = 500;
    }

    public void AddSpeed(float num)
    {
        if (speed < 0)
        {
            speed -= num;
        }
        else
        {
            speed += num;
        }
    }

    public void ReverseSpeed()
    {
        speed *= -1;
    }
}
