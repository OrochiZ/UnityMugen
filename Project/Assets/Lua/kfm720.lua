local trigger = require("trigger")

local setmetatable = setmetatable
local GlobaConfigMgr = MonoSingleton_GlobalConfigMgr.GetInstance()

local kfm720 = {}
kfm720.__index = kfm720

function kfm720:new()
   -- 静态数据
   if self._isInit == nil then
		self._isInit = true
		self:_initData()
		self:_initSize()
		self:_initStateDefs()
		self:_initCmds()
    end
   -- 动态数据
   local t = {PlayerDisplay = nil}
   return setmetatable(t, kfm720)
end

--====================外部调用接口==============================

function kfm720:OnInit(playerDisplay)
	self.PlayerDisplay = playerDisplay;
	trigger:Help_InitLuaPlayer(self, self)
end

function kfm720:OnDestroy()
  self.PlayerDisplay = nil
end

function kfm720:OnGetAICommandName(cmdName)
	
end

--===========================================================

function kfm720:_initData()
  if self.Data ~= nil then
	return
  end
  self.Data = {};
  
  self.Data.life = 1000
  self.Data.attack = 100
  self.Data.defence = 100
  
  self.Data.fall = {}
  self.Data.fall.defence_up = 50
  
  self.Data.liedown = {}
  self.Data.liedown.time = 60
  
  self.Data.airjuggle = 15
  self.Data.sparkno = 2
  
  self.Data.guard = {}
  self.Data.guard.sparkno = 40
  
  self.Data.KO = {}
  self.Data.KO.echo = 0
  
  self.Data.volume = 0
  self.Data.IntPersistIndex = 60
  self.Data.FloatPersistIndex = 40
end

function kfm720:_initSize()
  if self.Size ~= nil then
	return
  end
  self.Size = {}
  self.Size.xscale = 1
  self.Size.yscale = 1
end

--=====================================创建StateDef===================================
function kfm720:_initStateDefs()
	local luaCfg = GlobaConfigMgr:GetLuaCnsCfg("kfm720")
	if luaCfg == nil then
		return
	end
	
	-- 创建各种状态
	self:_initStateDef_200(luaCfg)
	self:_initStateDef_3000(luaCfg)
end

function kfm720:_initStateDef_200(luaCfg)
	local id = trigger:Help_CreateStateDef(luaCfg, "200")
	local def = trigger:Help_GetStateDef(luaCfg, id)
	--Def注册State
end

function kfm720:_initStateDef_3000(luaCfg)
	local id = trigger:Help_CreateStateDef(luaCfg, "3000")
	local def = trigger:Help_GetStateDef(luaCfg, id)
	def.Type = Mugen.Cns_Type.S
	def.MoveType = Mugen.Cns_MoveType.A
	def.PhysicsType = Mugen.Cns_PhysicsType.S
	def.Juggle = 4
	def.Animate = 3000
	def.Ctrl = 0
	def.Sprpriority = 2
	def.Velset_x = 0
	def.Velset_y = 0
end
--======================================================================================

function kfm720:_initCmds()
end

setmetatable(kfm720, {__call = kfm720.new})
return kfm720