using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }

        [Required(ErrorMessage = "Resim Url Boş bırakılamaz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Başlık Boş bırakılamaz")]
        [MinLength(5, ErrorMessage = "Başlık en az 5 karakter olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama Boş bırakılamaz")]
        [MaxLength(100, ErrorMessage = "Açıklama maksimum 100 karakter olmalıdır.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Video Url Boş bırakılamaz")]
        public string VideoUrl { get; set; }
    }
}