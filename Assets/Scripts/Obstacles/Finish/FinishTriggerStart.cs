using UnityEngine;
using UnityEngine.UI;

public class FinishTriggerStart : MonoBehaviour
{
    [SerializeField] private GameObject tapsText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            RigidbodyConstraints rigidbodyConstraints;
            rigidbodyConstraints = RigidbodyConstraints.FreezeRotation;
            other.transform.GetComponent<PlayerFinishMode>().Finish();
            other.transform.GetComponent<Rigidbody>().constraints = rigidbodyConstraints;
            tapsText.SetActive(true);
            Destroy(gameObject);
        }
    }
}
