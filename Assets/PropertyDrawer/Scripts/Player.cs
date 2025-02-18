using UnityEngine;

namespace zer0
{

    public class Player : MonoBehaviour
    {
        [SerializeField, SetProperty("Name")] private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                _UpdateDate();
            }
        }

        [SerializeField, SetProperty("Hp")] private int _hp;
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                _UpdateDate();
            }
        }

        [SerializeField, SetProperty("Atk")] private int _atk;
        public int Atk
        {
            get => _atk;
            set
            {
                _atk = value;
                _UpdateDate();
            }
        }

        private void _UpdateDate()
        {
            Debug.Log(this);
        }

        public override string ToString()
        {
            return $"Player data updated.\nName: {_name}, Hp: {_hp}, Atk: {_atk}";
        }

    }

}
