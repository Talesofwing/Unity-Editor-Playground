using UnityEngine;

namespace zer0
{

    public class Entity : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private int _hp;
        [SerializeField] private int _atk;

        public void Init(string name, int hp, int atk)
        {
            _name = name;
            _hp = hp;
            _atk = atk;
        }

    }

}
