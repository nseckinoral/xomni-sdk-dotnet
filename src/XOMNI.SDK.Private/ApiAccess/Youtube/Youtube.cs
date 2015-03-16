using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Core.ApiAccess;
using XOMNI.SDK.Core.Providers;
using XOMNI.SDK.Model.Asset;
using XOMNI.SDK.Model.Youtube;

namespace XOMNI.SDK.Private.ApiAccess.Youtube
{
    public class Youtube : ApiAccessBase
    {
        protected override string SingleOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override string ListOperationBaseUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected string ChannelSearchUrl
        {
            get { return "/private/youtube/channelsearch"; }
        }

        protected string ChannelVideoFetchUrl
        {
            get { return "/private/youtube/channelvideos"; }
        }
        protected string ChannelPlaylistFetchUrl
        {
            get { return "/private/youtube/playlistsearch"; }
        }
        protected string PlaylistVideoFetchUrl
        {
            get { return "/private/youtube/playlistvideos"; }
        }
        protected string RelateVideoUrl
        {
            get { return "/private/youtube/videoRelation"; }
        }

        public Task<List<Channel>> SearchChannelsAsync(string channelName, int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("channelName", channelName);
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());

            return HttpProvider.GetAsync<List<Channel>>(GenerateUrl(ChannelSearchUrl, additionalParameters), credential);
        }

        public Task<List<Video>> GetVideosInChannelAsync(string channelId, int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("channelId", channelId);
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());

            return HttpProvider.GetAsync<List<Video>>(GenerateUrl(ChannelVideoFetchUrl, additionalParameters), credential);
        }

        public Task<List<Playlist>> GetPlaylistsInChannelAsync(string channelId, int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("channelId", channelId);
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());

            return HttpProvider.GetAsync<List<Playlist>>(GenerateUrl(ChannelPlaylistFetchUrl, additionalParameters), credential);
        }

        public Task<List<Video>> GetVideosInPlaylistAsync(string playlistId, int skip, int take, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("playlistId", playlistId);
            additionalParameters.Add("skip", skip.ToString());
            additionalParameters.Add("take", take.ToString());

            return HttpProvider.GetAsync<List<Video>>(GenerateUrl(PlaylistVideoFetchUrl, additionalParameters), credential);
        }

        public Task<AssetRelationMapping> RelateVideoAsync(int itemId, YoutubeAssetRelation relation, ApiBasicCredential credential)
        {
            Dictionary<string, string> additionalParameters = new Dictionary<string, string>();
            additionalParameters.Add("itemId", itemId.ToString());

            return HttpProvider.PostAsync<AssetRelationMapping>(GenerateUrl(RelateVideoUrl, additionalParameters), relation, credential);
        }
    }
}
