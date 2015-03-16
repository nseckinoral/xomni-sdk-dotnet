using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.Management;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Model.Youtube;

namespace XOMNI.SDK.Private.Youtube
{
    public class YoutubeManagement : ManagementBase
    {
        private readonly ApiAccess.Youtube.Youtube youtubeApi;

        public YoutubeManagement()
        {
            youtubeApi = new ApiAccess.Youtube.Youtube();
        }

        public Task<List<Channel>> SearchChannelsAsync(string channelName, int skip, int take)
        {
            return youtubeApi.SearchChannelsAsync(channelName, skip, take, this.ApiCredential);
        }

        public Task<List<Video>> GetVideosInChannelAsync(string channelId, int skip, int take)
        {
            return youtubeApi.GetVideosInChannelAsync(channelId, skip, take, this.ApiCredential);
        }

        public Task<List<Playlist>> GetPlaylistsInChannelAsync(string channelId, int skip, int take)
        {
            return youtubeApi.GetPlaylistsInChannelAsync(channelId, skip, take, this.ApiCredential);
        }

        public Task<List<Video>> GetVideosInPlaylistAsync(string playlistId, int skip, int take)
        {
            return youtubeApi.GetVideosInPlaylistAsync(playlistId, skip, take, this.ApiCredential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int itemId, YoutubeAssetRelation relation)
        {
            return youtubeApi.RelateVideoAsync(itemId, relation, this.ApiCredential);
        }
    }
}
