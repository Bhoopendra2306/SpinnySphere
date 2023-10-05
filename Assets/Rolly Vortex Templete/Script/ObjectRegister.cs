
using UnityEngine;
public class ObjectRegister : MonoBehaviour
{
    void Start()
    {
        RegisterObj("Cube");
        RegisterObj("Tube");
        RegisterObj("BallFx");
        RegisterObj("ScoreText");
        RegisterObj("Coin");
    }

    void RegisterObj(string name)
    {
        Object[] objects = Resources.LoadAll(name, typeof(GameObject));
        foreach (var temp in objects)
        {
            ObjectPoolManager.instance.RegisterPool(temp.name, (GameObject)temp);
        }
    }
}
