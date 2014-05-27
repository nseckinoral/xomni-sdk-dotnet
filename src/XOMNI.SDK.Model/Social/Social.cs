using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Social
{
    public abstract class SocialContent
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string AuthorPictureUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int RelatedItemId { get; set; }
        public List<SocialInteractionStatus> AvailablePlatforms { get; set; }
    }
}
