using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] bool toggleBool = false;
    [SerializeField] private int ged;

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayModeScene()
    {
        SceneManager.LoadScene("PlayMode");
    }
    public void UVPerlinScene()
    {
        
        if (toggleBool == true)
        {
            print("True");
            SceneManager.LoadScene("63VertsOccul");
        }

        if (toggleBool == false)
        {
            print("false");
            SceneManager.LoadScene("63Verts");
        }
    }
    public void UVPerlinOneScene()
    {
        SceneManager.LoadScene("63Verts");
    }
    public void UVPerlinTwoScene()
    {
        SceneManager.LoadScene("127Verts");
    }
    public void UVPerlinThreeScene()
    {
        SceneManager.LoadScene("255Verts");
    }
    
    
    public void UVPerlinOcculOneScene()
    {
        SceneManager.LoadScene("63VertsOccul");
    }
    public void UVPerlinOcculTwoScene()
    {
        SceneManager.LoadScene("127VertsOccul");
    }
    public void UVPerlinOcculThreeScene()
    {
        SceneManager.LoadScene("255VertsOccul");
    }

    public void UVVoroni()
    {
        if (toggleBool == true)
        {
            print("True");
            SceneManager.LoadScene("63VertsVoroniOccul");
        }

        if (toggleBool == false)
        {
            print("false");
            SceneManager.LoadScene("63Voronoi");
        }
    }
    public void UVVoronoiOneScene()
    {
        SceneManager.LoadScene("63Voronoi");
    }
    public void UVVoronoiTwoScene()
    {
        SceneManager.LoadScene("127Voronoi");
    }
    public void UVVoronoiThreeScene()
    {
        SceneManager.LoadScene("255Voronoi");
    }
    
    public void UVVoronoiOcculOneScene()
    {
        SceneManager.LoadScene("63VertsVoroniOccul");
    }
    public void UVVoronoiOcculTwoScene()
    {
        SceneManager.LoadScene("127VertsVoroniOccul");
    }
    public void UVVoronoiOcculThreeScene()
    {
        SceneManager.LoadScene("255VertsVoroniOccul");
    }

    public void IscosPerlin()
    {
        if (toggleBool == true)
        {
            print("True");
            SceneManager.LoadScene("OccullNoise3Sub");
        }

        if (toggleBool == false)
        {
            print("false");
            SceneManager.LoadScene("Noise3Sub");
        }
    }

    public void IscosPerlinOne()
    {
        SceneManager.LoadScene("Noise3Sub");
    }
    public void IscosPerlinTwo()
    {
        SceneManager.LoadScene("Noise4Sub");
    }
    public void IscosPerlinThree()
    {
        SceneManager.LoadScene("Noise5Sub");
    }
    
    
    public void IscosPerlinOcculOne()
    {
        SceneManager.LoadScene("OccullNoise3Sub");
    }
    public void IscosPerlinOcculTwo()
    {
        SceneManager.LoadScene("OccullNoise4Sub");
    }
    public void IscosPerlinOcculThree()
    {
        SceneManager.LoadScene("OccullNoise5Sub");
    }
    
    public void IscosVoronoi()
    {
        if (toggleBool == true)
        {
            print("True");
            SceneManager.LoadScene("Occull3Sub");
        }

        if (toggleBool == false)
        {
            print("false");
            SceneManager.LoadScene("3Sub");
        }
    }
    public void IscosVoronoiOne()
    {
        SceneManager.LoadScene("3Sub");
    }
    public void IscosVoronoiTwo()
    {
        SceneManager.LoadScene("4Sub");
    }
    public void IscosVoronoiThree()
    {
        SceneManager.LoadScene("5Sub");
    }
    
    public void IscosVoronoiOcculOne()
    {
        SceneManager.LoadScene("Occull3Sub");
    }
    public void IscosVoronoiOcculTwo()
    {
        SceneManager.LoadScene("Occull4Sub");
    }
    public void IscosVoronoiOcculThree()
    {
        SceneManager.LoadScene("Occull5Sub");
    }
    public void ToggleBtn()
    {
        toggleBool = !toggleBool;
        
    }
  
}
