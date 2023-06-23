using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float ySpeed;
    [SerializeField] private float xSpeed;
    [SerializeField] private SpriteRenderer flame;
    private bool touchingWall = false;
    private float whatWall = 0; // if -1 is left wall, id 1 is right wall, if 0 none
    [SerializeField] private bool debugLogs;


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 newVel = rb.velocity;
        if (Input.GetKey(KeyCode.Space))
        {
            newVel.y = ySpeed;
            flame.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            flame.enabled = false;
        }

        if (!touchingWall) newVel.x = Input.GetAxis("Horizontal") * xSpeed;
        else if (touchingWall && whatWall * Input.GetAxisRaw("Horizontal") == -1)
        {
            newVel.x = Input.GetAxis("Horizontal") * xSpeed;
        }
        rb.velocity = newVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Shreder"))
        {
            float whatSide = Mathf.Clamp(transform.position.x, -1f, 1f);
            whatWall = Mathf.Round(whatSide);
            touchingWall = true;
        }
        if(debugLogs) Debug.Log("Enter collision " + collision.gameObject.tag + " " + touchingWall + " " + whatWall);*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shreder"))
        {
            touchingWall = false;
            whatWall = 0;
        }
        if (debugLogs) Debug.Log("Exit collision " + collision.gameObject.tag + " " + touchingWall + " " + whatWall);
    }


    // if player.position.x > cam.posotion.x then player is on right side but if < then on the left
}
