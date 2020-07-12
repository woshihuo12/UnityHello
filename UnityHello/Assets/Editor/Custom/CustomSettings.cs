using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using LuaInterface;

using BindType = ToLuaMenu.BindType;
using System.Reflection;

using UnityEngine.EventSystems;

public static class CustomSettings
{
    public static string saveDir = Application.dataPath + "/ToLua/Source/Generate/";
    public static string luaDir = Application.dataPath + "/Lua/";
    public static string toluaBaseType = Application.dataPath + "/ToLua/BaseType/";
    public static string toluaLuaDir = Application.dataPath + "/ToLua/Lua";
    public static string injectionFilesPath = Application.dataPath + "/ToLua/Injection/";

    //导出时强制做为静态类的类型(注意customTypeList 还要添加这个类型才能导出)
    //unity 有些类作为sealed class, 其实完全等价于静态类
    public static List<Type> staticClassTypes = new List<Type>
    {
        typeof(UnityEngine.Application),
        typeof(UnityEngine.Time),
        typeof(UnityEngine.Screen),
        typeof(LuaHelper),
    };

    //附加导出委托类型(在导出委托时, customTypeList 中牵扯的委托类型都会导出， 无需写在这里)
    public static DelegateType[] customDelegateList =
    {
        _DT(typeof(Action)),
        _DT(typeof(UnityEngine.Events.UnityAction)),
        _DT(typeof(System.Predicate<int>)),
        _DT(typeof(System.Action<int>)),
        _DT(typeof(System.Comparison<int>)),
    };

    //在这里添加你要导出注册到lua的类型列表
    public static BindType[] customTypeList =
    {

       _GT(typeof(Debugger)).SetNameSpace(null),

        _GT(typeof(Component)),
        _GT(typeof(Transform)),
        _GT(typeof(Material)),
        _GT(typeof(Light)),
        _GT(typeof(Rigidbody)),
        _GT(typeof(Camera)),
        _GT(typeof(AudioSource)),
        //_GT(typeof(LineRenderer))
        //_GT(typeof(TrailRenderer))
      
        _GT(typeof(Behaviour)),
        _GT(typeof(MonoBehaviour)),
        _GT(typeof(GameObject)),
        _GT(typeof(Application)),
        _GT(typeof(Time)),
        _GT(typeof(Texture)),
        _GT(typeof(Texture2D)),
        _GT(typeof(Shader)),
        _GT(typeof(Renderer)),
        _GT(typeof(Screen)),
        _GT(typeof(CameraClearFlags)),
        _GT(typeof(AudioClip)),
        _GT(typeof(AsyncOperation)).SetBaseType(typeof(System.Object)),
        _GT(typeof(LightType)),
        _GT(typeof(SleepTimeout)),
        _GT(typeof(Animator)),
        _GT(typeof(Input)),
        _GT(typeof(KeyCode)),
        _GT(typeof(Space)),
        _GT(typeof(GraphicRaycaster)),

        _GT(typeof(MeshRenderer)),

        _GT(typeof(BoxCollider)),
        _GT(typeof(MeshCollider)),
        _GT(typeof(SphereCollider)),
        _GT(typeof(CharacterController)),
        _GT(typeof(CapsuleCollider)),

        _GT(typeof(Animation)),
        _GT(typeof(AnimationClip)).SetBaseType(typeof(UnityEngine.Object)),
        _GT(typeof(AnimationState)),
        _GT(typeof(AnimationBlendMode)),
        _GT(typeof(QueueMode)),
        _GT(typeof(PlayMode)),
        _GT(typeof(WrapMode)),

        _GT(typeof(QualitySettings)),
        _GT(typeof(RenderSettings)),
        _GT(typeof(SkinWeights)),
        _GT(typeof(RenderTexture)),

        ////////////////////////////////////////////
        _GT(typeof(Resources)),
        _GT(typeof(Graphic)),
        _GT(typeof(MaskableGraphic)),
        _GT(typeof(Image)),
        _GT(typeof(Text)),
        _GT(typeof(Sprite)),
        _GT(typeof(Toggle)),
        _GT(typeof(ToggleGroup)),
        _GT(typeof(InputField)),
        _GT(typeof(Rect)),
        _GT(typeof(LayoutGroup)),
        _GT(typeof(HorizontalOrVerticalLayoutGroup)),
        _GT(typeof(VerticalLayoutGroup)),
        _GT(typeof(HorizontalLayoutGroup)),
        _GT(typeof(ContentSizeFitter)),

        _GT(typeof(Dropdown)),
        _GT(typeof(Mask)),
        _GT(typeof(RectMask2D)),
        _GT(typeof(LayoutElement)),

        _GT(typeof(Slider)),

        _GT(typeof(Scrollbar)),

        _GT(typeof(RectTransform)),
        _GT(typeof(RectTransformUtility)),

        _GT(typeof(Button)),
        _GT(typeof(Canvas)),

        _GT(typeof(LuaBehaviour)),
        _GT(typeof(UILuaBehaviour)),
        _GT(typeof(GameResFactory)),
        _GT(typeof(UIAtlasMgr)),

        _GT(typeof(ScrollRect)),
        _GT(typeof(LoopScrollRect)),
        _GT(typeof(LoopVerticalScrollRect)),
        _GT(typeof(LoopHorizontalScrollRect)),

        _GT(typeof(Base)),
        _GT(typeof(Manager)),
        _GT(typeof(ByteBuffer)),
        _GT(typeof(NetworkManager)),

        _GT(typeof(LuaHelper)),
        _GT(typeof(Globals)),

        /////////////////////////////////////LeanTween     
        _GT(typeof(LeanTweenType)),
        _GT(typeof(LTBezier)),
        _GT(typeof(LTBezierPath)),
        _GT(typeof(LTEvent)),
        _GT(typeof(LTSpline)),
        _GT(typeof(LeanTween)),
        _GT(typeof(LeanAudio)),
        /////////////////////////////////////LeanTween  end
    };

    public static List<Type> dynamicList = new List<Type>()
    {
    };

    //重载函数，相同参数个数，相同位置out参数匹配出问题时, 需要强制匹配解决
    //使用方法参见例子14
    public static List<Type> outList = new List<Type>()
    {
    };

    public static List<Type> sealedList = new List<Type>()
    {

    };

    public static BindType _GT(Type t)
    {
        return new BindType(t);
    }

    public static DelegateType _DT(Type t)
    {
        return new DelegateType(t);
    }
}
