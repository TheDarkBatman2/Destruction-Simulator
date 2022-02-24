using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedPieceController : MonoBehaviour
{
    public bool is_connected = true;
    private bool is_dropping = false;
    [HideInInspector] public bool visited = false;
    public List<DestroyedPieceController> connected_to = new List<DestroyedPieceController>();

    public static bool is_damaged = false;

    private Rigidbody _rigidbody;
    private Vector3 _starting_pos;
    private Quaternion _starting_orientation;
    private Vector3 _starting_scale;

    private bool _configured = false;

    // Start is called before the first frame update
    

    void Start()
    {
        
        _starting_pos = transform.position;
        _starting_orientation = transform.rotation;
        _starting_scale = transform.localScale;

        transform.localScale *= 1.02f;
        _rigidbody = this.GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_configured)
        {
            
            var neighbour = collision.gameObject.GetComponent<DestroyedPieceController>();

            if (neighbour)
            {

                if(!connected_to.Contains(neighbour))
                    connected_to.Add(neighbour);
            }
        }
        //else if (collision.gameObject.CompareTag("Floor"))
        //{
            //VFXController.Instance.spawn_dust_cloud(transform.position);
        //}
    }

    public void make_static()
    {
        _configured = true;
        print("Object is static!");
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = true;

        transform.localScale = _starting_scale;
        transform.position = _starting_pos;
        transform.rotation = _starting_orientation;
    }

    public void cause_damage(float expForce,float expRange )
    {
        is_connected = false;
        _rigidbody.isKinematic = false;
        is_damaged = true;
        _rigidbody.AddExplosionForce(expForce , transform.position, expRange, 1f);
        //VFXController.Instance.spawn_dust_cloud(transform.position);
    }

    public void drop()
    {
        if (!is_dropping){
            print("Object dropping!");
            is_connected = false;
            _rigidbody.isKinematic = false;
            Destroy(this.gameObject,5);
            is_dropping = true;
        }
        
    }
    
}
