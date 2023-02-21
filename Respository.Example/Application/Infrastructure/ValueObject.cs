namespace Application.Infrastructure
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object>? GetAttributesToIncludeEqualityCheck();

        public override bool Equals(object obj){

                return Equals(obj as T);
        }

        public bool Equals(T other)
        {
            if (other == null)
                return false;

            return GetAttributesToIncludeEqualityCheck().SequenceEqual(other.GetAttributesToIncludeEqualityCheck());
        }

        public static bool operator == (ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }
        public static bool operator != (ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public override int GetHashCode()
        {

            int hash = 17;
            foreach (var item in GetAttributesToIncludeEqualityCheck())
            {
                hash = hash * 31 + (item == null ? 0 : item.GetHashCode());
            }
            return hash;
        }

    }
}