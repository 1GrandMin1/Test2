using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed_Move = 5f;
    [SerializeField] private float player_Jump = 10f;
    [SerializeField] private float gravity = 0.05f;
    [SerializeField] private int _scoreJump=0;
    private int twojump = 2;
    [SerializeField] float speed_Run = 10f;
    [SerializeField] private CharacterController _player;
    Vector3 move_Direction;
    private int scoreMoney;
    [SerializeField] private Text _scoreMoney;
    [SerializeField] private int score;
    private void Start()
    {
        _player = GetComponent<CharacterController>();
        
    }
    private void Update()
    {
        _scoreMoney.text = scoreMoney.ToString();
        player_Move();
       
    }

    private void player_Move()
    {
        float x_Move = Input.GetAxis("Horizontal")*speed_Move;
        float z_Move = Input.GetAxis("Vertical")*speed_Move;
        if (_player.isGrounded)
        {
            move_Direction = new Vector3(x_Move, 0f, z_Move);
            move_Direction = transform.TransformDirection(move_Direction);
            _scoreJump = 0;
           
        }
        if (Input.GetKeyDown(KeyCode.Space) && _scoreJump < twojump)
        {
            move_Direction.y += player_Jump;
            _scoreJump++;
        }


        move_Direction.y -= gravity;
        _player.Move(move_Direction * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other!=null)
        {
            if (other.CompareTag("Money"))
            {
                scoreMoney += score;
            }
            if (other.CompareTag("Enemy"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
