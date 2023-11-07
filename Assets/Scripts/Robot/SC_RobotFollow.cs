using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;


namespace Robot
{
    public class SC_RobotFollow : MonoBehaviour
    {
        public Transform playerPosition;
        private NavMeshAgent _agent;
        public Player player;
        public LayerMask itemLayerMask;
        public float detectionRadius = 70f;
        private bool _isGoingToItem = false;
        [SerializeField] private float stoppingDistance = 8f;

        private List<Transform> detectedItems = new List<Transform>();

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, itemLayerMask);

            UpdateDetectedItems(hitColliders);

            if (Vector3.Distance(playerPosition.position, _agent.transform.position) > stoppingDistance && !_isGoingToItem)
            {
                _agent.destination = playerPosition.position;
            }
            
            if (detectedItems.Count > 0)
            {
                SetItemFollow();
                Debug.Log("Found items: " + detectedItems.Count);

                detectedItems.Sort((item1, item2) => Vector3.Distance(transform.position, item1.position)
                    .CompareTo(Vector3.Distance(transform.position, item2.position)));

                Debug.Log("Destination: " + detectedItems[0].position);

                _agent.destination = detectedItems[0].position;
            }
            else
            {
                SetPlayerFollow();
            }
        }

        private void UpdateDetectedItems(Collider[] hitColliders)
        {
            detectedItems.Clear();

            foreach (var collider in hitColliders)
            {
                detectedItems.Add(collider.transform);
            }
        }

        private void SetPlayerFollow()
        {
            _isGoingToItem = false;
            _agent.stoppingDistance = stoppingDistance;
        }

        private void SetItemFollow()
        {
            _isGoingToItem = true;
            _agent.stoppingDistance = 0;
        }
    }
}
