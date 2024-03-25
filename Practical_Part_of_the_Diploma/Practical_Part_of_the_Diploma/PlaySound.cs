using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Practical_Part_of_the_Diploma
{
    internal class PlaySound
    {
        public static void OnPlaySoundClick(object sender, EventArgs a, string filePath, float volume, int number)
        {
            try
            {
                using (var audioFile = new Mp3FileReader(filePath))
                {
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);

                        outputDevice.Volume = volume;

                        outputDevice.Play();

                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(number);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при відтворенні звуку: {ex.Message}");
            }
        }
    }
}