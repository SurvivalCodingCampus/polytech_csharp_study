using System.Reflection.Metadata;

namespace CsharpStudy.DTO.Model;

public record Pokemon(string Name, string ImageUrl);

/*public class Pokemon
{
    
    public string Name { get;  }
     public string ImageUrl { get;  }

     public Pokemon(string name, string imageUrl)
     {
         Name = name;
         ImageUrl = imageUrl;
     }

     protected bool Equals(Pokemon other)
     {
         return Name == other.Name && ImageUrl == other.ImageUrl;
     }

     public override bool Equals(object? obj)
     {
         if(obj is null) return false;
         if(ReferenceEquals(this, obj)) return true;
         if(obj.GetType() != this.GetType()) return false;
         return Equals((Pokemon)obj);
     }

     public override int GetHashCode()
     {
         return HashCode.Combine(Name, ImageUrl);
     }

     public override string ToString()
     {
         return $"{nameof(Name)}: {Name}, {nameof(ImageUrl)}: {ImageUrl}";
     }
}*/