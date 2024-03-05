using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT;

public class GameController : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitializeBeforeSceneLoad()
    {
        ServiceLocator.Initialize();

        ServiceLocator.Current.Register<DataService>(new DataService());
    }
}
