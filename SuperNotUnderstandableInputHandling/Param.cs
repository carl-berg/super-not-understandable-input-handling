﻿namespace SuperNotUnderstandableInputHandling
{
    public class Param<T>
    {
        internal InputParam<T> inputParam;
        internal readonly T defaultValue;
        internal readonly bool optional;
        private readonly IInput input;

        public InputValue<T> Value { get; internal set; }
        public TrySetResult<T> LastResult { get; private set; }

        public Param(InputParam<T> inputParam, T defaultValue, bool optional, IInput input)
        {
            this.inputParam = inputParam;
            this.defaultValue = defaultValue;
            this.optional = optional;
            this.input = input;
        }

        public void SetValue(T value)
        {
            Value = InputValue<T>.Of(value);
        }

        public void SetValueNull()
        {
            Value = InputValue<T>.Null;
        }

        public T Get()
        {
            if(Value == null)
            {
                LastResult = input.TrySet(this);
            }

            return Value.HasValue ? Value.Value : defaultValue;
        }
    }
}