using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private PlayerUI playerUI;

    private float speed = 150;
    private float direction;

    private void Update()
    {
        float forwardMove = speed * Time.fixedDeltaTime;
        float sideMove = speed * Time.fixedDeltaTime / 3;

        if (Input.touchCount > 0)
        {
            direction = Input.GetTouch(0).position.x;

            for (int i = 10; i >= 0; i--)
            {
                if (direction > Screen.width / 10 * i)
                {
                    if ((playerStatus.positive && !playerStatus.vectorX) ||
                        !playerStatus.positive && playerStatus.vectorX)
                    {
                        direction = playerStatus.leftBorder;
                    }
                    else
                    {
                        direction = playerStatus.rightBorder;
                    }

                    if (playerStatus.positive && playerStatus.vectorX)
                    {
                        direction += (10 - i) - 0.5f;
                    }
                    else
                    {
                        direction += i + 0.5f;
                    }

                    break;
                }
            }
        }

        if (!playerStatus.positive)
        {
            forwardMove *= -1;
        }

        if (playerStatus.vectorX)
        {
            rigidBody.velocity = new Vector3(forwardMove, 0.1f, (direction - transform.position.z) * sideMove);
            CheckBorders(transform.position.z);
        }
        else
        {
            rigidBody.velocity = new Vector3((direction - transform.position.x) * sideMove, 0.1f, forwardMove);
            CheckBorders(transform.position.x);
        }
    }

    private float CheckBorders(float number)
    {
        float Right = playerStatus.rightBorder;
        float Left = playerStatus.leftBorder;

        Vector3 pos = transform.position;
        float result = number;

        if (playerStatus.vectorX)
        {
            if (playerStatus.positive)
            {
                if (number < Right + 0.3f)
                    result = Right + 0.3f;
                else
                if (number > Left - 0.3f)
                    result = Left - 0.3f;
            }
            else
            {
                if (number < Left + 0.3f)
                    result = Left + 0.3f;
                else
                if (number > Right - 0.3f)
                    result = Right - 0.3f;
            }

            transform.position = new Vector3(pos.x, pos.y, result);
        }
        else
        {
            if (playerStatus.positive)
            {
                if (number > Right - 0.3f)
                    result = Right - 0.3f;
                else
                if (number < Left + 0.3f)
                    result = Left + 0.3f;
            }
            else
            {
                if (number > Left - 0.3f)
                    result = Left - 0.3f;
                else
                if (number < Right + 0.3f)
                    result = Right + 0.3f;
            }

            transform.position = new Vector3(result, pos.y, pos.z);
        }

        return result;
    }

    public void AddSpeed(float num)
    {
        speed += num;
        playerUI.TryChangeSpeed(speed);
    }
}
