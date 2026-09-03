using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    public float gravityModifier;
    public float jumpForce;
    private Rigidbody rb;
    private bool isOnGround = false;
    private Animator playerAnimator;

    // JOUER LES PARTICLES 
    public ParticleSystem playerParticles;
    public ParticleSystem dirtParticles;

    // JOUER DU SON
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    public PlayerController(Rigidbody rb)
    {
        this.rb = rb;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
        this.playerAnimator = this.GetComponent<Animator>();
        this.playerAudio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool mustJump = Input.GetKeyDown(KeyCode.Space) && isOnGround && !this.gameOver;
        if (mustJump)
        {
            this.dirtParticles.Stop();
            this.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            this.isOnGround = false;
            this.playerAnimator.SetTrigger("Jump_trig");
            this.playerAudio.PlayOneShot(this.jumpSound, 1f);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.dirtParticles.Play();
            this.isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("obstacles"))
        {
            this.gameOver = true;
            Debug.Log("Game Over");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            this.playerParticles.Play();
            this.dirtParticles.Stop();
            this.playerAudio.PlayOneShot(this.crashSound, 1f);
        }
    }
}