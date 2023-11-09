using UnityEngine;
using TMPro;

public class KeysCounter : MonoBehaviour
{
    public static KeysCounter instance;
    public TMP_Text keyText;
    public int currentKeys;
        
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        keyText.text = currentKeys.ToString();
            
    }
    public void AddKeys(int amount)
    {
        currentKeys += amount;
        keyText.text = currentKeys.ToString();
    }

    public void RemoveKeys(int amount)
    {
        currentKeys -= amount;
        keyText.text = currentKeys.ToString();
    }
}
