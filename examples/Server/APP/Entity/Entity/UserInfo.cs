using Fantasy.Entitas;
using Fantasy.Entitas.Interface;

/// <summary>
/// 用户信息。
/// </summary>
public sealed class UserInfo : Entity, ISupportedSerialize
{
    /// <summary>
    /// 账号。
    /// </summary>
    public string account;
    
    /// <summary>
    /// 密码。
    /// </summary>
    public string password;
}