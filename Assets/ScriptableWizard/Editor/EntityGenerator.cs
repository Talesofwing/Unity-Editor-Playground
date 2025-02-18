using UnityEngine;
using UnityEditor;

namespace zer0.Editor
{

    public class EntityGenerator : ScriptableWizard
    {
        [SerializeField] private string _name;
        [SerializeField] private int _hp;
        [SerializeField] private int _atk;

        // default values
        private const string DefaultName = "zer0";
        private const int DefaultHp = 1;
        private const int DefaultAtk = 1;

        /// <summary>
        /// It will be called when the window open
        /// </summary>
        private void Awake()
        {
            Debug.Log("Entity Generator awake");

            _name = DefaultName;
            _hp = DefaultHp;
            _atk = DefaultAtk;
        }

        #region ScriptableWizard

        [MenuItem("zer0/ScriptableWizard/Entity Generator")]
        private static void CreateWizard()
        {
            // Title, Create Button Name, Other Button Name
            DisplayWizard<EntityGenerator>("Entity Generator", "Generate", "Reset");
        }

        /// <summary>
        /// On create button click
        /// </summary>
        private void OnWizardCreate()
        {
            GameObject go = new GameObject(_name);
            Entity entity = go.AddComponent<Entity>();
            entity.Init(_name, _hp, _atk);

            Debug.Log($"{_name} is created");
        }

        /// <summary>
        /// On other button click
        /// </summary>
        private void OnWizardOtherButton()
        {
            _name = DefaultName;
            _hp = DefaultHp;
            _atk = DefaultAtk;

            Debug.Log("Reset");
        }

        /// <summary>
        /// On wizard update
        /// </summary>
        private void OnWizardUpdate()
        {
            if (_name == "")
            {
                helpString = "Please input the name";
                isValid = false;
            }
            else
            {
                helpString = "Generate eneity";
                isValid = true;
            }

            _hp = Mathf.Max(0, _hp);
            _atk = Mathf.Max(0, _atk);
        }

    }

    #endregion

}
