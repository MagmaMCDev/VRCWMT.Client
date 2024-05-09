using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MagmaMC.SharedLibrary;
using VRCWMT.Models;

namespace VRCWMT;

public static class API
{
    private static readonly ConcurrentBag<HttpClient> _httpClientBag = new ConcurrentBag<HttpClient>();
    private static readonly ConcurrentDictionary<string, VRCW> _worldCache = new();


    public const string APIBase = "https://vrc.magmamc.dev/API/V1/";
    public static Uri APIUriBase => new(APIBase);



    private static HttpClient GetHttpClient()
    {
        if (_httpClientBag.TryTake(out HttpClient httpClient))
        {
            return httpClient;
        }
        else
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(APIBase);
            httpClient.DefaultRequestHeaders.Add("Authorization", Config.GithubAuth);
            httpClient.Timeout = TimeSpan.FromSeconds(6);
            return httpClient;
        }
    }
    private static async Task<bool> CheckStatus()
    {
        using (HttpClient httpClient = GetHttpClient())
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("/status");
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    private static void ReturnHttpClient(HttpClient httpClient)
    {
        _httpClientBag.Add(httpClient);
    }

    public static async Task<bool> AddWorldAsync(string worldName, string worldDescription, string githubRepo, byte[] imageData, string imageExtension)
    {
        var httpClient = GetHttpClient();
        try
        {
            MultipartFormDataContent content = new MultipartFormDataContent
                {
                    { new StringContent(worldName), "WorldName" },
                    { new StringContent(worldDescription), "WorldDescription" },
                    { new StringContent(githubRepo), "GithubRepo" }
                };

            ByteArrayContent imageContent = new ByteArrayContent(imageData);
            imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            content.Add(imageContent, "file", $"image.{imageExtension}");

            HttpResponseMessage response = await httpClient.PostAsync("/Worlds", content);
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }

    public static async Task<byte[]?> GetWorldImageAsync(string id)
    {
        var httpClient = GetHttpClient();
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync($"/Worlds/{id}/Image");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }
        catch
        {
            return null;
        }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }

    public static bool PushCommits(string WorldID)
    {
        var httpClient = GetHttpClient();
        try
        {
            return httpClient.PostAsync($"Worlds/{WorldID}/PushCommits", null).Result.IsSuccessStatusCode;
        }
        catch { return false; }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }

    public static string[] GetCommits(string WorldID)
    {
        var httpClient = GetHttpClient();
        try
        {
            return JsonSerializer.Deserialize<string[]>(httpClient.GetStringAsync($"Worlds/{WorldID}/GetCommits").Result)!;
        }
        catch { return Array.Empty<string>(); }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }

    public static VRCW? GetWorld(string id)
    {
        var httpClient = GetHttpClient();
        try
        {
            if (_worldCache.TryGetValue(id, out var cachedWorld))
                return cachedWorld;

            HttpResponseMessage response = httpClient.GetAsync($"Worlds/{id}").GetResult();
            HttpContent content = response.Content;
            VRCW? World = JsonSerializer.Deserialize<VRCW>(content.ReadAsStringAsync().Result);
            if (World != null)
                World.ID = id;
            _worldCache[id] = World ?? new VRCW();
            return World;
        }
        catch
        {
            return null;
        }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }

    public static SiteUser? GetUser(string worldId, string username)
    {
        var httpClient = GetHttpClient();
        try
        {
            HttpResponseMessage response = httpClient.GetAsync($"Worlds/{worldId}/{username}").GetResult();
            HttpContent content = response.Content;
            string res = content.ReadAsStringAsync().Result ?? string.Empty;
            return JsonSerializer.Deserialize<SiteUser>(res)!;
        }
        catch
        {
            return null;
        }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }


    public static Dictionary<string, string[]>? GetGroups(this VRCW World)
    {
        var httpClient = GetHttpClient();
        try
        {
            HttpContent Content = httpClient.GetAsync($"Worlds/{World.ID}/Groups").GetResult().Content;
            string a = Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonSerializer.Deserialize<Dictionary<string, string[]>>(a);
        }
        catch
        {
            return null;
        }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }
    public static string[]? GetPermissions(this VRCW World, string Group)
    {
        var httpClient = GetHttpClient();
        try
        {
            HttpContent Content = httpClient.GetAsync($"/Worlds/{World.ID}/Groups").GetResult().Content;
            return JsonSerializer.Deserialize<Dictionary<string, string[]>>(Content.ReadAsStringAsync().GetResult())!["Group"];
        }
        catch
        {
            return null;
        }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }
}
