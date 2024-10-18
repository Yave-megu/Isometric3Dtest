using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 oriPosition, targetPosition;
    private float timeToMove = 0.2f;

    enum Direction
    {
        Forward,
        Back,
        Left,
        Right,
        FLeft,
        FRight,
        BLeft,
        BRight
    }
    Vector3[] directions = new Vector3[]
    {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
        Vector3.forward + Vector3.left,
        Vector3.forward + Vector3.right,
        Vector3.back + Vector3.left,
        Vector3.back + Vector3.right
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(directions[(int)Direction.Forward]));
        }
        if(Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(directions[(int)Direction.Back]));
        }
        if(Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(directions[(int)Direction.Left]));
        }
        if(Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(directions[(int)Direction.Right]));
        }
        if(Input.GetKey(KeyCode.Q) && !isMoving)
        {
            StartCoroutine(MovePlayer(directions[(int)Direction.FLeft]));
        }
        if(Input.GetKey(KeyCode.E) && !isMoving)
        {
            StartCoroutine(MovePlayer(directions[(int)Direction.FRight]));
        }
        if(Input.GetKey(KeyCode.Z) && !isMoving)
        {
            StartCoroutine(MovePlayer(directions[(int)Direction.BLeft]));
        }
        if(Input.GetKey(KeyCode.C) && !isMoving)
        {
            StartCoroutine(MovePlayer(directions[(int)Direction.BRight]));
        }
        
    }
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        oriPosition = transform.position;
        targetPosition = oriPosition + direction;
        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(oriPosition, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }

}
