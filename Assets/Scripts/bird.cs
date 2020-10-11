using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird : MonoBehaviour
{
    private Vector3 _initialposition;
    private bool _birdwasLaunched;
    private float _timesittingaround;
    [SerializeField] private float _launcher = 500;

    private void Awake()
    {
        _initialposition = transform.position;
    }
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialposition);
        if (_birdwasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f)
        {
            _timesittingaround += Time.deltaTime;
        }

        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10 || _timesittingaround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directiontoinitialposition = _initialposition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directiontoinitialposition * _launcher);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdwasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}