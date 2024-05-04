namespace ecoapp.Response
{
    static public class ResponseMaker<T>
    {
        static public ResponseObject<T> GetResponse(T data , int code,  string message)
        {
            if (code == 200)
            {
                return new ResponseObject<T>() { Code = code, Data = data, Message = message };
            }
            return new ResponseObject<T>() { Code =  500, Data = data, Message = "error" };

        }
        
        
    }
}
