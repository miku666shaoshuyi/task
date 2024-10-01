using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    
    }
    void PlayerMove()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        //������ά�����������ƶ�����(normalized�ǽ�������Ϊ��λ����)
        Vector2 movedir = new Vector2(movex, movey).normalized;
        //�����ٶ�=����*�ƶ��ٶ�
        rb.velocity = movedir * moveSpeed;
        //�ı䶯����run��ֵ��ʹ�ÿ���ͨ��run�ı仯���̻���idle��run�ı仯
        //ע�⣺1��Ҫ*movex������ֵ������ֻ���ٶ�ֵ��2����������ֵ�������������������üӾ���ֵ������������
        playerAnim.SetFloat("run", Mathf.Abs(moveSpeed*movex));
        //�ı䳯��
        float faceNum = Input.GetAxisRaw("Horizontal")*3;//��raw�ǡ�-1��0��1���仯�������������ı仯
        if (faceNum != 0)
        {
            //Сд��t������ֱ�ӵ��ý�ɫ��������;scale������Ϊ�������������Ҫ��ά����
            transform.localScale = new Vector3(faceNum, transform.localScale.y,transform.localScale.z);
        }
    }
}
