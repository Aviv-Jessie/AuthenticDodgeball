using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnerBall : MonoBehaviour
{
    [SerializeField] protected KeyCode keyToPress;
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;
    [SerializeField] Transform spawnPosition = null;
    protected ForceMode2D forceMode = ForceMode2D.Impulse;
    private Rigidbody2D rb;

    
    protected virtual GameObject spawnObject() {
        // Step 1: spawn the new object.
        Vector3 positionOfSpawnedObject = spawnPosition.position ;  // span at the containing object position.   (+vector3.right- because the ball touched the player and apply the spawmner)
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // we need to make here RigidBody that changes the Velocity of 
        rb = newObject.GetComponent<Rigidbody2D>();
        rb.AddForce(velocityOfSpawnedObject, forceMode);

        return newObject;
    }

    private void Update() {
        if (Input.GetKeyDown(keyToPress)) {
            spawnObject();
        }
    }

}
