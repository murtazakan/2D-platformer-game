using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public int direction;

    private void MoveEnemy()
    {
        Vector3 position = transform.position;
        position.x -= speed * direction * Time.deltaTime;
        transform.position = position;
        animator.SetFloat("Walk", position.x);
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void EnemyMovementAnimation() {
        Vector3 scale = transform.localScale;
        scale.x = -direction * Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Edge"))
        {
            EnemyMovementAnimation();

            direction = direction * -1;
        }
        else { 
        
        }
       
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.killPlayer();
            //Destroy(playerController);

        }
    }
    
}
