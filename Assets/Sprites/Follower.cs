using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Follower : MonoBehaviour
{
    private float moveSpeed;
    private float friction;
    private Rigidbody rb;
    private ControlLoading CL;
    public PlayerController playerdata;
    public Transform player;
    private Animator Ani;
    public float distance;
    private Vector3 Newpos;
    public float smoothing = 10f;
    public Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Ani = GetComponent<Animator>();
        rb.freezeRotation = true;
        rb.drag = friction;
        CL = GameObject.Find("Sun").GetComponent<ControlLoading>();
        moveSpeed = CL.moveSpeed;
        friction = CL.friction;
        playerdata = GameObject.Find("player").GetComponent<PlayerController>();
        Physics.IgnoreLayerCollision(6, 7, true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 positionA = player.transform.position;
        Vector3 positionB = transform.position;
        distance = Vector3.Distance(positionA, positionB);

        //�̳���Ҷ���״̬
        Ani.SetBool("IfMoveKey", playerdata.Ani.GetBool("IfMoveKey"));
        Ani.SetInteger("FaceDir", playerdata.Dir);
        Ani.SetBool("Ifrun", playerdata.Ani.GetBool("Ifrun"));

        //����λ��
        if (distance > 1) 
        {
            if (playerdata.Dir == 1)
            {
                Newpos = new Vector3(positionA.x - moveSpeed / 6, positionA.y, positionA.z - moveSpeed / 6);
                transform.position = Vector3.SmoothDamp(transform.position, Newpos, ref velocity, smoothing * Time.fixedDeltaTime);
                Ani.SetBool("IfMoveKey", true);
                Ani.SetInteger("FaceDir", playerdata.Dir);
            }

            if (playerdata.Dir == -1)
            {
                Newpos = new Vector3(positionA.x + moveSpeed / 4 , positionA.y, positionA.z);
                transform.position = Vector3.SmoothDamp(transform.position, Newpos, ref velocity, smoothing * Time.fixedDeltaTime);
                Ani.SetBool("IfMoveKey", true);
                Ani.SetInteger("FaceDir", playerdata.Dir);
            }

            if (playerdata.Dir == 0)
            {
                Newpos = new Vector3(positionA.x + moveSpeed / 6, positionA.y, positionA.z + moveSpeed / 6);
                transform.position = Vector3.SmoothDamp(transform.position, Newpos, ref velocity, smoothing * Time.fixedDeltaTime);
                Ani.SetBool("IfMoveKey", true);
                Ani.SetInteger("FaceDir", playerdata.Dir);
            }

            if (playerdata.Dir == -2)
            {
                Newpos = new Vector3(positionA.x - moveSpeed / 4, positionA.y, positionA.z);
                transform.position = Vector3.SmoothDamp(transform.position, Newpos, ref velocity, smoothing * Time.fixedDeltaTime);
                Ani.SetBool("IfMoveKey", true);
                Ani.SetInteger("FaceDir", playerdata.Dir);
            }
        }

        //���������ж�
        if (Ani.GetBool("IfMoveKey"))
        {
            if (Ani.GetBool("Ifrun"))
            {
                switch (playerdata.Dir)
                {
                    case 1:
                        Ani.Play("Flyback");
                        break;
                    case 0:
                        Ani.Play("Flyface");
                        break;
                    case -1:
                        Ani.Play("Flyleft");
                        break;
                    case -2:
                        Ani.Play("Flyright");
                        break;
                }
            }
            else
            {
                switch (playerdata.Dir)
                {
                    case 1:
                        Ani.Play("Moveback");
                        break;
                    case 0:
                        Ani.Play("Moveface");
                        break;
                    case -1:
                        Ani.Play("Moveleft");
                        break;
                    case -2:
                        Ani.Play("Moveright");
                        break;
                }
            }
        }
        else
        {
            switch (playerdata.Dir)
            {
                case 1:
                    Ani.Play("Standback");
                    break;
                case 0:
                    Ani.Play("Standface");
                    break;
                case -1:
                    Ani.Play("Standleft");
                    break;
                case -2:
                    Ani.Play("Standright");
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // ���������ʱ��ʹ����ܹ�����
            Physics.IgnoreLayerCollision(6, 7, false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // �������������ʱ���ָ��㼶��ײ
            Physics.IgnoreLayerCollision(6, 7, true);
        }
    }
}
