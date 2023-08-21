using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private float timeToDestroyPipe;

        private void OnEnable()
        {
            StartCoroutine(ResetPipe());
        }

        private void Update()
        {
            if (GameManager.Instance.isGameOver || !gameObject.activeSelf)
                return;

            transform.position += (Vector3.left * Time.deltaTime * speed);
        }

        private IEnumerator ResetPipe()
        {
            yield return new WaitForSeconds(timeToDestroyPipe);
            transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}