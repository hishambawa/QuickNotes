using System;
namespace QuickNotes.DTO
{
    public class Response
    {
        public int Status { get; set; }
        public dynamic? Data { get; set; }
        public string Message { get; set; }

        public Response()
        {
        }

        public Response(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public Response(int Status, dynamic Data, string Message)
        {
            this.Status = Status;
            this.Data = Data;
            this.Message = Message;
        }
    }
}

