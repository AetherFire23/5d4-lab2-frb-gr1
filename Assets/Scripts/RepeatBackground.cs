using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private BoxCollider boxCollider;
    private Vector3 startPos;
    private float repeatWidth = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.boxCollider = this.GetComponent<BoxCollider>();
        this.repeatWidth = this.repeatWidth = boxCollider.size.x / 2;
        this.startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}