using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//public class sanityraycasttest : MonoBehaviour

    public class sanityraycasttest : MonoBehaviour
    {
        public float sanity = 100f;  
        public float sanityDecreaseRate = 1f;  

        private bool isMonsterInSight = false;

        public TMP_Text sanitycount;

        public AudioSource halfsanity;
        public AudioSource heartbeat;
        public AudioSource tensanity;
        public AudioSource death;

        private void FixedUpdate()
        {
            RaycastHit hit;
            Vector3 rayDirection = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, rayDirection, out hit, Mathf.Infinity))
            {
                
                if (hit.collider.CompareTag("monster"))
                {
                    Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.red);
                    isMonsterInSight = true;  
                }
                else
                {
                    Debug.DrawRay(transform.position, rayDirection * 8, Color.blue);
                    isMonsterInSight = false; 
                }
            }
            else
            {
                Debug.DrawRay(transform.position, rayDirection * 8, Color.blue);
                isMonsterInSight = false;  
            }

            
            if (isMonsterInSight)
            {
                sanity -= sanityDecreaseRate * Time.deltaTime;
                sanity = Mathf.Clamp(sanity, 0, 100);
                heartbeat.Play();   
            }
        }
        private void Update()
        {
            sanitycount.text = sanity.ToString();

            if (sanity == 50)
            {
                halfsanity.Play();
            }
            if (sanity == 10)
            {
                tensanity.Play();
            }
            if(sanity == 0)
            {
            deathscene();
                death.Play();
            }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="pills" && (Input.GetKey(KeyCode.E)))
        {
            sanity += 10;
            Debug.Log("it works");
        }
        if(sanity == 50)
        {
            halfsanity.Play();
        }
        if (sanity == 10)
        {
            tensanity.Play();
        }

    }
    void deathscene()
    {

    }
}


