using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPos : MonoBehaviour
{
    public Transform camerPositin;

    // Update is called once per frame
    private void Update()
    {
        transform.position = camerPositin.position;

    }
}
