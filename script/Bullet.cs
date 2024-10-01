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
        rigidbody.velocity = direction * speed*3;//�˶������ٶȼӷ���
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);//�����������ɱ�ը�����Լ�ʵ��ɾ��
        Destroy(gameObject);
    }
}
