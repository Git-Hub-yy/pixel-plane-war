using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

/// <summary>
/// 构建 Windows 播放器（供自动化打包使用）。
/// Unity.exe -batchmode -quit -projectPath ... -executeMethod BuildWin.Run
/// </summary>
public static class BuildWin
{
    private const string OutPath = @"D:\unity\build\pixelplanewar\PixelPlaneWar.exe";

    public static void Run()
    {
        var scenes = new System.Collections.Generic.List<string>();
        foreach (var s in EditorBuildSettings.scenes)
        {
            if (s.enabled) scenes.Add(s.path);
        }
        if (scenes.Count == 0)
        {
            Debug.LogError("BuildWin: EditorBuildSettings 里没有启用的场景");
            EditorApplication.Exit(1);
            return;
        }

        var options = new BuildPlayerOptions
        {
            scenes = scenes.ToArray(),
            locationPathName = OutPath,
            target = BuildTarget.StandaloneWindows64,
            options = BuildOptions.None
        };

        var report = BuildPipeline.BuildPlayer(options);
        var summary = report.summary;
        Debug.Log($"BUILD RESULT: {summary.result}, errors={summary.totalErrors}, size={summary.totalSize / (1024 * 1024)} MB, scenes={scenes.Count}");
        EditorApplication.Exit(summary.result == BuildResult.Succeeded ? 0 : 1);
    }
}