using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target;

    //�ֵĻ�������
    public float HP;
    public float maxHP;
    public float enemyspeed;

    //�ֵ�ai��Ӧ
    public float followDistance;
    public AnimatorStateInfo info;
    public Vector2 direction;//��ȡ���򣨲���⣩
    //״̬
    public bool isHit;

    public Animator EnemyAnim;
    public Rigidbody2D EnemyRB;

    private bool cishu = true;//����������

    // Start is called before the first frame update
    public void Start()
    {
        EnemyAnim = GetComponent<Animator>();
        EnemyRB = GetComponent<Rigidbody2D>();
        HP = maxHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;//��player��ǩ�е�ȡ���λ��

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        EnemyDie();
    }

    
    void FollowPlayer()
    {
        if (cishu)
        {
            if (Mathf.Abs(transform.position.y - target.position.y) < followDistance & Mathf.Abs(transform.position.x - target.position.x) < followDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemyspeed * Time.deltaTime);
                if (transform.position.x - target.position.x > 0)//�ı䳯��
                    transform.eulerAngles = new Vector3(0, 180, 0);
                else
                    transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            EnemyAnim.SetTrigger("hit");
            HP -= 1;

        }
    }


    void EnemyDie()
    {
        if (HP <=0 & cishu)
        {
            EnemyAnim.SetTrigger("die");
            cishu = false;
            Destroy(gameObject,2f);//����������ǡ��ӳ�ʱ�䡱�����ӳٻᵼ�¶�������������ɾ��ʵ����
        }
    }
    

}
