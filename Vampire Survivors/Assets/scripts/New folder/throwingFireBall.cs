using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowingFireBall : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    public int damage = 50;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y, 0);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }    
        private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy2 enemy = collision.GetComponent<Enemy2>();
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
            enemy.TakeDamege(damage);
        }
    }
}
