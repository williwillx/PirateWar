using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public Transform _firePointFront;
    public Transform _firePointSide1;
    public Transform _firePointSide2;
    public Transform _firePointSide3;
    public GameObject _prefabCannonBallSide;
    public GameObject _prefabCannonBallFront;
    public float _bulletForce;

    public float _interval;
    float _nextShotFront = 0.0f;
    float _nextShotSide = 0.0f;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (Time.time >= _nextShotFront)
            {
                _nextShotFront = Time.time + _interval;
                ShootFront();
            }
        }

        if(Input.GetMouseButton(1))
        {
            if (Time.time >= _nextShotSide)
            {
                _nextShotSide = Time.time + _interval;
                ShootSide();
            }
        }
    }

    void ShootFront()
    {
        GameObject cannonBallFront = Instantiate(_prefabCannonBallFront, _firePointFront.position, _firePointFront.rotation);
        Rigidbody2D rigidbody2D = cannonBallFront.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(_firePointFront.up * _bulletForce, ForceMode2D.Impulse);
    }

    void ShootSide()
    {
        GameObject cannonBallSide1 = Instantiate(_prefabCannonBallSide, _firePointSide1.position, _firePointSide1.rotation);
        GameObject cannonBallSide2 = Instantiate(_prefabCannonBallSide, _firePointSide2.position, _firePointSide2.rotation);
        GameObject cannonBallSide3 = Instantiate(_prefabCannonBallSide, _firePointSide3.position, _firePointSide3.rotation);
        Rigidbody2D rigidbody2D1 = cannonBallSide1.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbody2D2 = cannonBallSide2.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbody2D3 = cannonBallSide3.GetComponent<Rigidbody2D>();
        rigidbody2D1.AddForce(_firePointSide1.up * _bulletForce, ForceMode2D.Impulse);
        rigidbody2D2.AddForce(_firePointSide2.up * _bulletForce, ForceMode2D.Impulse);
        rigidbody2D3.AddForce(_firePointSide3.up * _bulletForce, ForceMode2D.Impulse);
    }
}
