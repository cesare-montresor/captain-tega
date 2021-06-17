using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Ship_Scr : MonoBehaviour {
    public GameState_Scr gameState;
    public float hitMultiplier;
    
    void OnCollisionEnter(Collision coll) {
        if (!(coll.gameObject.CompareTag("Player")))
        {
            gameState.health = Math.Max(0, gameState.health - coll.relativeVelocity.magnitude * hitMultiplier);

            DropContainers(gameState.health);
        }
       
    }

    private int initialContainersCount;

    void Start() {
        initialContainersCount = ContainersLeft();
        ShuffleContainers();
    }

    public Transform containersParent;
    
    int ContainersLeft() {
        return containersParent.transform.childCount;
    }

    public GameObject droppersParent;
    
    void DropContainers(float health) {
        var targetCount = (int)(initialContainersCount * health / 100);
        var dropCount = Math.Max(0, initialContainersCount - targetCount); 
        
        Debug.Log($"initial: {initialContainersCount} target: {targetCount} drop: {dropCount}");
        
        for (var i = 0; i < dropCount; i++) {
            var container = containersParent.GetChild(0);

            container.parent = null;
            Destroy(container.gameObject);
        }

        for (var i = 0; i < droppersParent.transform.childCount; i++) {
            droppersParent.transform.GetChild(i).GetComponent<ParticleSystem>().Play();
        }
    }

    void ShuffleContainers() {
        var containers = containersParent.transform.GetComponentsInChildren<Transform>().ToList();

        var rand = new Random();
        containers.Sort((t1, t2) => rand.Next());
        
        containers.Sort((t1, t2) => {
            if (t1.localPosition.y > t2.localPosition.y) return -1;
            if (t1.localPosition.y < t2.localPosition.y) return 1;

            if (Math.Abs(t1.localPosition.x) > Math.Abs(t2.localPosition.x)) return -1;
            if (Math.Abs(t1.localPosition.x) < Math.Abs(t2.localPosition.x)) return 1;
            
            return 0;
        });

        for (var i = 0; i < containers.Count; i++) {
            containers[i].SetSiblingIndex(i);
        }
    }
}
