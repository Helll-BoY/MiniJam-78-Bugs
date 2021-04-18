
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speed;
    public float Acc;

    Rigidbody2D rb;

    public float RotCon;

    float MoveY, MoveX = 1;
    public GameObject[] mas = new GameObject[10];
   [SerializeField] List<GameObject> masss= new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 Vel = transform.right * (MoveX * Acc);
        rb.AddForce(Vel);

        float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if (Acc > 0)
        {
            if (Dir > 0)
            {
                rb.rotation += MoveY * RotCon * (rb.velocity.magnitude / speed);
            }
            else
            {
                rb.rotation -= MoveY * RotCon * (rb.velocity.magnitude / speed);
            }
        }

        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustForce;

        rb.AddForce(rb.GetRelativeVector(relForce));


        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}