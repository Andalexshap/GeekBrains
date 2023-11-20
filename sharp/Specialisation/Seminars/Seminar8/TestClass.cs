namespace Seminar8
{
    internal class TestClass
    {
        public void CopyFile(string path, string fileName)
        {
            File.Copy(path, fileName);
        }

        public void MyCopyFile(string path, string targetFileName, string copyFileName)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден!");
            }
            else
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    //using (StreamWriter sw = new StreamWriter(sr))
                }
            }
        }
    }
}
