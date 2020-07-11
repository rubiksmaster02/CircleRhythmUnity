using System.IO;
using Beatmaps;
using Inflex.Rron;
using Logic.InGameEditor;
using UnityEngine;

namespace Ui.InGameEditor
{
    public class SaveButton : MouseNavigationControl
    {
        private readonly BeatMap beatMap = EditorInitializer.BeatMap;
        [SerializeField] private GameObject editorHolder;

        protected override void LeftClick()
        {
            string path = Path.Combine(GenericPaths.BeatMapsPath, this.beatMap.Title);
            Directory.CreateDirectory(path);
            this.CopyFiles(path);
            this.RenamePaths(path);
            this.SaveNewBeatMap();
            this.editorHolder.SetActive(false);
            this.gameObject.GetComponent<EditorConstructor>().Fill(this.beatMap);
        }

        private void CopyFiles(string path)
        {
            File.Copy(this.beatMap.SongFile, Path.Combine(path, Path.GetFileName(this.beatMap.SongFile)));
            File.Copy(this.beatMap.Background, Path.Combine(path, Path.GetFileName(this.beatMap.Background)));
        }

        private void RenamePaths(string path)
        {
            this.beatMap.SongFile = Path.GetFileName(this.beatMap.SongFile);
            this.beatMap.Background = Path.GetFileName(this.beatMap.Background);
            this.beatMap.Icon = this.beatMap.Background;
            this.beatMap.Path = Path.Combine(GenericPaths.BeatMapsPath, this.beatMap.Title, Path.Combine(path, "data.rron"));
        }

        private void SaveNewBeatMap() =>
            RronConvert.SerializeObjectToFile(this.beatMap, this.beatMap.Path, new[] {nameof(BeatMap.Id), nameof(BeatMap.Path)});
    }
}