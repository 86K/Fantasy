using Fantasy.Async;
using Fantasy.Entitas;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Fantasy.Outer.Login;

public class C2G_LoginRequestHandler : MessageRPC<C2G_LoginRequest, G2C_LoginResponse>
{
    protected override async FTask Run(Session session, C2G_LoginRequest request, G2C_LoginResponse response, Action reply)
    {
        var account = request.account;
        var password = request.password;
        
        // 查询数据库中是否有这个账号
        Log.Info($"{account} {password} 请求登录");

        var db = session.Scene.World[Common.Database.Name];
        var userInfos = await db?.Query<UserInfo>(x=>x.account.Equals(account) && x.password.Equals(password), true)!;
        
        // 模拟一次登录查询
        if (userInfos == null || userInfos.Count == 0)
        {
            var userInfo = Entity.Create<UserInfo>(session.Scene);
            userInfo.account = account;
            userInfo.password = password;
            await db.Save(userInfo);
            response.userId = userInfo.Id;
        }
        else
        {
            response.userId = userInfos[0].Id;
        }
        
        response.code = "200";
        response.result = "登录成功";
        
        await FTask.CompletedTask;
    }
}