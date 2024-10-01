using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject explosionPrefab;
    new private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed*3;//运动向量速度加方向
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);//遇到东西生成爆炸并将自己实体删除
        Destroy(gameObject);
    }
}
