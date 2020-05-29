using System;
using System.Collections.Generic;
using System.IO;

namespace CapitaExam
{
    public class LoadListFromTextFileAndRemoveDuplicateElementFromStringList
    {
        /// <summary>
        /// Remove Duplicate Element From String List
        /// </summary>
        public void RemoveDuplicateElement()
        {
            List<string> features = new List<string>(File.ReadAllLines(@"Files\Features.txt"));
            List<string> featureToDelete = new List<string>(File.ReadAllLines(@"Files\FeaturesToDelete.txt"));
            foreach (var deletestring in featureToDelete)
            {
                var listIndex = features.FindIndex(c => c.Contains(deletestring));
                features.RemoveAt(listIndex);
            }
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExpectedOutPut.txt")))
            {
                foreach (var line in features)
                    outputFile.WriteLine(line);

                outputFile.Dispose();
                outputFile.Close();
            }
        }
    }
}
