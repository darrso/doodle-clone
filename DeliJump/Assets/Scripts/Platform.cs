using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float forceJump;
    private float xstartpos, xendpos, ystartpos, yendpos;

    public void setPlatformSpawnParametrs(float xs, float xe, float ys, float ye)
    {
        xstartpos= xs;
        xendpos= xe;
        ystartpos= ys;
        yendpos= ye;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0 && collision.collider.name == "Deli")
        {
            Deli.instance.rigidbody.velocity = Vector2.up * forceJump;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "platform")
        {

            float boolean_y = Random.Range(1f, 5f);
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + boolean_y, transform.position.z);
            transform.position = newPosition;
            Debug.Log(boolean_y);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.name == "DeadZone")
        {
            float RandX = Random.Range(xstartpos, xendpos);
            //float RandY = Random.Range(transform.position.y + Unity.Mathematics.math.abs(ystartpos*2f), transform.position.y + yendpos*2f);
            float RandY = Random.Range(transform.position.y + 11f, transform.position.y + 15f);
            transform.position = new Vector3(RandX, RandY, transform.position.z);

        }
    }
}
