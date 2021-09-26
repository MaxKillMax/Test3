using UnityEngine;

public class PlayerFinishMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField]private float timer;
    private float clickCount;
    private float boosterY = 6;

    public void GetInformation(int clickCount)
    {
        this.clickCount = clickCount;

        if (clickCount < 5)
        {
            this.clickCount = 5;
        }
        else
        if (clickCount > 34)
        {
            this.clickCount = 34;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            // Need PlayerStatus.positive and !PlayerStatus.vectorX
            boosterY -= Time.deltaTime;
            rigidBody.velocity = new Vector3(0, clickCount * boosterY * Time.deltaTime, clickCount * 7 * Time.deltaTime);
        }
    }
}
