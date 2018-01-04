using System.ComponentModel.DataAnnotations;

namespace Traininghub.Data
{
    public interface IClientEntity
    {
        [Key]
        int Id { get; set; }
    }
}