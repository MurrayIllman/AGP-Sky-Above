using UnityEngine;
using System.Collections;
using UnityEditor;
	
[CustomEditor (typeof(Water))]			
public class WaterEditor : Editor 
{
	Water waterObject;
	static bool bOnce = true;
	void OnEnable () 
	{ 
		waterObject = (Water)target;
		/////////Tag Manager ////////////////////////////////////////
		if (bOnce) 
		{
			SerializedObject tagManager = new SerializedObject (AssetDatabase.LoadAllAssetsAtPath ("ProjectSettings/TagManager.asset") [0]);

			SerializedProperty layerProp = tagManager.FindProperty("layers");

			for(int i = 8; i <= 29; i++)
			{
				SerializedProperty sp0 = layerProp.GetArrayElementAtIndex (i);
				SerializedProperty sp1 = layerProp.GetArrayElementAtIndex (i+1);
				SerializedProperty sp2 = layerProp.GetArrayElementAtIndex (i+2);
				if(sp0.stringValue.Equals("WaterReflNRefrObjects") && sp1.stringValue.Equals("WaterReflObjects") && sp2.stringValue.Equals("WaterRefrObjects"))
				{
					break;
				}
				if(sp0 != null && sp1 != null && sp2 != null)
				{
					if(sp0.stringValue.Trim().Length == 0 && sp1.stringValue.Trim().Length == 0 && sp2.stringValue.Trim().Length == 0)
					{
						sp0.stringValue = "WaterReflNRefrObjects";
						sp1.stringValue = "WaterReflObjects";
						sp2.stringValue = "WaterRefrObjects";
						break;
					}
				}
			}

			tagManager.ApplyModifiedProperties ();

			bOnce = false;
		}
			
	}

	public override void OnInspectorGUI() 
	{
		
		// Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
		//serializedObject.Update ();
		//waterObject.Ocean = !waterObject.WaterArea;
		EditorGUILayout.Space();
		waterObject.SceneCamera = (Camera)EditorGUILayout.ObjectField ("MainCamera", waterObject.SceneCamera, typeof(Camera), true);
		EditorGUILayout.Space();
		waterObject.SunLight = (GameObject)EditorGUILayout.ObjectField ("Sun Light", waterObject.SunLight, typeof(GameObject), true);
		EditorGUILayout.Space();
		waterObject.Ocean = EditorGUILayout.Toggle ("Ocean", waterObject.Ocean);

		//EditorGUI.BeginDisabledGroup (waterObject.Ocean == false);

		//EditorGUI.EndDisabledGroup();

		/*waterObject.WaterArea = !waterObject.Ocean;
			waterObject.WaterArea = EditorGUILayout.Toggle ("WaterArea", waterObject.WaterArea);

			EditorGUI.BeginDisabledGroup (waterObject.WaterArea == false);
			waterObject.Length = EditorGUILayout.FloatField ("Water Area Length", waterObject.Length);
			waterObject.Width = EditorGUILayout.FloatField ("Water Area Width", waterObject.Width);
			EditorGUI.EndDisabledGroup();
			*/

		EditorGUILayout.Space();
		waterObject.DefaultWaterColor = EditorGUILayout.Toggle ("DefaultWaterColor", waterObject.DefaultWaterColor);

		EditorGUI.BeginDisabledGroup (waterObject.DefaultWaterColor == true);
		waterObject.WaterColor = EditorGUILayout.ColorField ("        Water Color", waterObject.WaterColor);
		EditorGUI.EndDisabledGroup();

		if (waterObject.DefaultWaterColor == true) 
		{
			waterObject.WaterColor = new Color (4.0f/255, 55.0f/255, 83.0f/255, 0.0f);
		}



		EditorGUILayout.Space();
		waterObject.ShadowReceive = EditorGUILayout.Toggle ("ShadowReceive", waterObject.ShadowReceive);
		EditorGUILayout.Space();
		waterObject.ObjectReflection = EditorGUILayout.Toggle ("ObjectReflection", waterObject.ObjectReflection);
		EditorGUILayout.Space();
		waterObject.ObjectRefraction = EditorGUILayout.Toggle ("ObjectRefraction", waterObject.ObjectRefraction);
		EditorGUILayout.Space();

		waterObject.SkyReflection = EditorGUILayout.Toggle ("EnvironmentReflection", waterObject.SkyReflection);

		EditorGUI.BeginDisabledGroup (waterObject.SkyReflection == false);
		waterObject.DefaultSkyReflection = !waterObject.CustomSkyColor;
		waterObject.DefaultSkyReflection = EditorGUILayout.Toggle ("        DefaultSkyReflection", waterObject.DefaultSkyReflection);
		waterObject.CustomSkyColor = !waterObject.DefaultSkyReflection;
		waterObject.CustomSkyColor = EditorGUILayout.Toggle ("        CustomSkyColor", waterObject.CustomSkyColor);

		if (waterObject.CustomSkyColor == true) {
			waterObject.SkyColor = EditorGUILayout.ColorField ("           SkyColor", waterObject.SkyColor);
		}
		EditorGUI.EndDisabledGroup ();

		EditorGUILayout.Space();
		//waterObject.SunColor = EditorGUILayout.ColorField ("SunColor", waterObject.SunColor);

		waterObject.DefaultSunColor = EditorGUILayout.Toggle ("DefaultSunColor", waterObject.DefaultSunColor);
		
		EditorGUI.BeginDisabledGroup (waterObject.DefaultSunColor == true);
		waterObject.SunColor = EditorGUILayout.ColorField ("        Sun Color", waterObject.SunColor);
		EditorGUI.EndDisabledGroup();
		
		if (waterObject.DefaultSunColor == true) 
		{
			waterObject.SunColor = new Color (0.89f, 0.73f, 0.56f, 0.0f);
		}

		EditorUtility.SetDirty (target);

	}

}

