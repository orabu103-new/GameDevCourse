using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Mover : MonoBehaviour
    {
        [Tooltip("Movement vector in meters per second")]
        [SerializeField] Vector3 velocity;
        public int speed = 20;

        void Update()
        {
            transform.position += velocity * Time.deltaTime * speed;
        }

    }
