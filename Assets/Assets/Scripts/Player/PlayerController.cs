using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent PlayerAgent;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false )//鼠标点击获取摄像头射线坐标，再移动
        {
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray, out hit);
            if (isCollide)
            {

                if(hit.collider.tag == Tag.GROUND)//
                {
                    PlayerAgent.stoppingDistance = 0f;//
                    PlayerAgent.SetDestination(hit.point);//
                }
                else if (hit.collider.tag == Tag.INTERACTABLE)
                {
                    PlayerAgent.stoppingDistance = 2f;
                    hit.collider.GetComponent<InteractableObject>().OnClick(PlayerAgent);//
                }
                    //PlayerAngent.SetDestination(hit.point);

            }

        }
        


    }
}
