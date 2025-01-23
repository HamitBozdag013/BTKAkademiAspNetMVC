namespace BtkAkademi.Models
{
    public static class Repository
    {
        // private static List<Candidate> candidates = new List<Candidate>();
        private static List<Candidate> applications = new();  //Artık üstteki yerine bu şekilde de tanımlanabiliyor.
        public static IEnumerable<Candidate> Aplications => applications;
        public static void Add(Candidate candidate)
        {
            applications.Add(candidate);
        }
    }
}