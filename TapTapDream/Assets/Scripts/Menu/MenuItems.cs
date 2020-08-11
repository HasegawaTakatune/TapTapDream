using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class MenuItems : MonoBehaviour
    {
        [SerializeField] GameObject Configuration = default;
        [SerializeField] GameObject SelectMap = default;
        [SerializeField] GameObject Status = default;       

        public void OnClickStoryButton()
        {

        }

        public void OnClickStatusButton()
        {

        }

        public void OnClickConfigButton()
        {
            bool flg = Configuration.activeSelf;
            Configuration.SetActive(!flg);
        }

        public void OnClickBackgroundPanel()
        {
            Configuration.SetActive(false);
        }
    }
}