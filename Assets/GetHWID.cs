using UnityEngine;

public class GetHWID : MonoBehaviour
{
    void Start()
    {
        try
        {
            string[] args = System.Environment.GetCommandLineArgs();
            Debug.Log(System.Environment.CommandLine);
            //"EAM GetClientHWID.exe" -nographics -batchmode {C:\Users\Maik8\Documents\Unity\EAM GetClientHWID\Build}
            Debug.Log($"{System.Environment.NewLine}HWID: {SystemInfo.deviceUniqueIdentifier}{System.Environment.NewLine}");

            string dir = System.IO.Path.GetFullPath(".");
            //string t = "\"EAM GetClientHWID.exe\" - nographics - batchmode {C:\\Users\\Maik8\\Documents\\Unity\\EAM GetClientHWID\\Build\\asd}";
            //if (!string.IsNullOrWhiteSpace(t) && t.Contains("{") && t.Contains("}"))
            if (!string.IsNullOrWhiteSpace(System.Environment.CommandLine) && System.Environment.CommandLine.Contains("{") && System.Environment.CommandLine.Contains("}"))
            {
                //dir = t.Substring(t.IndexOf("{") + 1, (t.IndexOf("}") - 1) - t.IndexOf("{"));
                dir = System.Environment.CommandLine.Substring(System.Environment.CommandLine.IndexOf("{") + 1, (System.Environment.CommandLine.IndexOf("}") - 1)- System.Environment.CommandLine.IndexOf("{"));
            }
            Debug.Log($"|{dir}|");

            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "EAM.HWID"), SystemInfo.deviceUniqueIdentifier);
            
        }
        catch (System.Exception e)
        {
            Debug.LogError($"FAILED TO GET OR SAVE HWID! {System.Environment.NewLine}StackTrace:{System.Environment.NewLine}{e.StackTrace}");
        }

        Application.Quit();
    }
}
