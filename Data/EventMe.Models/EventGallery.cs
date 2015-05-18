namespace EventMe.Models
{
    using System;

    using System.Collections.Generic;

    public class EventGallery
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<GalleryPhoto> Photos { get; set; }
    }
}
