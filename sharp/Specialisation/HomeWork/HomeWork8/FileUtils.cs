namespace HomeWork8
{
    internal class FileUtils
    {
        private string MainDirectory { get; set; } = @"D:\";
        private string FileExtension { get; set; } = "";
        private string TargetWorld { get; set; } = "";
        private IEnumerable<string> FindResult { get; set; } = new List<string>();

        public void SetMainDirectory(string path)
            => MainDirectory = path;
        public void SetFileWxtension(string extension)
            => FileExtension = extension;
        public void SetTargetWorld(string world)
            => TargetWorld = world;

        public void FindAllFiles()
        {

        }



    }
}
