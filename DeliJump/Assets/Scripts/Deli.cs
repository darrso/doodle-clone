using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deli : MonoBehaviour
{
    float horizontal;
    public Rigidbody2D rigidbody;
    public static Deli instance;
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }
        //horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (horizontal > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        // 10f
        rigidbody.velocity = new Vector2(horizontal * 10f, rigidbody.velocity.y);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Instantiate(BulletPrefab, touch.position, Quaternion.identity);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "DeadZone")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.collider.name == "Left")
        {
            transform.position = new Vector3(2f, transform.position.y, transform.position.z);
        }
        if (collision.collider.name == "Right")
        {
            transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
        }
    }
}
