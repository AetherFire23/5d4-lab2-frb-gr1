using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    public float gravityModifier;
    public float jumpForce;
    private Rigidbody rb;
    private bool isOnGround = false;

    public PlayerController(Rigidbody rb)
    {
        this.rb = rb;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            this.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            this.isOnGround = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("obstacles"))
        {
            this.gameOver = true;
            Debug.Log("Game Over");
        }
    }
}