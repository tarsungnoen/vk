using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AudioCategory
{
	/// <inheritdoc />
	public Task<long> AddAsync(long audioId,
								long ownerId,
								string accessKey = null,
								long? groupId = null,
								long? albumId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(audioId, ownerId, accessKey, groupId, albumId), token);

	/// <inheritdoc />
	public Task<AudioPlaylist> CreatePlaylistAsync(long ownerId,
													string title,
													string description = null,
													IEnumerable<string> audioIds = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreatePlaylist(ownerId, title, description, audioIds), token);

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long audioId,
								long ownerId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(audioId, ownerId), token);

	/// <inheritdoc />
	public Task<bool> DeletePlaylistAsync(long ownerId,
										long playlistId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeletePlaylist(ownerId, playlistId), token);

	/// <inheritdoc />
	public Task<long> EditAsync(AudioEditParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params), token);

	/// <inheritdoc />
	public Task<bool> EditPlaylistAsync(long ownerId,
										int playlistId,
										string title,
										string description = null,
										IEnumerable<string> audioIds = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditPlaylist(ownerId, playlistId, title, description, audioIds), token);

	/// <inheritdoc />
	public Task<VkCollection<Audio>> GetAsync(AudioGetParams @params,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<AudioPlaylist>> GetPlaylistsAsync(long ownerId,
																uint? count = null,
																uint? offset = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPlaylists(ownerId, count, offset), token);

	/// <inheritdoc />
	public Task<AudioPlaylist> GetPlaylistByIdAsync(long ownerId,
													long playlistId,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPlaylistById(ownerId, playlistId), token);

	/// <inheritdoc />
	public Task<IEnumerable<object>> GetBroadcastListAsync(AudioBroadcastFilter filter = null,
															bool? active = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetBroadcastList(filter, active), token);

	/// <inheritdoc />
	public Task<IEnumerable<Audio>> GetByIdAsync(IEnumerable<string> audios,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(audios), token);

	/// <inheritdoc />
	public Task<AudioGetCatalogResult> GetCatalogAsync(uint? count,
														bool? extended,
														UsersFields fields = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalog(count, extended, fields), token);

	/// <inheritdoc />
	public Task<long> GetCountAsync(long ownerId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCount(ownerId), token);

	/// <inheritdoc />
	public Task<Lyrics> GetLyricsAsync(long lyricsId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLyrics(lyricsId), token);

	/// <inheritdoc />
	public Task<IEnumerable<Audio>> GetPopularAsync(bool onlyEng = false,
													AudioGenre? genre = null,
													uint? count = null,
													uint? offset = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPopular(onlyEng, genre, count, offset), token);

	/// <inheritdoc />
	public Task<VkCollection<Audio>> GetRecommendationsAsync(string targetAudio = null,
															long? userId = null,
															uint? count = null,
															uint? offset = null,
															bool? shuffle = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRecommendations(targetAudio, userId, count, offset, shuffle), token);

	/// <inheritdoc />
	public Task<UploadServer> GetUploadServerAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetUploadServer, token);

	/// <inheritdoc />
	public Task<IEnumerable<long>> AddToPlaylistAsync(long ownerId,
													long playlistId,
													IEnumerable<string> audioIds,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddToPlaylist(ownerId, playlistId, audioIds), token);

	/// <inheritdoc />
	public Task<bool> ReorderAsync(long audioId,
									long? ownerId,
									long? before,
									long? after,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Reorder(audioId, ownerId, before, after), token);

	/// <inheritdoc />
	public Task<Audio> RestoreAsync(long audioId,
									long? ownerId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Restore(audioId, ownerId), token);

	/// <inheritdoc />
	public Task<Audio> SaveAsync(string response,
								string artist = null,
								string title = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(response, artist, title), token);

	/// <inheritdoc />
	public Task<VkCollection<Audio>> SearchAsync(AudioSearchParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params), token);

	/// <inheritdoc />
	public Task<IEnumerable<long>> SetBroadcastAsync(string audio = null,
													IEnumerable<long> targetIds = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetBroadcast(audio, targetIds), token);
}