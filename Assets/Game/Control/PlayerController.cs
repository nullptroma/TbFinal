using UnityEngine;
using UnityEngine.Serialization;

namespace Control
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float groundDeceleration;
        [SerializeField] private float flyAcceleration;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float jumpImpuls;
        
        private bool _jump = false;
        private bool _grounded = false;
        private Rigidbody2D _rb;
        private float _moveXAxis;
    
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var velocity = _rb.velocity;
            if (!_grounded && _moveXAxis != 0)
                velocity.x = Mathf.MoveTowards(velocity.x, maxSpeed * _moveXAxis, flyAcceleration*Time.deltaTime);
            else if(_grounded)
                velocity.x = Mathf.MoveTowards(velocity.x, 0, groundDeceleration*Time.deltaTime);
            _rb.velocity = velocity;
            if (_jump)
            {
                _rb.AddForce(Vector2.up * jumpImpuls, ForceMode2D.Impulse);
                _jump = false;
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            _moveXAxis = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space))
                _jump = true;
        }
    }
}
