using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private PlayerTurn playerTurn;

    public bool vectorX { get; private set; }
    public bool positive { get; private set; }

    public float leftBorder { get; private set; }
    public float rightBorder { get; private set; }

    public float rotation { get; private set; }

    private void Start()
    {
        vectorX = false;
        positive = true;

        leftBorder = -5;
        rightBorder = 5;
    }

    public void ChangeVector(bool change)
    {
        if (change != vectorX)
        {
            rigidBody.velocity = new Vector3(0, 0, 0);
            vectorX = change;
        }
    }

    public void ChangePositive(bool change)
    {
        if (change != positive)
        {
            positive = change;
        }

        if (vectorX)
        {
            if (positive)
            {
                rotation = 90;
            }
            else
            {
                rotation = 270;
            }
        }
        else if (!vectorX)
        {
            if (positive)
            {
                rotation = 0;
            }
            else
            {
                rotation = 180;
            }
        }

        playerTurn.StartTurn(rotation);
    }

    public void ChangeBorders(float left, float right)
    {
        leftBorder = left;
        rightBorder = right;
    }
}
