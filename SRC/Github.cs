using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using VRCWMT.Models;
namespace VRCWMT;

public class Github
{
    private static readonly ConcurrentDictionary<string, GithubUser> _userCache = new();
    public static void ClearCache() => _userCache.Clear();

    public static async Task<GithubUser> GetUserAsync(string token)
    {
        if (_userCache.TryGetValue(token, out var cachedUser))
            return cachedUser;

        GithubUser user = (await FetchUserAsync(token))!;
        _userCache[token] = user;
        return user;
    }

    private static async Task<GithubUser?> FetchUserAsync(string token)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        httpClient.DefaultRequestHeaders.Add("User-Agent", Client.User_Agent);

        var response = await httpClient.GetAsync("https://api.github.com/user");
        if (!response.IsSuccessStatusCode)
            return null;
        var json = await response.Content.ReadAsStringAsync();
        var userData = JsonSerializer.Deserialize<GithubUser>(json)!;
        userData.Access_Token = token;
        return userData;
    }
}

public class GithubUser
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string login
    {
        get; set;
    }
    public uint id
    {
        get; set;
    }
    public string name
    {
        get; set;
    }
    public string avatar_url
    {
        get; set;
    }
    public string Access_Token
    {
        get; set;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

public struct GithubAuth
{
    public static GithubUser? GetUser(string Access_Token)
    {
        try
        {
            GithubUser User = Github.GetUserAsync(Access_Token).GetAwaiter().GetResult();
            return User;
        }
        catch { return null; }
    }
}