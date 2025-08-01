using System.Collections; 

using System.Collections.Generic; 

using UnityEngine; 

using UnityEngine.SceneManagement; 

 

// CREATE CANVAS - ADD VIDEO 

 

 

public class Intro : MonoBehaviour 

{ 

    public float waitTime = 6f; 

 

    void Start() 

    { 

        StartCoroutine(WaitForIntro()); 

    } 

 

    IEnumerator WaitForIntro() 

    { 

        yield return new WaitForSeconds(waitTime); 

        SceneManager.LoadScene(1); 

         

    } 

} 