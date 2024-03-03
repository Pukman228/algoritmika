using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Vector2 targetPosition;
    public float moveStep;
    public bool isTrap;
    public float speedFactor;
    public float scaleFactor;
    public int catchCount;
    // public GameObject playerObj;

    Vector2 GetRandomPoint()
    {
        Vector2 randomVector = new Vector2();
        randomVector.x = Random.Range(-6, 6);
        randomVector.y = Random.Range(-3, 3);
        return randomVector;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isTrap == false)
        {
            Player.squares.Add(this);
        }
        targetPosition = GetRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveStep * Time.deltaTime);

        if((Vector2)transform.position == targetPosition)
        {
            targetPosition = GetRandomPoint();
        }
    }

    void Catch()
    {
        // Player player = playerObj.GetComponent<Player>();
        Player.score++;
        catchCount--;
        if (catchCount == 0)
        {
            Player.squares.Remove(this);
            Destroy(gameObject);
        }
        else
        {
            moveStep += speedFactor;
            transform.localScale = (Vector2)transform.localScale - new Vector2(scaleFactor, scaleFactor);
            transform.position = GetRandomPoint();
        }

            
    }

    void OnMouseDown()
    {
        if(isTrap)
        {
            Player.Defeat();
        }
        else
        {
            Catch();
        }
    }
}
