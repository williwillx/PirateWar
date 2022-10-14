using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float _moveSpeed;

    public Rigidbody2D _rigidbody;

    
    public int rotationSpped;
    public GameObject _ship;
    GameObject _player;

    Vector2 _movement;
    Vector2 _mousePosition;
    Vector2 _playerPosition;
    Vector3 mouseposition;

    public Transform _firePointFront;
    public Transform _firePointSide1;
    public Transform _firePointSide2;
    public GameObject _prefabCannonBallFront;
    public float _bulletForce;

    public float _interval;
    float _nextShotFront = 0.0f;
    float _nextShotSide = 0.0f;


    float _playerDistance;

    public SpriteRenderer _shipImage;
    
    public Sprite _shipHit1;
    public Sprite _shipHit2;
    public Sprite _shipDead;
    public Animator _animatorExplosion;
    int _damage = 0;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        _playerPosition = new Vector2(_player.transform.position.x, _player.transform.position.y);
        _playerDistance = Vector2.Distance(_playerPosition, _rigidbody.position); 
    }

    void FixedUpdate()
    {
        if(_playerDistance>7f)
        {
            _rigidbody.AddForce((_playerPosition - _rigidbody.position).normalized * _moveSpeed);
        }
        

        Vector2 lookPosition = _playerPosition - _rigidbody.position;
        mouseposition = new Vector3(lookPosition.x, lookPosition.y, 0);
        Quaternion diseredRotation = Quaternion.LookRotation(Vector3.forward, mouseposition);
        _ship.transform.rotation = Quaternion.RotateTowards(_ship.transform.rotation, diseredRotation, rotationSpped * Time.deltaTime);


        if (Time.time >= _nextShotSide)
        {
            _nextShotSide = Time.time + _interval;
            ShootSide();
        }
    }

    void ShootSide()
    {
        GameObject cannomBallFront = Instantiate(_prefabCannonBallFront, _firePointFront.position, _firePointFront.rotation);
        GameObject cannonBallSide1 = Instantiate(_prefabCannonBallFront, _firePointSide1.position, _firePointSide2.rotation);
        GameObject cannonBallSide2 = Instantiate(_prefabCannonBallFront, _firePointSide2.position, _firePointSide2.rotation);
        Rigidbody2D rigidbody2D1 = cannonBallSide1.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbody2D2 = cannonBallSide2.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbody2D3 = cannomBallFront.GetComponent<Rigidbody2D>();
        rigidbody2D1.AddForce(_firePointSide1.up * _bulletForce, ForceMode2D.Impulse);
        rigidbody2D2.AddForce(_firePointSide2.up * _bulletForce, ForceMode2D.Impulse);
        rigidbody2D3.AddForce(_firePointFront.up * _bulletForce, ForceMode2D.Impulse);
    }

    public void Attacked(int hit)
    {
        _damage += hit;
        if(_damage==1)
        {
            _shipImage.sprite = _shipHit1;
        }
        else if (_damage == 2)
        {
            _shipImage.sprite = _shipHit2;
        }else if (_damage >= 3)
        {
            _animatorExplosion.Play("Explosion");
            _shipImage.sprite = _shipDead;
            Destroy(gameObject, 1);
        }
    }

}
