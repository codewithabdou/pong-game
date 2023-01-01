using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 8f;
    private float maxY = 4.160667f;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        float movementY=0;
        if (gameObject.CompareTag("Rocket1")) movementY = Input.GetAxisRaw("Vertical");
        else if (gameObject.CompareTag("Rocket2"))
        {
            print("44444");
            movementY = Input.GetAxisRaw("Vertical2");
        }
        transform.position += new Vector3(0f, movementY * speed * Time.deltaTime);
        if (transform.position.y < -maxY) transform.position = new Vector3(transform.position.x, -maxY, transform.position.z);
        if (transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border")) { }
    }
}
