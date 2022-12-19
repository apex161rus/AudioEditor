using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class EmumEditor 
{
    public static void WriteTofail(string name,string path)
    {
        List<string> tracks = File.ReadAllLines(path).ToList();

        for (int i = 0; i < tracks.Count; i++)
        {
            if (tracks[i] ==  "}")
            {
                name = name.Replace(" ", "");
                var firstCharter = char.ToUpper(name[0]).ToString();
                name = firstCharter + (name.Length >= 2 ? name.Substring(1) : "");
                tracks.Insert(i,"\t" + name + ",");
                break;
            }
        }
        File.WriteAllLines(path, tracks, Encoding.Default);
    }

    //public static bool TryRemuveFromFile(string name, string path)
    //{
    //    List<string> tracks = File.ReadAllLines(path).ToList();
    //    for (int i = 0; i < tracks.Count; i++)
    //    {
    //        if (tracks[i].Contains(name))
    //        {
    //            tracks.RemoveAt(i);
    //            File.WriteAllLines(path, tracks, Encoding.Default);
    //            return true;
    //        }
    //    }
    //    return false;
    //}
}
