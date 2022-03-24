using Netcorext.EntityFramework.UserIdentityPattern.Entities;

namespace Lctech.Configuration.Domain.Entities;

public class Configuration : Entity
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Group { get; set; }
    public string Source { get; set; }
    public long? ParentId { get; set; }
    public string Hierarchy { get; set; }
    public int Level { get; set; }
    public int SortingIndex { get; set; }
}