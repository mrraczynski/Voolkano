using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent _agent;
    public Transform _destanation;
    public float deathTime = 5;
    private bool hit;
    public float speed;
    private string navTag;
    public GameObject[] navPoints;

    [SerializeField] private float _rate = 1;
    [SerializeField] private float _amplitude = 3;

    private float _baseSpeed;
    private float _perlinTime;

	public GameObject ghostPrefub;

    private void OnEnable()
    {
        _baseSpeed = _agent.speed;
        _perlinTime = Random.Range(0f, 1000f);
        hit = false;
    }

    private void Update()
    {
        if (!hit)
        {
            _perlinTime += Time.deltaTime * _rate;
            var moveDirection = Vector2.Perpendicular(_agent.velocity).normalized;
            var moveVelocity = moveDirection * Mathf.Lerp(-1f, 1f, Mathf.PerlinNoise(_perlinTime, 0f)) * _amplitude;
            _agent.Move(moveVelocity * Time.deltaTime);
            _agent.speed = (_baseSpeed - moveVelocity.magnitude) * speed;
        }
        else
        {
            _agent.speed = 0;
        }
        //Debug.Log(hit);
    }
    private void Start()
    {
        
        if (navPoints[0])
        {
            int randPoint = Random.Range(0, navPoints.Length);
            navTag = navPoints[randPoint].tag;
            Vector3 dest = GameObject.FindGameObjectWithTag(navTag).transform.position;
            //_agent.SetDestination(_destanation.position);
            _agent.SetDestination(dest);
        }
        else
        {
            _agent.SetDestination(_destanation.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Finish") || other.gameObject.CompareTag("Rock"))
        {
            if (other.gameObject.CompareTag("Finish"))
            {
               HealthController.instance.TakeDamage();
            }
            else
            {
                ScoreController.instance.AddScore();
            }
            Debug.Log("Enemy Enter");
            hit = true;
			Instantiate(ghostPrefub, transform.position, transform.rotation);
			Destroy(this.gameObject);
			
		}
        if (navPoints[0])
        {
            if (other.gameObject.CompareTag(navTag))
            {
                _agent.SetDestination(_destanation.position);
            }
        }
    }

}
