using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    private int direction = 1;
    private Vector3 dirVec;

    

    void Start()
    {
        
    }

    void Update()
    {
        //Movement
        Vector2 movementX = new Vector2(speed * direction, 0);
        transform.Translate(movementX * Time.deltaTime);
        dirVec = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trigger")
        {       
            //Turns around
            direction *= -1;
            dirVec.x *= -1;
            transform.localScale = dirVec;
        }

        if (other.gameObject.tag == "MinotaurATK")
        {
            GetComponent<Animator>().Play("MinotaurATK"); // Trigger the attack animation
        }
    }
}