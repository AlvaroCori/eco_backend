namespace ecoapp.Response
{
    public class ResponseObject<T>
    {
        public T? Data { get; set; }
        public int Code { get; set; }
        public string? Message { get; set; }
    }
}
