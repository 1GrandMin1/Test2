using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;
    private bool isRight=false;
    [SerializeField] private float offset;

    


    private void Update()
    {
        
        if (!isRight)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * 3);
        }
        else
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
        if (transform.position.x >= _startPosition.x)
        {
            isRight = false;

        }
        else if(transform.position.x <= _endPosition.x)
        {
            isRight = true;
        }
        
        


    }
}
