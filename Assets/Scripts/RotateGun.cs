using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{

    [SerializeField] private Camera _camera;

    private float _currentSide;
    private float _originalScale;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _originalScale = transform.localScale.y;
    }

    void Update()
    {
        Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.z = 0f;
        transform.right = difference.normalized;
        Flip(difference);
    }

    void Flip(Vector3 difference)
    {
        //var side = Vector3.Dot(difference, Vector3.right) > 0f ? 1f : -1f;

        float side = 0f;
        if (Vector3.Angle(difference, Vector3.right) < 90f)
            side = 1f;
        else
            side = -1f;

        if (_currentSide != side)
        {
            _currentSide = side;
            var myScale = transform.localScale;
            myScale.y = side * _originalScale;
            transform.localScale = myScale;
        }
    }


    /*[SerializeField] private Camera _camera;
    public float offset;


    void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        Vector3 difference = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Vector2.SignedAngle(Vector2.up, _camera.ScreenToWorldPoint(Input.mousePosition)) < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, -1, transform.localScale.z);
        }

    }*/
}

