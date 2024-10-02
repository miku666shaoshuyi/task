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
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
        EnemyRB=GetComponent<Rigidbody2D>();
        HP = maxHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;//��player��ǩ�е�ȡ���λ��

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        EnemyDie();
    }

    private void FixedUpdate()
    {
        Enemyhit();
    }
    void FollowPlayer()
    {
        if (Mathf.Abs(transform.position.x-target.position.x)<followDistance )
        {
            if(Mathf.Abs(transform.position.y - target.position.y) < followDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemyspeed * Time.deltaTime);
                if (transform.position.x - target.position.x > 0)//�ı䳯��
                    transform.eulerAngles = new Vector3(0, 180, 0);
                else
                    transform.eulerAngles = new Vector3(0, 0, 0);
            } 
        }
    }


    //�ܻ�
    void Enemyhit()//�Ѷ�����
    {
        info = EnemyAnim.GetCurrentAnimatorStateInfo(0);//��ȡ������Ϣ
        if (isHit)
        {
            enemyspeed = 0;
            EnemyRB.velocity = -direction * enemyspeed;//�ܻ�����(or ��ֱ)��
            if (info.normalizedTime >= .6f)//��������֣���������ѭ��������С������������
            {
                isHit = false;
                enemyspeed = 1;
            }
        }
    }
    public void GetEnemyHit(Vector2 direction)
    {
        if (!isHit)
        {
            transform.localScale = new Vector3(direction.x, 1, 1);
            isHit = true;
            this.direction = -direction;
            HP -= 20;
            EnemyAnim.SetTrigger("hit");//���ö���״̬
        }
    }
    void EnemyDie()
    {
        if (HP <= 0)
        {
            EnemyAnim.SetTrigger("die");
            Destroy(gameObject);
        }
    }
    


}
