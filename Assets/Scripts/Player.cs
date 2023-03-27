using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager _gameManager;
    public float forwardSpeed;
    private float firstTouch;
    public int coffeeCount = 0;
    public List<GameObject> cofees;
    void Start()
    {
        cofees = new List<GameObject>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (_gameManager.curruntGameState != GameState.Start)
        {
            return;
        }
        // ileri gönder
        Vector3 moveVektor = new Vector3( -1 * forwardSpeed * Time.deltaTime,  0,  0);
        float diff = 0;
        if (Input.GetMouseButtonDown(0))
        {
            firstTouch = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            float lastTouchX = Input.mousePosition.x;
            diff = lastTouchX - firstTouch;
            moveVektor += new Vector3( 0,  0, diff * Time.deltaTime);
            firstTouch = lastTouchX;

        }
        transform.position += moveVektor;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollecTible"))
        {
            other.transform.SetParent(transform);
            cofees.Add(other.gameObject);

            coffeeCount++;
        }
        else if (other.CompareTag("Finish"))
        {

            if (coffeeCount == 0)
            {
                _gameManager.EndGame();
            }
            else
            {
                Destroy(cofees[cofees.Count - 1]);
                cofees.RemoveAt(cofees.Count - 1);
                coffeeCount--;
            }

        }
    }
}
