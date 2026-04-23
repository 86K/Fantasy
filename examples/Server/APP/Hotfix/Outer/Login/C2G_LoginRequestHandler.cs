using Fantasy.Async;
using Fantasy.Entitas;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Fantasy;

/// <summary>
/// 处理登录请求。
/// </summary>
public class C2G_LoginRequestHandler : MessageRPC<C2G_LoginRequest, G2C_LoginResponse>
{
    protected override async FTask Run(Session session, C2G_LoginRequest request, G2C_LoginResponse response, Action reply)
    {
        var account = request.account;
        var password = request.password;
        
        // 查询数据库中是否有这个账号
        Log.Debug($"{account} {password} 请求登录");

        var db = session.Scene.World[Common.Database.Name];
        var userInfos = await db?.Query<UserInfo>(x=>x.account.Equals(account) && x.password.Equals(password), true)!;
        
        if (userInfos == null || userInfos.Count == 0)
        {
            response.code = "301";
            response.result = "账号或密码错误";
        }
        else
        {
            var userInfo = userInfos[0];
            if (userInfo.loggingIn == 1)
            {
                // 告诉后登录的，已经有人登录这个账号了
                response.code = "302";
                response.result = "账号已登录";
            }
            else
            {
                userInfo.loggingIn = 1;
                await db.Save(userInfo);
            
                response.code = "200";
                response.result = "登录成功";
                response.userId = userInfo.Id;
            }
        }
        
        await FTask.CompletedTask;
    }
}