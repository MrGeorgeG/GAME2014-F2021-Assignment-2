using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float sideSpeedy;
    public float sideBoundary;

    void Update()
    {
        SMove();
        checkBounds();
    }

    private void SReset()
    {
        this.transform.position = new Vector3(sideBoundary, transform.position.y);
    }

    private void SMove()
    {
        transform.position -= new Vector3(sideSpeedy, 0.0f) * Time.deltaTime;
    }

    private void checkBounds()
    {
        if (transform.position.x <= -sideBoundary)
        {
            SReset();
        }
    }
}
