using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
    public float distance;
    public GameObject progressBarCover;
    bool isActive = true;

    void Update()
    {
        if (isActive)
        {
            var p = progressBarCover.transform.localPosition;
            if (p.y > 0 && p.y <= 4)
                progressBarCover.transform.localPosition = new Vector3(p.x, p.y - distance * Time.deltaTime, p.z);
        }
    }
}
