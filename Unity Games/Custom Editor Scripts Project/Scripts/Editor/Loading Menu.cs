using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class LoadingMenu : EditorWindow
{

    GameObject planePrefab, unit2Prefab, unit1Prefab;
    string[] sceneFile;
    private bool unit1ButtonPressed, unit2ButtonPressed, player3ButtonPressed;

    [MenuItem("My Menu/Map Editor %g")]
    static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(LoadingMenu));

    }

    [MenuItem("My Menu/Open Scenes/Scene 1 %h")]
    static void FirstScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity");
    }
    [MenuItem("My Menu/Open Scenes/Scene 2 %j")]
    static void SecondScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/TerrainSceen.unity");
    }

    public void OnEnable()
    {

        VisualTreeAsset uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Editor/MapEditorMain.uxml");

        VisualElement ui = uiAsset.CloneTree();

        StyleSheet style = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/Editor/MapEditorStyles.uss");

        ui.styleSheets.Add(style);
        rootVisualElement.Add(ui);

        SetupButtons();

        SceneView.duringSceneGui += OnScene; // Adds function to GUi

    }

    private void SetupButtons()
    {

        string[] prefabFile = Directory.GetFiles("Assets/Resources/Prefab", "*.prefab");

        byte[] bytes;

        if (prefabFile.Length <= 2)
        {
            
            foreach (string prefab in prefabFile)
            {

                var unitPrefabTexture = AssetDatabase.LoadAssetAtPath(prefab, typeof(GameObject)) as GameObject;
                var texture = AssetPreview.GetAssetPreview(unitPrefabTexture);
                bytes = ImageConversion.EncodeToPNG(texture);
                if (bytes != null)
                {
                    File.WriteAllBytes(Application.dataPath + "/Textures/Players/" + unitPrefabTexture.name + "texture.png", bytes);
              
                }
                else if (bytes == null)
                {
                   
                    File.Delete("Assets/Textures/Players/" + unitPrefabTexture.name + "texture.png");

                    File.WriteAllBytes(Application.dataPath + "/Textures/Players/" + unitPrefabTexture.name + "texture.png", bytes);
                }


            }

        }

        Button unitOneButton = rootVisualElement.Q<Button>("Unit1Button");
       
        Button unitTwoButton = rootVisualElement.Q<Button>("Unit2Button");
      
        unitOneButton.clickable.clicked += () =>
        {

            unit2ButtonPressed = false;
            unit1ButtonPressed = true;
            unitOneButton.style.backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Textures/Players/Unit1texture.png");



        };
        unitTwoButton.clickable.clicked += () =>
        {

            unit1ButtonPressed = false;
            unit2ButtonPressed = true;
            unitTwoButton.style.backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Textures/Players/Unit2texture.png");

        };

        Button SpawnMapButton = rootVisualElement.Q<Button>("SpawnMapButton");

        SpawnMapButton.clickable.clicked += () =>
        {
            SpawnMap();
        
        };
    }
    void OnScene(SceneView scene)
    {
        Event e = Event.current;
        if (e.type == EventType.MouseDown && e.button == 2)
        {
            Vector3 mousePos = e.mousePosition;
            float pixelPoint = EditorGUIUtility.pixelsPerPoint;
            mousePos.y = scene.camera.pixelHeight - mousePos.y * pixelPoint;
            mousePos.x *= pixelPoint;

            Ray ray = scene.camera.ScreenPointToRay(mousePos);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {


                if (unit1ButtonPressed)
                {
                    UnitObject(hit, "Unit1.prefab", unit1Prefab);
             
                }
                if (unit2ButtonPressed)
                {
                    UnitObject(hit, "Unit2.prefab", unit2Prefab);
                }
                

            }
            e.Use();
        }
    }

    void UnitObject(RaycastHit point, string filename, GameObject spawnObject)
    {
        BaseField<float> speedInt = rootVisualElement.Q<BaseField<float>>("Speed");
        BaseField<float> accelerationInt = rootVisualElement.Q<BaseField<float>>("Acceleration");
        BaseSlider<float> angularSpeedInt = rootVisualElement.Q<BaseSlider<float>>("AngularSpeedSlider");


        string[] prefabFile = Directory.GetFiles("Assets/Resources/Prefab", filename);


        foreach (string prefab in prefabFile)
        {
            spawnObject = AssetDatabase.LoadAssetAtPath(prefab, typeof(GameObject)) as GameObject;

        }
        spawnObject.transform.position = point.point + point.normal;
        var navAgent = spawnObject.GetComponent<NavMeshAgent>();
        navAgent.speed = speedInt.value;
        navAgent.acceleration = accelerationInt.value;
        navAgent.angularSpeed = angularSpeedInt.value;



        PrefabUtility.InstantiatePrefab(spawnObject as GameObject);



    }

    private void SpawnMap()
    {


        BaseField<int> xAxis = rootVisualElement.Q<BaseField<int>>("XAxis");
        BaseField<int> zAxis = rootVisualElement.Q<BaseField<int>>("ZAxis");


        string[] prefabFile = Directory.GetFiles("Assets/Resources/Prefab/Buildings", "Plane.prefab");


        foreach (string prefab in prefabFile)
        {
            planePrefab = AssetDatabase.LoadAssetAtPath(prefab, typeof(GameObject)) as GameObject;

        }

        Debug.Log(xAxis.value);

        planePrefab.transform.localScale = new Vector3((float)xAxis.value, 1, (float)zAxis.value);
        PrefabUtility.InstantiatePrefab(planePrefab as GameObject);

        xAxis.value = xAxis.value;
        zAxis.value = zAxis.value;




    }
}

