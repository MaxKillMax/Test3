using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;

    private float timer;
    private float rotation;

    public void StartTurn(float rotation)
    {
        this.rotation = rotation;
        timer = 4;

        playerTurn.enabled = true;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, rotation, transform.rotation.eulerAngles.z), 0.2f);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            playerTurn.enabled = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation, transform.rotation.eulerAngles.z);
        }
    }
}
