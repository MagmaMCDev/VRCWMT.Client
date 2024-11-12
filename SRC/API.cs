using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MagmaMC.SharedLibrary;
using OpenVRChatAPI.Models;
using VRCWMT.Models;

namespace VRCWMT;

public static class API
{
    private static readonly ConcurrentBag<HttpClient> _httpClientBag = new();
    private static readonly ConcurrentDictionary<string, VRCW> _worldCache = new();


    public const string APIBase = "https://vrc.magmamc.dev/API/V3/";
    public static Uri APIUriBase => new(APIBase);



    public static HttpClient GetHttpClient()
    {
        if (_httpClientBag.TryTake(out var httpClient))
        {
            return httpClient;
        }
        else
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(APIBase);
            httpClient.DefaultRequestHeaders.Add("User-Agent", Client.User_Agent);
            httpClient.DefaultRequestHeaders.Add("Authorization", Config.GithubAuth);
            httpClient.Timeout = TimeSpan.FromSeconds(6);
            return httpClient;
        }
    }
    public static async Task<bool> CheckStatus()
    {
        using HttpClient httpClient = GetHttpClient();
        try
        {
            httpClient.Timeout = TimeSpan.FromSeconds(4);
            using HttpResponseMessage response = await httpClient.GetAsync("/status");
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static void ReturnHttpClient(HttpClient httpClient)
    {
        _httpClientBag.Add(httpClient);
    }
    public static async Task<string> AddWorldAsync(string worldName, string worldDescription, string githubRepo, byte[] imageData, string imageExtension)
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

            using HttpResponseMessage response = await httpClient.PostAsync("Worlds", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return "";
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
            using HttpResponseMessage response = await httpClient.GetAsync($"/Worlds/{id}/Image");
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

    public static string[]? GetWorldStaff(string WorldID)
    {
        var httpClient = GetHttpClient();
        try
        {
            using HttpResponseMessage response = httpClient.GetAsync($"Worlds/{WorldID}/Access/Write").GetResult();
            using HttpContent content = response.Content;
            return JsonSerializer.Deserialize<string[]>(content.ReadAsStringAsync().GetResult())!;
        }
        catch { return null; }
        finally
        {
            ReturnHttpClient(httpClient);
        }
    }
    public static string[]? GetWorldMods(string WorldID)
    {
        var httpClient = GetHttpClient();
        try
        {
            using HttpResponseMessage response = httpClient.GetAsync($"Worlds/{WorldID}/Access/Read").GetResult();
            using HttpContent content = response.Content;
            return JsonSerializer.Deserialize<string[]>(content.ReadAsStringAsync().GetResult())!;
        }
        catch { return null; }
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
            using HttpResponseMessage response = httpClient.GetAsync($"Worlds/{WorldID}/GetCommits").GetResult();
            using HttpContent content = response.Content;
            return JsonSerializer.Deserialize<string[]>(content.ReadAsStringAsync().GetResult())!;
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

            using HttpResponseMessage response = httpClient.GetAsync($"Worlds/{id}").GetResult();
            using HttpContent content = response.Content;
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
            using HttpResponseMessage response = httpClient.GetAsync($"Worlds/{worldId}/{username}").GetResult();
            using HttpContent content = response.Content;
            var res = content.ReadAsStringAsync().Result ?? string.Empty;
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

    public static async Task<bool> AddGroup(string worldID, string groupName, string permissions)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
        {
            { "GroupName", groupName },
            { "Permissions", permissions },
            { "FormType", "ADD" }
        };

            var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Groups", content);
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
    public static async Task<bool> RemoveGroup(string worldID, string groupName)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
        {
            { "GroupName", groupName },
            { "FormType", "REMOVE" }
        };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Groups", content);
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

    public static async Task<bool> AddPlayer(string worldID, string permissionGroup, string playerID, string message)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
        {
            { "WorldID", worldID },
            { "PlayerID", playerID },
            { "Message", message },
            { "FormType", "ADD" }
        };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Groups/{permissionGroup}", content);
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
    public static async Task<bool> RemovePlayer(string worldID, string permissionGroup, string playerID, string message)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
            {
                { "WorldID", worldID },
                { "PlayerID", playerID },
                { "Message", message },
                { "FormType", "REMOVE" }
            };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Groups/{permissionGroup}", content);
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

    public static async Task<bool> AddWorldStaff(string worldID, string username)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
            {
                { "User", username },
                { "FormType", "ADD" }
            };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Access/Write", content);
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
    public static async Task<bool> RemoveWorldStaff(string worldID, string username)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
            {
                { "User", username },
                { "FormType", "REMOVE" }
            };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Access/Write", content);
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

    public static async Task<bool> AddWorldMod(string worldID, string username)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
            {
                { "User", username },
                { "FormType", "ADD" }
            };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Access/Read", content);
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
    public static async Task<bool> RemoveWorldMod(string worldID, string username)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
            {
                { "User", username },
                { "FormType", "REMOVE" }
            };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Access/Read", content);
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

    public static async Task<bool> EditWorldName(string worldID, string Name)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
            {
                { "Value", Name },
            };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Name", content);
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

    public static async Task<bool> EditWorldDescription(string worldID, string Description)
    {
        var httpClient = GetHttpClient();
        try
        {
            var formData = new Dictionary<string, string>
            {
                { "Value", Description },
            };

            using var content = new FormUrlEncodedContent(formData);

            using HttpResponseMessage response = await httpClient.PostAsync($"Worlds/{worldID}/Description", content);
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


    public static async Task<bool> AddPlayer(this VRCW world, string groupName, string playerID, string message) =>
       await AddPlayer(world.ID, groupName, playerID, message);
    public static async Task<bool> RemovePlayer(this VRCW world, string groupName, string playerID, string message) =>
        await RemovePlayer(world.ID, groupName, playerID, message);

    public static async Task<bool> AddGroup(this VRCW world, string groupName, string permissions) =>
        await AddGroup(world.ID, groupName, permissions);
    public static async Task<bool> RemoveGroup(this VRCW world, string groupName) =>
        await RemoveGroup(world.ID, groupName);

    public static async Task<bool> AddStaff(this VRCW world, string username) =>
        await AddWorldStaff(world.ID, username);
    public static async Task<bool> RemoveStaff(this VRCW world, string username) =>
        await RemoveWorldStaff(world.ID, username);
    public static async Task<bool> AddMod(this VRCW world, string username) =>
        await AddWorldMod(world.ID, username);
    public static async Task<bool> RemoveMod(this VRCW world, string username) =>
        await RemoveWorldMod(world.ID, username);
    public static string[]? GetStaff(this VRCW world) =>
        GetWorldStaff(world.ID);
    public static string[]? GetMods(this VRCW world) =>
        GetWorldMods(world.ID);
    public static async Task<bool> EditWorldName(this VRCW world, string Name) =>
        await EditWorldDescription(world.ID, Name);
    public static async Task<bool> EditWorldDescription(this VRCW world, string Description) =>
        await EditWorldDescription(world.ID, Description);


    public static Dictionary<string, string[]>? GetGroups(this VRCW World)
    {
        var httpClient = GetHttpClient();
        try
        {
            using HttpContent Content = httpClient.GetAsync($"Worlds/{World.ID}/Groups").GetResult().Content;
            var Result = Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonSerializer.Deserialize<Dictionary<string, string[]>>(Result);
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
    public static PlayerItem[]? GetPlayers(this VRCW World, string Group)
    {
        var httpClient = GetHttpClient();
        try
        {
            using HttpContent Content = httpClient.GetAsync($"Worlds/{World.ID}/Groups/{Group}").GetResult().Content;
            var Result = Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonSerializer.Deserialize<PlayerItem[]>(Result);
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
    public static VRCUser? GetVRCUser(this VRCW World, string PLayerID)
    {
        var httpClient = GetHttpClient();
        try
        {
            using HttpContent Content = httpClient.GetAsync($"Worlds/{World.ID}/VRChat/Users/{PLayerID}").GetResult().Content;
            var Result = Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonSerializer.Deserialize<VRCUser>(Result);
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
