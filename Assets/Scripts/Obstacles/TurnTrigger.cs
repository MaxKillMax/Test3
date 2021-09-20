using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    [Header("ToDestroy")]
    [SerializeField] private GameObject obstacles;

    [Header("Direction")]
    [SerializeField] private bool nextVectorX;
    [SerializeField] private bool nextPositive;

    [Header("Section Vars")]
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();

            playerStatus.ChangeVector(nextVectorX);
            playerStatus.ChangePositive(nextPositive);
            playerStatus.ChangeBorders(leftBorder, rightBorder);

            Destroy(obstacles);
        }
    }
}
