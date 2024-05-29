    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        // Variables públicas para los enemigos
        public GameObject enemy1;
        public GameObject enemy2;

        void Awake()
        {
            // Asegúrate de que este objeto no se destruya al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
        }

        // Métodos para obtener los enemigos
        public GameObject GetEnemy1()
        {
            return enemy1;
        }

        public GameObject GetEnemy2()
        {
            return enemy2;
        }
    }