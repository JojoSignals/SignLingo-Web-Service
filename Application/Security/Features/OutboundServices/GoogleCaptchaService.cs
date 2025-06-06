using System.Text;
using System.Text.Json;
using Domain.Security.Model.Responses;
using Domain.Security.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Security.Features.OutboundServices;

public class GoogleCaptchaService : IGoogleCaptchaService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    
    public GoogleCaptchaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<bool> ValidateAsync(string captchaResponse)
    {
        var key = _configuration["GoogleCaptcha:SecretKey"];
        
        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(captchaResponse))
            return false;

        var response = await _httpClient.PostAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={key}&response={captchaResponse}",
            null);
        Console.WriteLine("🛰️ Status de Google: " + response.StatusCode);
        if (!response.IsSuccessStatusCode)
            return false;

        var json = await response.Content.ReadAsStringAsync();

        var captchaResult = JsonSerializer.Deserialize<GoogleCaptchaResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return captchaResult?.Success == true;
    }
}