using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Model.Social
{
    public class SocialInteraction<T>
    {
        public SocialInteractionStatusType SocialnteractionStatus { get; set; }
        public T Item { get; set; }

        public override string ToString()
        {
            return SocialnteractionStatus.ToString();
        }
    }
}
