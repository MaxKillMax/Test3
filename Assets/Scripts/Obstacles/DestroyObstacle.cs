using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerHealth>().Kill();
        }
    }
}
