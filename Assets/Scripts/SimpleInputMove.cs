using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInputMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _firstY = 2.5f;

    public event System.Action OnMove;

    void Update()
    {
        if(Input.anyKey)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * _moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, _firstY, transform.position.z);
            OnMove?.Invoke();
        }
        
    }
}
