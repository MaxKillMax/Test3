using UnityEngine;

public class BoostObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerMove>().AddSpeed(15);
            Destroy(gameObject);
        }
    }
}
