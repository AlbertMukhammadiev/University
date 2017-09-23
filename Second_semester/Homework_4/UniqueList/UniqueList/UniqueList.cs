using ListNamespace;

namespace UniqueListNamespace
{
    public class UniqueList : List
    {
        /// <summary>
        /// duplicate values are ignored
        /// </summary>
        /// <param name="value"></param>
        public override void Add(int value)
        {
            if (this.Contains(value))
            {
                throw new DuplicateValuesException("the list contains the given value");
            }

            base.Add(value);
        }

        /// <summary>
        /// duplicate values are ignored
        /// </summary>
        /// <param name="value"></param>
        public override void AddWithKeepingOrder(int value)
        {
            if (this.Contains(value))
            {
                throw new DuplicateValuesException("the list contains the given value");
            }

            base.AddWithKeepingOrder(value);
        }
    }
}
