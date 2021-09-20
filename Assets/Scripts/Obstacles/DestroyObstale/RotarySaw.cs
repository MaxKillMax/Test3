using UnityEngine;

public class RotarySaw : DestroyObstacle
{
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform leftStick;
    [SerializeField] private Transform rightStick;

    private bool toLeft = true;
    private float currentRotation = 0;

    private void Update()
    {
        if (currentRotation > 100000)
        {
            currentRotation = 0;
        }
        else
        {
            currentRotation += Time.deltaTime * 800;
            transform.localEulerAngles = new Vector3(currentRotation, 0, 90);
        }

        Vector3 zero = Vector3.zero;
        if (toLeft)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(leftStick.position.x, leftStick.position.y + 0.9f, leftStick.position.z), ref zero, 0.2f, 3);

            if ((new Vector3(leftStick.position.x, leftStick.position.y + 0.9f, leftStick.position.z) - transform.position).magnitude <= 0.5f)
            {
                toLeft = false;
            }
        }
        else if (!toLeft)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(rightStick.position.x, rightStick.position.y + 0.9f, rightStick.position.z), ref zero, 0.2f, 3);

            if ((new Vector3(rightStick.position.x, rightStick.position.y + 0.9f, rightStick.position.z) - transform.position).magnitude <= 0.5f)
            {
                toLeft = true;
            }
        }
    }
}
