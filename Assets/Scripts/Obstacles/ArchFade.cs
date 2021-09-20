using UnityEngine;

public class ArchFade : MonoBehaviour
{
    [SerializeField] private Material material;

    private float timer;
    private float currentFade = 0;
    private bool down = false;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            timer = 0;

            if (down)
            {
                currentFade -= 0.1f;
            }
            else
            {
                currentFade += 0.1f;
            }

            if (currentFade >= 1 || currentFade <= 0)
            {
                down = !down;
            }

            material.color = new Color(1, 1, 1, currentFade);
        }
    }
}
