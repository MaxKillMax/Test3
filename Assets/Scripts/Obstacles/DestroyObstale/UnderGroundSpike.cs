using UnityEngine;

public class UnderGroundSpike : DestroyObstacle
{
    [SerializeField] private Rigidbody rigidBody;

    private float upY = -0.2f;
    private float downY = -3;

    private float timer = 0;

    private bool moveUp = true;
    private float moveSpeed = 400;

    void Update()
    {
        if (timer <= 0)
        {
            rigidBody.velocity = new Vector3(0, moveSpeed * Time.deltaTime, 0);

            if (moveUp && (upY - transform.position.y) < 0.1f ||
                !moveUp && (transform.position.y - downY) < 0.1f)
            {
                ChangeMove();
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void ChangeMove()
    {
        timer = 1.5f;

        moveUp = !moveUp;
        moveSpeed *= -1;

        rigidBody.velocity = Vector3.zero;
    }
}
