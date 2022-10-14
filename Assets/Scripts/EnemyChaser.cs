using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
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


    public Animator _animatorBomb;
    public Animator _animatorExplosion;

    int _damage = 0;

    private void Awake()
    {
        _animatorBomb.SetBool("Bomb",  true);
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        _playerPosition = new Vector2(_player.transform.position.x, _player.transform.position.y);
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce((_playerPosition - _rigidbody.position).normalized * _moveSpeed);
        
        Vector2 lookPosition = _playerPosition - _rigidbody.position;
        mouseposition = new Vector3(lookPosition.x, lookPosition.y, 0);
        Quaternion diseredRotation = Quaternion.LookRotation(Vector3.forward, mouseposition);
        _ship.transform.rotation = Quaternion.RotateTowards(_ship.transform.rotation, diseredRotation, rotationSpped * Time.deltaTime);
    }
    public void Attacked(int Hit)
    {
        Destroy(gameObject, 1);
        _animatorExplosion.Play("Explosion");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Attacked(2);
        }
        Attacked(1);
    }

}
