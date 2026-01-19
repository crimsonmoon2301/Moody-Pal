using kursadarbs_reactiveUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace kursadarbs_reactiveUI.Services
{
    public static class JournalFileService
    {
        private static string _jsonFileName =
        Path.Combine(AppContext.BaseDirectory, "MyJournal.json");

        /// <summary>
        /// Stores the given items into a file on disc
        /// </summary>
        /// <param name="itemsToSave">The items to save</param>
        public static async Task SaveToFileAsync(IEnumerable<JournalItem> itemsToSave)
        {
            // Ensure all directories exists
            Directory.CreateDirectory(Path.GetDirectoryName(_jsonFileName)!);

            // We use a FileStream to write all items to disc
            using (var fs = File.Create(_jsonFileName))
            {
                await JsonSerializer.SerializeAsync(fs, itemsToSave, new JsonSerializerOptions { WriteIndented = true });
                await fs.FlushAsync();
            }
        }

        /// <summary>
        /// Loads the file from disc and returns the items stored inside
        /// </summary>
        /// <returns>An IEnumerable of items loaded or null in case the file was not found</returns>
        public static async Task<IEnumerable<JournalItem>?> LoadFromFileAsync()
        {
            try
            {
                // We try to read the saved file and return the Journal items if successful
                using (var fs = File.OpenRead(_jsonFileName))
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<JournalItem>>(fs);
                }
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                // In case the file was not found, we simply return null
                return null;
            }
        }
    }
}
