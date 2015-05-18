namespace EventMe.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GalleryPhotos")]
    public class GalleryPhoto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public DateTime Date { get; set; }

        public int EventGalleryId { get; set; }

        public virtual EventGallery EventGallery { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}
