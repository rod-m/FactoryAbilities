using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AI;
public class PlayerNav : MonoBehaviour
{
    private int _health = 100;
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public int NormalSpeed
    {
        get { return _normalSpeed; }
        set { _normalSpeed = value; }
    }

    private int _normalSpeed = 5;
    public int Speed
    {
        get { return _speed; }
        set
        {
            if (value > _speed)
            {
                ShowParticle(1);
                StartCoroutine(SpeedDown());
            }
            _speed = value;
            agent.speed = _speed;
            agent.acceleration = 12;
         
        }
    }

    private int _speed = 10;
    [SerializeField] private GameObject[] particles;
    
    private NavMeshAgent agent;

    public void ShowParticle(int index)
    {
        GameObject particle = particles[index];
        particle.SetActive(true);
        StartCoroutine(HideMe(particle));

    }

    private IEnumerator HideMe(GameObject particle)
    {
        yield return new WaitForSeconds(1);
        particle.SetActive(false);
    }
    private IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(2);
        this.Speed = this.NormalSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
          
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 300))
            {
                //Debug.Log("hit " + hit.point.ToString());
                agent.destination = hit.point;
                agent.isStopped = false;       
            }
           
        }

     
        
    }
}
