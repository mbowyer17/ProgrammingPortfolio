using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;
public class SceneSelector : EditorWindow
{
    [MenuItem("Scene Selector/Main Menu _g")]
    static void MainMenu()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
    }
    [MenuItem("Scene Selector/Intro Scene _h")]
    static void FirstScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/IntroScene.unity");
    }
    [MenuItem("Scene Selector/Level1 Scene _j")]
    static void SecondScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Level1.unity");
    }
    [MenuItem("Scene Selector/Level2 Scene _k")]
    static void ThirdScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Level2.unity");
    }
    [MenuItem("Scene Selector/Level3 Scene _l")]
    static void FourthScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Level3.unity");
    }
    [MenuItem("Scene Selector/End Scene _;")]
    static void FifthScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/EndScene.unity");
    }
}
