require "common/init"
require "uiscripts/init"
require "eventsystem/init"
require "framework/init"

string_table = require "globalization/zh/string_table"

UGameObject = UnityEngine.GameObject
UObject = UnityEngine.Object

UNetworkManager = LuaHelper.GetNetManager()
