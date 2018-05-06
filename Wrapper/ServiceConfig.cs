using Proto;

namespace Wrapper
{
    public sealed class ServiceConfig : IServiceConfig
    {
        internal readonly Props Props;

        public ServiceConfig(string name, Props props)
        {
            Name = name;
            Props = props;
        }

        public string Name { get; }

        #region Equality members

        private bool Equals(ServiceConfig other)
        {
            return Equals(Props, other.Props) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ServiceConfig) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Props != null ? Props.GetHashCode() : 0) * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        #endregion
    }
}