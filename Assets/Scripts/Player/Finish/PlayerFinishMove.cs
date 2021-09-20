using UnityEngine;

public class PlayerFinishMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField]private float timer;
    private float clickCount;
    private float boosterY = 5;

    public void GetInformation(int clickCount)
    {
        this.clickCount = clickCount;

        if (clickCount < 10)
        {
            clickCount = 10;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            // Need PlayerStatus.positive and !PlayerStatus.vectorX
            boosterY -= Time.deltaTime;
            rigidBody.velocity = new Vector3(0, clickCount * boosterY * 15 * Time.deltaTime, clickCount * 15 * Time.deltaTime);
        }
    }
}
