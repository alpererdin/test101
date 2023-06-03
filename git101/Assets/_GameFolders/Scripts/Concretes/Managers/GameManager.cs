using Abstracts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{

   public class GameManager : Singleton<GameManager>
    {
        void Awake()
        {
            SingletonThisObject(this);
        }

        void Start()
        {
        
        }

  
    }
}