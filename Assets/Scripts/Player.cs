using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _moveSpeed;

    public Rigidbody2D _rigidbody;

    public Camera _camera;
    public int rotationSpped;
    public GameObject _ship;

    Vector2 _movement;
    Vector2 _mousePosition;
    Vector3 mouseposition;
    public SpriteRenderer _shipImage;

    public Sprite _shipHit1;
    public Sprite _shipHit2;
    public Sprite _shipDead;
    public Animator _animatorExplosion;
    int _damage = 0;

    void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if(Input.GetKey("space"))
        {
            _rigidbody.AddForce((_mousePosition - _rigidbody.position).normalized * _moveSpeed);
        }
        Vector2 lookPosition = _mousePosition - _rigidbody.position;
        mouseposition = new Vector3(lookPosition.x, lookPosition.y, 0);
        Quaternion diseredRotation = Quaternion.LookRotation(Vector3.forward, mouseposition);
        _ship.transform.rotation = Quaternion.RotateTowards(_ship.transform.rotation, diseredRotation, rotationSpped * Time.deltaTime);
    }
    public void Attacked(int hit)
    {
        _damage += hit;
        if (_damage == 1)
        {
            _shipImage.sprite = _shipHit1;
        }
        else if (_damage == 2)
        {
            _shipImage.sprite = _shipHit2;
        }
        else if (_damage >= 3)
        {
            _animatorExplosion.Play("Explosion");
            _shipImage.sprite = _shipDead;
        }
    }
}
