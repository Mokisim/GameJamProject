using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Car : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private TrafficLights _trafficLights;
    private bool _canRide = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _trafficLights = FindObjectOfType<TrafficLights>();
    }

    private void Update()
    {
        if (_canRide == true)
        {
            _rigidbody.velocity = transform.right * _speed;
        }
    }

    private void OnEnable()
    {
        _trafficLights.TrafficLightsOff += StartRide;
        _trafficLights.TrafficLightsOn += StopRide;
    }

    private void OnDisable()
    {
        _trafficLights.TrafficLightsOff -= StartRide;
        _trafficLights.TrafficLightsOn -= StopRide;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void StopRide()
    {
        _canRide = false;
        _rigidbody.velocity = transform.right * 0;
    }

    private void StartRide()
    {
        _canRide = true;
    }
}
