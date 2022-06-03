using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchMineralsController : MonoBehaviour
{
    [SerializeField] private List<MineralInfo> mineralInfos = new List<MineralInfo>();
    // Start is called before the first frame update
    void Start()
    {
        mineralInfos = FindObjectsOfType<MineralInfo>().ToList() ;

        foreach (var item in mineralInfos)
        {
            if(PlayerPrefs.GetInt("Id") == 0)
            {
                item.SetCircle(true);
            }
            else if (item.ExhibitionID == PlayerPrefs.GetInt("Id"))
            {
                item.SetCircle(true);
            }
            else
            {
                item.SetCircle(false);
            }
        }
    }
}
