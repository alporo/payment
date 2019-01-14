using System;

namespace AFS.Payment.Utility
{
    public class Maybe<T> where T : class
    {
        private readonly T value;

        public Maybe(T someValue)
        {
            value = someValue ?? throw new ArgumentNullException(nameof(someValue));
        }

        private Maybe()
        {
        }

        public Maybe<TO> Map<TO>(Func<T, Maybe<TO>> func) where TO : class => value != null ? func(value) : Maybe<TO>.None();
        public void Map(Action<T> action)
        {
            if (value != null)
                action(value);
        }

        public static Maybe<T> None() => new Maybe<T>();
    }

    public static class MaybeExtensions
    {
        public static Maybe<T> AsMaybe<T>(this T value) where T : class
        {
            return value != null ? new Maybe<T>(value) : Maybe<T>.None();
        }
    }
}
