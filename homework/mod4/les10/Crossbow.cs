using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public Arrow arrowPrefab;
    public float interval = 0.75f;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseScreenPos = Input.mousePosition;
            Vector2 mouseScenePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            Vector2 crossbowPos = transform.position;
            Vector2 wantedDirection = mouseScenePos - crossbowPos;
            Vector2 defaultDirection = Vector2.up;
            float angle = Vector2.SignedAngle(defaultDirection, wantedDirection);
            Vector3 newEuler = new Vector3(0, 0, angle);
            transform.localEulerAngles = newEuler;
            if (timer <= 0)
            {
                Instantiate(arrowPrefab, transform.position, transform.rotation);
                timer = interval;
            }
        }

    }
}
