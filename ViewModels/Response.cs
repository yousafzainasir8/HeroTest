using Microsoft.AspNetCore.Http;

namespace HeroTest.ViewModels;

public class Response<T>
{
    public T? Data { get; set; }
    public bool IsSuccess { get; set; } = true; 
    public string Message { get; set; }

}


