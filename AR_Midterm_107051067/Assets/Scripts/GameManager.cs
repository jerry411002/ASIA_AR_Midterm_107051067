
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("維京人")]
    public Transform Meshtint;
    [Header("劍士")]
    public Transform Ekard;
    [Header("虛擬搖桿")]
    public DynamicJoystick joystick;
    [Header("旋轉速度"), Range(0.1f, 20f)]
    public float turn = 1.5f;
    [Header("縮放"), Range(0f, 5f)]
    public float size = 0.3f;
    [Header("維京人動畫元件")]
    public Animator aniMeshtint;
    [Header("劍士動畫元件")]
    public Animator aniEkard;

    private void Start()
    {
        print("開始事件執行中");
    }
    private void Update()
    {
        print("更新事件");
        print(joystick.Vertical);   
        Meshtint.Rotate(0, -joystick.Horizontal * turn, 0);
        Ekard.Rotate(0, -joystick.Horizontal * turn, 0);


        Meshtint.localScale += new Vector3(1, 1, 1) * joystick.Vertical;
        Meshtint.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(Meshtint.localScale.x, 0.5f,3.5f);
        Ekard.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        Ekard.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(Ekard.localScale.x, 0.5f, 3.5f);
    }
    
   public void PlayAnimation(string aniName)
    {
        print(aniName);
        aniMeshtint.SetTrigger(aniName);
        aniEkard.SetTrigger(aniName);
    }


    }
