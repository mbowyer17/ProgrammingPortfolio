using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Inventory))]
public class CustomInventoryInspector : Editor
{
    Texture2D armorTex, healthTex, flagTex;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Inventory inv = (Inventory)target;

        armorTex = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Textures/GUITextures/Armor.png");
        healthTex = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Textures/GUITextures/Heart.png");
        flagTex = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Textures/GUITextures/Flag.png");

        GUILayout.BeginHorizontal();
        GUILayout.Label("Has flag: " + inv.flag.ToString() );
        if (GUILayout.Button(flagTex, GUILayout.Height(40f), GUILayout.Width(40F)))
        {
            inv.flag = !inv.flag;
            
        }
        GUILayout.EndHorizontal();
        //        inv.health = EditorGUILayout.IntSlider("Health", inv.health, 0, 100);
        
        inv.health = EditorGUILayout.IntSlider("Health", inv.health, 0, 100);
        
        //ValueBar(inv.health / 100.0f, "Health");



        GUILayout.BeginHorizontal();

        inv.armor = EditorGUILayout.IntField("Armor", inv.armor);

        if (GUILayout.Button(armorTex, GUILayout.Width(60f), GUILayout.Height(60f)))
        {
            inv.armor += 5;

        }
        GUILayout.Label("+5 Armor");
        GUILayout.EndHorizontal();



        if (GUILayout.Button("Add Weapon Component"))
        {
            inv.gameObject.AddComponent<WeaponScript>();
        }


    }
}
