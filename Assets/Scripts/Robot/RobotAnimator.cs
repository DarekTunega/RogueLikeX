using UnityEngine;
using UnityEngine.AI;

namespace Robot
{
    public class RobotAnimator : MonoBehaviour
    {
        public Animator animator;
        public NavMeshAgent agent;

        public void Start()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

        public void Update()
        {
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("Speedpercent", speedPercent, 0.1f, Time.deltaTime);
        }
    }
}
