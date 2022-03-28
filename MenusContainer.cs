using UnityEngine;

public class MenusContainer : MonoBehaviour
{
    private Menu[] _allMenus;

    public void Awake()
    {
        _allMenus = new Menu[transform.childCount];
        for (int i = 0; i < _allMenus.Length; i++)
        {
            _allMenus[i] = transform.GetChild(i).GetComponent<Menu>();
        }
    }

    public void EnableMenu(Menu menu)
    {
        for (int i = 0; i < _allMenus.Length; i++)
        {
            _allMenus[i].gameObject.SetActive(menu==_allMenus[i]);
        }
    }
}
