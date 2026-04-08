- 使用.proto文件定义消息结构
- 使用.Config文件管理路由和漫游类型

- Inner是服务器间的协议；Outer是客户端-服务器间的协议

- 框架基于proto3标准，支持以下数据类型：
	- int、uint、int32、uint32、int64、uint64
	- float、double、long
	- bool
	- byte、bytes
	- string
	- enum
	- 自定义消息类型：repeated MessageNameDefine xxx = 1
	- 自定义类型：原样保留。
	- 集合类型
		- repeated -> List<T>；自动初始化（List<T> = new List<T>())；默认选择
		- repeatedList -> List<T>
		- repeatedArray -> T[]
	- map  map<KeyType, ValueType> FieldName = FieldNumber;
		- KeyType必须是基本类型或枚举，不能是复杂对象
		- ValueType可以是所有基本类型、自定义枚举类型、自定义消息类型

> 不要删除字段: 使用新的消息类型替代
> 不要修改字段编号: 会导致序列化失败
> 添加字段要向后兼容: 使用可选字段

- OpCode有框架自动生成在Opcode.Cache文件中
1-999，框架保留，不要使用
1000-9999，Outer协议
10000-19999，Inner协议
20000+，扩展协议，可自定义范围

- IMessage  普通消息：通知、广播、状态同步
- IRequest,响应名  请求消息：查询、执行操作
- IResponse  返回消息：返回请求结果

- C - Client（客户端）
- G - Gate（网关服务器）


----------------------------------------------------------------
> 定义消息结构，需要注释标记消息接口类型
> 定义在XXXMessage.proto文件中

// 普通客户端消息（IMessage，单向发送）
message C2G_TestMessage // IMessage

---

// RPC请求（IRequest）
message C2G_LoginRequest // IRequest,G2C_LoginResponse

// RPC响应（IResponse）
message G2C_LoginResponse // IResponse

----------------------------------------------------------------




----------------------------------------------------------------
> 定义枚举类型，不需要接口注释
> 定义在XXXType.Config文件中


// Route 路由协议，用于客户端-服务器之间：RouteType.Config
GateRoute = 1001 

// RoamingType 漫游协议，用于服务器之间：RoamingType.Config
MapRoamingType = 10001

----------------------------------------------------------------