using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class BombExplosion : MonoBehaviour
{
    public SoundManager soundManager;
    public float explosionDelay = 2f;
    public Vector3 planeWorldPosition , planeWorldDirection;
    public LayerMask explodableObjects;
    void Start()
    {
        Invoke("Explode" , explosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);
        // creating random planes
        List<Vector3> directions = new List<Vector3>();

        for (int i = 0; i < 5; i++){
            directions.Add(UnityEngine.Random.onUnitSphere);
        }
        //
        foreach (Collider nearby in colliders){
            // MeshDestroy md = nearby.gameObject.GetComponent<MeshDestroy>();
            // if (md != null){
            //     md.DestroyMesh();
            // }
            // Rigidbody rg = nearby.GetComponent<Rigidbody>();

            // if(rg != null){
                // rg.AddExplosionForce(2000f , transform.position, 10f);
            // }
            if (explodableObjects == (explodableObjects | 1<<nearby.gameObject.layer)){

                var nearbyMaterial = nearby.GetComponent<MeshRenderer>().material;
                var position = transform.position;
                int destroyOriginal = 0;

                List<GameObject> originalObjects = new List<GameObject>();
                originalObjects.Add(nearby.gameObject);
                List<GameObject> originalObjectsCopy = new List<GameObject>();
                for (int i = 0; i < 5; i++){
                    originalObjectsCopy.Clear();
                    foreach (GameObject _originalObject in originalObjects){
                        GameObject[] desObjects = _originalObject.SliceInstantiate(position , directions[i] , crossSectionMat: nearbyMaterial);
                        // If plane doesnt slice object , it will be null
                        if (desObjects != null){
                            Destroy(_originalObject);
                            foreach (GameObject _desObject in desObjects){
                                originalObjectsCopy.Add(_desObject);
                                _desObject.GetComponent<MeshRenderer>().material = nearbyMaterial;
                                _desObject.AddComponent<Rigidbody>();
                                MeshCollider _objectCollider = _desObject.AddComponent<MeshCollider>();
                                _objectCollider.convex = true;
                                _desObject.layer = 9;
                                // Structure layer 
                            }
                        }
                    }
                    originalObjects.Clear();
                    foreach(GameObject element in originalObjectsCopy){
                        originalObjects.Add(element);
                    }

                }
                foreach (GameObject _subObject in originalObjects){
                    Rigidbody _subObjectRg = _subObject.GetComponent<Rigidbody>();
                    _subObjectRg.AddExplosionForce(200f , transform.position, 10f);
                }
                // if (destroyOriginal == 0){
                //     Destroy(nearby.gameObject);
                // }
            }

        }
        Destroy(this.gameObject);

    }

    private void OnDestroy() {
        SoundManager.PlaySound3D(SoundLibrary.sfxLibrary3D["bomb_explosion"] , transform.position);
    }
}