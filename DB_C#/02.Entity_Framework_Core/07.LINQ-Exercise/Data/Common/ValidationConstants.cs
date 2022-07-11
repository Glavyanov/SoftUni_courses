using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.Data.Common
{
    public static class ValidationConstants
    {
        //Song
        public const int SongNameMaxLength = 20;

        //Album
        public const int AlbumNameMaxLength = 40;

        //Performer
        public const int PerformerFirstNamesMaxLength = 20;
        public const int PerformerLastNamesMaxLength = 20;

        //Producer
        public const int ProducerNameMaxLength = 30;

        //Writer
        public const int WriterNameMaxLength = 20;

    }
}
