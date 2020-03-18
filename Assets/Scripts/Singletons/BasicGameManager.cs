using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singletons
{
    public class BasicGameManager : MonoBehaviour
    {

        private static BasicGameManager _instance = null;

        public static BasicGameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<BasicGameManager>();

                    if (_instance == null)
                    {
                        GameObject go = new GameObject();
                        go.name = "SingletonController";
                        _instance = go.AddComponent<BasicGameManager>();
                        DontDestroyOnLoad(go);
                    }
                }

                return _instance;
            }
        }

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}