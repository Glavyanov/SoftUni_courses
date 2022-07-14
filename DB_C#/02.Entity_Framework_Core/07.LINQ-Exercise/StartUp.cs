namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Task 2.	All Albums Produced by Given Producer
            Console.WriteLine(ExportAlbumsInfo(context, 9));

            //Task 3.	Songs Above Given Duration
            Console.WriteLine(ExportSongsAboveDuration(context, 4));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            var albums = context.Albums
                .Where(a => a.ProducerId.Value == producerId)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        s.Name,
                        s.Price,
                        WriterName = s.Writer.Name
                    }),
                    a.Price
                })
                .ToArray();

            foreach (var album in albums.OrderByDescending(a => a.Price))
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int count = 1;
                foreach (var song in album.Songs.OrderByDescending(s => s.Name).ThenBy(w => w.WriterName))
                {
                    sb.AppendLine($"---#{count++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");

                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");

            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(sp => sp.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(s => s.Producer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    PerformerFullName = s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullName)
                .ToArray();

            var sb = new StringBuilder();
            int count = 1;
            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{count++}");
                sb.AppendLine($"---SongName: {s.Name}");
                sb.AppendLine($"---Writer: {s.WriterName}");
                sb.AppendLine($"---Performer: {s.PerformerFullName}");
                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}");
                sb.AppendLine($"---Duration: {s.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
