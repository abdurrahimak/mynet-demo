using System.Collections.Generic;
using UnityEngine;

namespace MynetDemo.Game
{
    [CreateAssetMenu(fileName = "PoolData.asset", menuName = "Mynet Demo / Create Pool Data")]
    public class PoolData : ScriptableObject
    {
        [SerializeField] public List<Pool> Pools;
    }
}
