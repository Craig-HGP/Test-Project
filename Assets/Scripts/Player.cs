using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header ("Movement")]
    CharacterController playerController;
    [SerializeField] float xMovement;
    [SerializeField] float zMovement;
    [SerializeField] float moveSpeed;
    [SerializeField] float yRotateAngle;
    Vector3 playerMovement;
    private float xSpeed;
    private float zSpeed;

    [SerializeField] bool isGrounded;

    [Header ("Jumping")]
    [SerializeField] float jumpForce;
    [SerializeField] float yForce;
    [SerializeField] float gravity;
    [SerializeField] float maxGravity;
    
    [Header ("Score")]
    public int coinScore;
    public int maxCoinScore;
    public AudioSource audioSource;
    public ParticleSystem glitter;
    public TextMeshProUGUI coinScoreText;
    public TextMeshProUGUI winText;

    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        glitter = FindObjectOfType<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Gravity();
        Move();
        SetCountText();
        WinGame();

        if(playerController.isGrounded)
        {
            Debug.Log("player is grounded");
        }

    }    

    void Jump()
    {
        //This is the if statement that controls when you jump (by pressing the space bar)
        if(Input.GetKeyDown(KeyCode.Space) && playerController.isGrounded)
        {
            Debug.Log("tried to jump!");
            yForce += jumpForce;
        }
    }
    void Gravity()
    {
        yForce = Mathf.Clamp(yForce - gravity * Time.deltaTime, maxGravity, 300);

        playerMovement.y -= gravity * Time.deltaTime;

        playerController.Move(transform.up * yForce * Time.deltaTime);

    }
    
    void Move()
    {
        //This is the if statement for moving the character forward (using the W key)
        if(Input.GetKey(KeyCode.W))
        {
            playerController.Move(transform.forward * zMovement * Time.deltaTime);
        }                

        if(Input.GetKey(KeyCode.S))
        {
            playerController.Move(-transform.forward * zMovement * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            playerController.Move(-transform.right * xMovement * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            playerController.Move(transform.right * xMovement * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0,-yRotateAngle * Time.deltaTime, 0);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0,yRotateAngle * Time.deltaTime, 0);
        }
    }

    void SetCountText()
    {
        coinScoreText.text = "Score: " + coinScore.ToString();
    }

    void WinGame()
    {
        if(coinScore == maxCoinScore)
        {
            winText.enabled = true;
            Invoke("BackToStart", 2f);
        }
    }

    void BackToStart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }

}
