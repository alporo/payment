using System;

namespace AFS.Payment.Utility
{
    public interface Option<T>
    {
        Option<TO> Map<TO>(Func<T, Option<TO>> func) where TO : class;
        Option<TO> Map<TO>(Func<T, TO> func) where TO : class;
        Option<TO> Map<TO>(Func<T, TO?> func) where TO : struct;
        Option<T> Map(Action<T> action);
        T OrElse(T defaultValue);
        T OrElse(Func<T> defaultFunc);
        T OrThrow(Exception e);
        bool HasValue();
    }

    public class Some<T> : Option<T>
    {
        private readonly T _value;
        public Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            _value = value;
        }
        public Option<TO> Map<TO>(Func<T, Option<TO>> func) where TO : class => func(_value);
        public Option<TO> Map<TO>(Func<T, TO> func) where TO : class => new Some<TO>(func(_value));

        public Option<TO> Map<TO>(Func<T, TO?> func) where TO : struct
        {
            var r = func(_value);
            return r.HasValue ? new Some<TO>(r.Value) : new None<TO>() as Option<TO>;
        }

        public Option<T> Map(Action<T> action)
        {
            action(_value);
            return this;
        }

        public T OrElse(T defaultValue) => _value;
        public T OrElse(Func<T> defaultFunc) => _value;

        public T OrThrow(Exception e) => _value;

        public bool HasValue() => true;
    }

    public class None<T> : Option<T>
    {
        public Option<TO> Map<TO>(Func<T, Option<TO>> func) where TO : class => new None<TO>();
        public Option<TO> Map<TO>(Func<T, TO> func) where TO : class => new None<TO>();
        public Option<TO> Map<TO>(Func<T, TO?> func) where TO : struct => new None<TO>();

        public Option<T> Map(Action<T> action) => this;
        public T OrElse(T defaultValue) => defaultValue;
        public T OrElse(Func<T> defaultFunc) => defaultFunc();

        public T OrThrow(Exception e) { throw e; } 

        public bool HasValue() => false;
    }

    public static class Option
    {
        public static Option<T> AsOption<T>(this T value)
            where T : class => value != null ? new Some<T>(value) : new None<T>() as Option<T>;

        public static Option<T> AsOption<T>(this T? value) where T : struct =>
            value == null ? new None<T>() : new Some<T>(value.Value) as Option<T>;
        public static T OrThrow<T>(this Option<T> maybe, string message) =>
            maybe.OrThrow(new Exception(message));
    }
}