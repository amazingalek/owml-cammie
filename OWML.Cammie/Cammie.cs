using System;
using System.IO;
using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace Cammie
{
    public class Cammie : ModBehaviour
    {
        private string _folder;
        private int _size;

        public override void Configure(IModConfig config)
        {
            _size = config.GetSettingsValue<int>("size");
            if (_size < 1)
            {
                _size = 1;
            }
            ModHelper.Console.WriteLine($"Set size to {_size}");
        }

        private void Start()
        {
            _folder = $"{ModHelper.Manifest.ModFolderPath}/Screenshots";

            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                var path = $"{_folder}/Screenshot-{DateTime.Now:yyyy-MM-dd-HH-mm-ss-ffff}.png";
                ModHelper.Console.WriteLine($"Taking screenshot {path}");
                ScreenCapture.CaptureScreenshot(path, _size);
            }
        }
    }
}
