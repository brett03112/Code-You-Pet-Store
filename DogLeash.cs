using System.Text.Json;

namespace Store.App;

internal class DogLeash : Product
{
    public int LengthInches { get; set; }
    public string? Material { get; set; }
    
}