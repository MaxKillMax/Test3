using UnityEngine;

public class Press : DestroyObstacle
{
    [SerializeField] private Press neighborPress;
    [SerializeField] private bool start;

    private Vector3 startPosition;
    private bool forward = true;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (start)
        {
            Vector3 zero = Vector3.zero;

            if (forward)
            {
                transform.position = Vector3.SmoothDamp(transform.position, neighborPress.transform.position, ref zero, 0.25f);

                if ((neighborPress.transform.position - transform.position).magnitude < 0.02f)
                {
                    forward = false;
                }
            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position, startPosition, ref zero, 0.25f);

                if ((startPosition - transform.position).magnitude < 0.02f)
                {
                    forward = true;
                    start = false;

                    neighborPress.Next();
                }
            }

        }
    }

    public void Next()
    {
        start = true;
    }
}
