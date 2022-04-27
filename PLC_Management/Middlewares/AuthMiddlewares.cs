namespace PLC_Management.Middlewares
{
    public class AuthMiddlewares
    {
        private readonly RequestDelegate _next;
        public AuthMiddlewares(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string host = context.Request.Host.ToString();
            string path = context.Request.Path.ToString().ToLower();

            // Neu path = / , login , logout thi cho pheo di tiep 
            // neu khong thi phai co session xac nhan dang nhap moi cho tiep tuc
            // neu khong co session xac nhan thi chuyen ve trang dang nhap
            if(path == "/" || path.Contains("/login/login") || path.Contains("/login/logout"))
            {
               await _next(context);
            }
            else
            {
                if (context.Session.GetInt32(Common.SESSION_USER_LOGIN) != null)
                {
                    await _next(context);
                }
                else
                {
                    context.Response.Redirect(host);
                }
            }
        }
    }
}
    