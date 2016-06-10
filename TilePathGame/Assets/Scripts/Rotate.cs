using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    bool isPause = false;
    bool isRotating = false;
    int direction = 1;
    int degree = 1;
    private float speed = 1f;
    private float offset = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            transform.Rotate(new Vector3(0, 0, direction * degree));
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            transform.Rotate(new Vector3(0, 0, direction * degree));
        }

        if (Input.GetKey(KeyCode.W))
        {
            offset = Time.deltaTime;
            transform.Translate(new Vector3(0, offset, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            offset = Time.deltaTime;
            transform.Translate(new Vector3(0, -offset, 0));
        }
    }
}
