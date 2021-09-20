using UnityEngine;

public class FinishTriggetEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerFinishMode>().EndFinish();
            Destroy(gameObject);
        }
    }
}
