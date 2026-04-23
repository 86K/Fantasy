using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Fantasy;

/// <summary>
/// 处理登出消息。
/// </summary>
public class C2G_SignoutMessageHandler : Message<C2G_SignoutMessage>
{
    protected override async FTask Run(Session session, C2G_SignoutMessage message)
    {
        var userId = message.userId;
        
        var db = session.Scene.World[Common.Database.Name];
        var userInfos = await db?.Query<UserInfo>(x=>x.Id.Equals(userId), true)!;
        foreach (var userInfo in userInfos)
        {
            if (userInfo.Id == userId)
            {
                userInfo.loggingIn = 0;
                await db.Save(userInfo);
                Log.Debug($"{userInfo.account} 已登出");
            }
        }
        
        await FTask.CompletedTask;
    }
}