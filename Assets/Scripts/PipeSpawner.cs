using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace FlappyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        private GameObject pipe;
        [SerializeField]
        private GameObject nightpipe;
        [SerializeField]
        private GameObject daypipe;
        [SerializeField]
        private Transform spawnPoint;

        [Space, SerializeField, Range(-1, 1)]
        private float minHeight;
        [SerializeField, Range(-1, 1)]
        private float maxHeight;

        [Space, SerializeField]
        private float timeToSpawnFirstPipe;
        [SerializeField]
        private float timeToSpawnPipe;

        [SerializeField]
        private int numOfpipes=3;

        [SerializeField]
        List<GameObject> pipePool;

        private void Start()
        {
            
        }

        public void SetPipeTime(bool day)
        {
            if(day)
            {
                pipe = daypipe;
            }
            else
            {
                pipe = nightpipe;
            }
            InitPipes();
            StartCoroutine(SpawnPipes());
        }

        private Vector3 GetNewPosition()
        {
            return new Vector3(spawnPoint.position.x, Random.Range(minHeight, maxHeight), spawnPoint.position.z);
        }

        private void InitPipes()
        {
            for (int i = 0; i < numOfpipes; i++)
            {
                GameObject currentPipe = Instantiate(pipe, GetNewPosition(), Quaternion.identity);
                currentPipe.SetActive(false);
                pipePool.Add(currentPipe);
            }
        }

        private void UpdatePipe()
        {
            foreach (var item in pipePool)
            {
                if(item.activeSelf==false)
                {
                    item.transform.position = GetNewPosition();
                    item.SetActive(true);
                    return;
                }
            }
        }

        private IEnumerator SpawnPipes()
        {
            //yield return new WaitForSeconds(timeToSpawnFirstPipe);

            //Instantiate(pipe, GetNewPosition(), Quaternion.identity);

            do
            {
                yield return new WaitForSeconds(timeToSpawnPipe);

                UpdatePipe();
            } while (true);
        }

        public void Stop()
        {
            StopAllCoroutines();
        }
    }
}