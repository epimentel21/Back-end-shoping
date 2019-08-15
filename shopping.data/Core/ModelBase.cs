using System;
using System.Collections.Generic;
using System.Text;

namespace shopping.data.Core
{
    public class ModelBase<T>
    {
        

        public T Id { get; set; }
        public bool IsNewModel()
        {
            return Id.Equals(default(T));
        }
    }
}
