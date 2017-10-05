using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    
    public float walkSpeed;
    public float jumpSpeed;

    bool isGrounded;
    bool isWalking;
    public KeyCode jumping = KeyCode.Space;
    RaycastHit2D hit;
    public Sprite[] walkingSprite;
    public Sprite idleSprite;
    bool facingRight;
    
    bool instruct = false;
    public GameObject info;
    public GameObject instructions;


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, rigid.velocity.y);
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
        }
        if (!facingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (rigid.velocity.magnitude > 0.1f)
        {
            if (!isWalking)
            {
                StartCoroutine(Walk());
            }
        }

        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down);
        //Debug.Log(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hit.collider.transform.position));
        if (hit.distance < 1.0f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(jumping))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpSpeed);

            }
        }
        if (!isWalking)
        {
            GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
        if (Input.GetKeyDown(KeyCode.I) && instruct == false)
        {
            instructions.SetActive(true);
            info.SetActive(false);
            instruct = true;

        }
        if (Input.GetKeyDown(KeyCode.M) && instruct == true)
        {
            instructions.SetActive(false);
            info.SetActive(true);
            instruct = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit2d = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);

            if (hit2d.collider.gameObject.GetComponent<ItemData>() != null && hit2d.collider.gameObject.tag == "Good")
            {
                    GetComponent<Health>().health += 20;
                    GetComponent<ItemScript>().add(hit2d.collider.gameObject.GetComponent<ItemData>().itemType, 1);
                    Destroy(hit2d.collider.gameObject);
           }
            else if (hit2d.collider.gameObject.GetComponent<ItemData>() != null && hit2d.collider.gameObject.tag == "Bad")
            {
                GetComponent<Health>().health -= 20;
                GetComponent<ItemScript>().add(hit2d.collider.gameObject.GetComponent<ItemData>().itemType, 1);
                Destroy(hit2d.collider.gameObject);
            }

            else if (hit2d.collider.gameObject.GetComponent<ItemData>() != null)
            {
                GetComponent<ItemScript>().add(hit2d.collider.gameObject.GetComponent<ItemData>().itemType, 1);
                Destroy(hit2d.collider.gameObject);
                Debug.Log("Destroy");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
           SceneManager.LoadScene("Lose");
        }
    }

    IEnumerator Walk()
    {
        isWalking = true;
        GetComponent<SpriteRenderer>().sprite = walkingSprite[0];
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().sprite = walkingSprite[1];
        yield return new WaitForSeconds(0.25f);
        isWalking = false;
    }



}
