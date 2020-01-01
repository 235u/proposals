using System.Collections.Generic;

namespace WotApi.Models
{
    public sealed class ClanList
    {
        public Status Status { get; set; }

        public Meta Meta { get; set; }

        public IList<Clan> Data { get; set; }
    }
}
