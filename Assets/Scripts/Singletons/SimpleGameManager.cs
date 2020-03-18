using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singletons
{
    public class SimpleGameManager : MonoBehaviour
    {
        /*
     *
     * Example Usage
         SimpleGameManager.Instance.Score = 100;
     */
        public static SimpleGameManager Instance;
        public string Name { get; set; }
        private int _score = 0;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}