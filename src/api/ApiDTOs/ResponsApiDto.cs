namespace api.ApiDTOs
{
    public class ResponsApiDto<T,E>
    {
        public T Data { get; set; }
        public bool Success => Errors == null;
        public List<E> Errors { get; private set; }
        public void AddError(E error)
        {
            if (Errors == null)
                Errors = new List<E>();

            Errors.Add(error);
        }
    }
}
