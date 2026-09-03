using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private SpawnManager spawnManagerScript;
    public float speed = 10f;

    public float leftBound = -25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // si lobject attache, sa position depasse le leftbound pis je suis un obstacle ( pour eviter de despawner le background )
        if (this.transform.position.x < leftBound && gameObject.CompareTag("obstacles"))
        {
            Destroy(gameObject);
        }
    }
}