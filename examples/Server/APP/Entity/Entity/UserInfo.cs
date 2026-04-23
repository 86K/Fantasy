using Fantasy.Entitas;
using Fantasy.Entitas.Interface;
using Newtonsoft.Json;

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

    /// <summary>
    /// 状态：1（登录中）、0（未登录）。
    /// </summary>
    public int loggingIn;
}